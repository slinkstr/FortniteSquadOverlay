using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static FortniteSquadOverlayClient.MiscUtil;
using static FortniteSquadOverlayClient.ImageUtil;

namespace FortniteSquadOverlayClient
{
    internal static class Program
    {    
        private static string _localAppData   = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string _dataFolder     = Path.Combine(_localAppData, "FortniteOverlay");
        
        public static MainForm             MainWindow;
        public static OverlayForm          OverlayWindow;

        public static Config               Config       = new(_dataFolder, "config.json");
        public static HttpClient           HttpClient   = new HttpClient();
        public static Updater              Updater      = new Updater("https://api.github.com/repos/slinkstr/FortniteSquadOverlay/releases/latest", "FortniteSquadOverlay-Installer.exe", HttpClient);
        public static Logger               Logger       = new(Path.Combine(_dataFolder, "log.txt"));
        
        public static FortnitePlayer       LocalPlayer  = null;
        public static List<FortnitePlayer> CurrentSquad = [];
        public static List<string>         UserIdOrder  = [];
        public static bool                 DebugMode    = false;
        public static string               ProgramName  = "Fortnite Squad Overlay";
            
        private static readonly LogReader _logReader    = new LogReader(Path.Combine(_localAppData, "FortniteGame/Saved/Logs/FortniteGame.log"), LogParser.ProcessLine, ResetProgramState);
        private static readonly ProcMon   _procMon      = new ProcMon("FortniteClient-Win64-Shipping");
        
        private static Timer          _updateTimer      = new Timer();
        private static PixelPositions _pixelPositions   = null;
        private static Bitmap         _screenBuffer     = null;
        private static DateTime       _lastDownload     = DateTime.MinValue;
        private static DateTime       _lastUpload       = DateTime.MinValue;

        private static Bitmap _debugBuffer = null;

        [STAThread]
        static void Main()
        {
            // Initialize
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainWindow = new MainForm();
            OverlayWindow = new OverlayForm();

            HttpClient.DefaultRequestHeaders.Add("User-Agent", $"{Program.ProgramName} {Updater.CurrentVersion()} (+https://github.com/slinkstr/FortniteOverlay)");

            if (!Config.Exists())
            {
                Logger.LogInfo("Config not found, prompting first time config setup.");
                Config.Save();
                new ConfigForm().ShowDialog();
            }
            Config.Load();
            
            // Squadmate order
            Task.Run(async () =>
            {
                UserIdOrder = await GetOrder(HttpClient);
            });

            // Background tasks
            _logReader.Start();
            _procMon.Start();

            Task.Run(async () =>
            {
                try
                {
                    var hasUpdate = await Updater.CheckForUpdate();
                    if (hasUpdate)
                    {
                        string message = $"New update available ({Updater.LatestVersion()}).";
                        Logger.LogInfo(message);
                        MainWindow.SetUpdateNotice(message);
                    }
                    else
                    {
                        Logger.LogInfo("Program up to date.");
                    }
                }
                catch (Exception exc)
                {
                    Logger.LogError("Unable to check for updates: " +  exc);
                }
            });

            // Rendering and upload/download events
            _updateTimer.Tick += new EventHandler(UpdateEvent);
            _updateTimer.Interval = 500;
            _updateTimer.Start();

            try
            {
                Application.Run(MainWindow);
            }
            catch(Exception exc)
            {
                Logger.LogCritical("Unhandled exception: " + exc);
                Logger.Flush();
                MessageBox.Show(exc.ToString(), "Unhandled exception");
                Environment.Exit(1);
            }
        }

        public static void ResetProgramState()
        {
            Logger.LogInfo("Fortnite restarted, resetting log file.");
            LocalPlayer = null;
            CurrentSquad.Clear();
        }

        public static async void UpdateEvent(Object obj, EventArgs evtargs)
        {
            _updateTimer.Stop();
            _updateTimer.Interval = 500 * (_procMon.ValidHandle() ? 1 : 20);
            
            Logger.LogLevel = DebugMode ? Logger.LogSeverity.Debug : Logger.LogSeverity.Info;

            if (_procMon.ValidHandle())
            {
                _pixelPositions = PixelPositions.GetMatchingPositions(_procMon.WindowSize.Width, _procMon.WindowSize.Height, Config.HudScale);
            }

            var tasks = new List<Task>();
            if (_lastUpload.AddSeconds(Config.UploadInterval) - DateTime.UtcNow <= TimeSpan.FromSeconds(0.2))
            {
                tasks.Add(UploadGear());
            }
            if (_lastDownload.AddSeconds(Config.DownloadInterval) - DateTime.UtcNow <= TimeSpan.FromSeconds(0.2))
            {
                tasks.Add(DownloadGear());
            }
            await Task.WhenAll(tasks);

            if (Config.EnableOverlay && _procMon.Focused)
            {
                ShowOverlay();
                OverlayWindow.SetOverlayOpacity(Config.OverlayOpacity);
                OverlayWindow.SetHudScale((float)Config.HudScale / 100);
                if (DebugMode)
                {
                    ShowDebugOverlay();
                }
                else
                {
                    OverlayWindow.SetDebugOverlay(null);
                }
            }
            else
            {
                OverlayWindow.Hide();
                _debugBuffer = null;
            }

            if (!_procMon.ValidHandle())
            {
                // will eventually get GC'd
                _screenBuffer = null;
            }

            UpdateFormElements();

            _updateTimer.Start();
        }

        public static async Task UploadGear()
        {
            if (LocalPlayer == null)     { return; }
            if (!_procMon.Focused)       { return; }
            if (CurrentSquad.Count < 1)  { return; }

            TakeScreenshot(ref _screenBuffer, _procMon.WindowSize);

            if (!ImageProcessing.IsPlaying   (_screenBuffer, _pixelPositions)) { return; }
            if ( ImageProcessing.IsSpectating(_screenBuffer, _pixelPositions)) { return; }
            if ( ImageProcessing.IsDriving   (_screenBuffer, _pixelPositions)) { return; }

            var gearBitmap  = ImageProcessing.CropGear(_screenBuffer, _pixelPositions);
            var gearResized = new Bitmap(gearBitmap, new System.Drawing.Size( 5 * 52, 52));
            var stream      = new MemoryStream();
            gearResized.Save(stream, ImageFormat.Jpeg);
            stream.Seek(0, SeekOrigin.Begin);

            var formData = new MultipartFormDataContent
            {
                { new StringContent(Config.SecretKey), "secret" },
                { new StringContent(LocalPlayer.Name), "filename" },
                { new ByteArrayContent(stream.ToArray()), "gear", "image.jpg" }
            };

            _lastUpload = DateTime.UtcNow;
            string responseString = "";
            try
            {
                var response   = await HttpClient.PostAsync(Config.UploadEndpoint, formData);
                responseString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (Exception exc)
            {
                string err = "Error uploading data to server.\n" +
                             "-------------------------\n" +
                             exc + "\n" +
                             (!string.IsNullOrWhiteSpace(responseString) ? "-------------------------\nServer response:\n" + responseString : "");
                
                Logger.LogError(err);
                return;
            }

            LocalPlayer.GearImage = new Bitmap(stream);
            LocalPlayer.GearModified = DateTime.UtcNow;
            LocalPlayer.IsFaded = false;
        }

        public static async Task DownloadGear()
        {
            if (!_procMon.ValidHandle()) { return; }
            if (CurrentSquad.Count < 1)  { return; }

            _lastDownload = DateTime.UtcNow;

            // get list of users
            HttpResponseMessage response = null;
            string responseString = "";
            JArray availImages = null;
            try
            {
                response = await HttpClient.GetAsync(Config.ImageLocation);
                responseString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                availImages = (JArray)JsonConvert.DeserializeObject(responseString);
                if (availImages == null) { throw new Exception("Couldn't process json (availImages was null)."); }
            }
            catch (Exception exc)
            {
                string err = "Error downloading data from server.\n" +
                             "-------------------------\n" +
                             exc + "\n" +
                             (!string.IsNullOrWhiteSpace(responseString) ? "-------------------------\nServer response:\n" + responseString : "");
                
                Logger.LogError(err);
                return;
            }

            // get images for current squad
            foreach (var fort in CurrentSquad.ToList())
            {
                var match = availImages.FirstOrDefault(x => x["name"].ToString() == fort.Name + ".jpg");
                if (match == null) { continue; }

                DateTime lastMod = DateTime.Parse(match["mtime"].ToString().Substring(5)).ToUniversalTime();
                if (lastMod != fort.GearModified)
                {
                    string gearUrl = Config.ImageLocation.TrimEnd('/') + "/" + match["name"];
                    try
                    {
                        response = await HttpClient.GetAsync(gearUrl);
                        response.EnsureSuccessStatusCode();
                    }
                    catch (Exception exc)
                    {
                        string err = $"Error downloading gear image for {fort.Name}\n" +
                                     "-------------------------\n" +
                                     exc + "\n" +
                                     "-------------------------\n";
                        Logger.LogError(err);
                        continue;
                    }

                    var stream = await response.Content.ReadAsStreamAsync();

                    // squad could change while we're fetching gear, hence the ToList() and this
                    var ftn = CurrentSquad.FirstOrDefault(x => x.Name == fort.Name);
                    if (ftn != null)
                    {
                        ftn.GearImage = new Bitmap(stream);
                        ftn.GearModified = lastMod;
                        ftn.IsFaded = false;
                    }
                }
            }
        }

        private static void ShowOverlay()
        {
            var bounds = _procMon.WindowSize;
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                bounds = Screen.GetBounds(Point.Empty);
            }
            OverlayWindow.Location = new Point(bounds.Left, bounds.Top);
            OverlayWindow.Size = new System.Drawing.Size(bounds.Width, bounds.Height);
            OverlayWindow.Show();
        }

        private static void ShowDebugOverlay()
        {
            var bounds = _procMon.WindowSize;
            if (bounds.Width != _debugBuffer?.Width || bounds.Height != _debugBuffer?.Height)
            {
                _debugBuffer = new Bitmap(bounds.Width, bounds.Height);
            }
            ImageProcessing.RenderDebugMarkers(ref _debugBuffer, _pixelPositions);
            OverlayWindow.SetDebugOverlay(_debugBuffer);
        }

        public static void UpdateFormElements()
        {
            var gearFadeTargets = new List<FortnitePlayer>() { LocalPlayer }.Concat(CurrentSquad);
            foreach (var player in gearFadeTargets)
            {
                if (player == null)                                       { continue; }
                if (player.GearImage == null)                             { continue; }
                if (player.IsFaded)                                       { continue; }
                if (player.GearModified.AddSeconds(20) > DateTime.UtcNow) { continue; }

                player.GearImage = ImageProcessing.MarkStaleImage(player.GearImage);
                player.IsFaded   = true;
            }

            var activePlayers = CurrentSquad.Where(x => x.State != FortnitePlayer.ReadyState.SittingOut);
            for (int i = 0; i < 3; i++)
            {
                if (CurrentSquad.Count > i)
                {
                    OverlayWindow.SetSquadGear(i, CurrentSquad[i].IsFaded ? null : CurrentSquad[i].GearImage);
                    MainWindow.SetSquadGear(i, CurrentSquad[i].GearImage);
                    MainWindow.SetSquadName(i, CurrentSquad[i].Name);
                }
                else
                {
                    OverlayWindow.SetSquadGear(i, null);
                    MainWindow.SetSquadGear(i, null);
                    MainWindow.SetSquadName(i, "");
                }
            }

            MainWindow.SetSelfName(LocalPlayer?.Name);
            MainWindow.SetSelfGear(LocalPlayer?.GearImage);

            MainWindow.ShowHideSortButtons(CurrentSquad.Count);
        }
    }
}
