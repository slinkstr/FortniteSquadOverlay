﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static FortniteOverlay.Util.ImageUtil;
using static FortniteOverlay.Util.LogReadUtil;
using static FortniteOverlay.Util.MiscUtil;

namespace FortniteOverlay
{
    internal static class Program
    {
        public static System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
        public static Form1 form;
        public static DateTime lastUp;
        public static DateTime lastDown;
        public static Dictionary<string, string> logRegex = new Dictionary<string, string>();
        public static string hostName;
        public static string hostId;
        public static bool inGame = false;
        public static List<Fortniter> fortniters = new List<Fortniter>();
        public static ProgramConfig config;
        public static HttpClient httpClient = new HttpClient();

        public static List<PixelPositions> pixelPositions = KnownPositions();

        [STAThread]
        static void Main()
        {
            if(!File.Exists("config.json"))
            {
                MessageBox.Show("No config.json found.", "FortniteOverlay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            var configText = string.Join("\n", File.ReadAllLines("config.json"));
            try { config = JsonConvert.DeserializeObject<ProgramConfig>(configText); }
            catch (Exception e)
            {
                MessageBox.Show("Error processing config.json:\n" + e.Message, "FortniteOverlay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            var curWidth = Screen.GetBounds(Point.Empty).Width;
            var curHeight = Screen.GetBounds(Point.Empty).Height;
            if (!pixelPositions.Any(x => x.Resolution[0] == curWidth && x.Resolution[1] == curHeight))
            {
                MessageBox.Show($"Screen resolution {Screen.GetBounds(Point.Empty).Size} not supported - program may not function as expected.", "FortniteOverlay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pixelPositions.Add(InterpolateResolution(pixelPositions.First(), curWidth, curHeight));
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();
            updateTimer.Tick += new EventHandler(UpdateEvent);
            updateTimer.Interval = 1000;
            updateTimer.Start();

            BackgroundWorker logReader = new BackgroundWorker();
            logReader.DoWork += new DoWorkEventHandler(ReadLogFile);
            logReader.RunWorkerAsync();

            Application.Run(form);
        }

        public static async void UpdateEvent(Object obj, EventArgs evtargs)
        {
            updateTimer.Stop();

            var tasks = new List<Task>();
            if (lastUp == null || lastUp.AddSeconds(form.GetUpFreq()) - DateTime.Now <= TimeSpan.FromSeconds(0.5))
            {
                tasks.Add(UploadGear());
            }

            if (lastDown == null || lastDown.AddSeconds(form.GetDownFreq()) - DateTime.Now <= TimeSpan.FromSeconds(0.5))
            {
                tasks.Add(DownloadGear());
            }

            foreach(var fort in fortniters)
            {
                if (fort.GearModified.AddSeconds(15) > DateTime.Now) { continue; }
                if (fort.GearImage == null)                          { continue; }
                if (fort.IsFaded)                                    { continue; }

                fort.GearImage = MarkStaleImage(fort.GearImage);
                fort.IsFaded = true;
            }

            await Task.WhenAll(tasks);

            updateTimer.Start();
        }

        public static async Task UploadGear()
        {
            if(!FortniteFocused()) { return; }
            var screen = TakeScreenshot();
            if (!IsMapVisible(screen, pixelPositions)) { return; }
            //form.Log($"Uploading gear...");
            var gearBitmap = RenderGear(screen, pixelPositions);

            var urlFriendlyName = StringToHex(hostName);
            var stream = new MemoryStream();
            gearBitmap.Save(stream, ImageFormat.Bmp);
            stream.Seek(0, SeekOrigin.Begin);
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(config.SecretKey), "secret");
            formData.Add(new StringContent(urlFriendlyName), "filename");
            formData.Add(new ByteArrayContent(stream.ToArray()), "gear", "image.png");
            HttpResponseMessage response = await httpClient.PostAsync(config.UploadEndpoint, formData);
            var responseString = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                form.Log("Error uploading image to server. " + responseString);
            }
            else
            {
                form.SetSelfGear(gearBitmap);
            }

            lastUp = DateTime.Now;
        }

        public static async Task DownloadGear()
        {
            if (!FortniteOpen())       { return; }
            if (!inGame)               { return; }
            if (fortniters.Count == 0) { return; }
            lastDown = DateTime.Now;
            //form.Log($"Downloading gear...");

            var response = await httpClient.GetAsync(config.ImageLocation);
            string jsonString = await response.Content.ReadAsStringAsync();
            JArray data = null;
            try
            {
                data = (JArray)JsonConvert.DeserializeObject(jsonString);
            }
            catch (Exception e)
            {
                form.Log("Error downloading data from server.\n" +
                    "-------------------------\n" +
                    e.ToString() + "\n" +
                    "-------------------------\n" +
                    "Server response:\n" + jsonString);
                return;
            }

            foreach (var fort in fortniters)
            {
                var match = data.FirstOrDefault(x => x["name"].ToString() == fort.NameEncoded + ".png");
                if (match == null) { continue; }

                DateTime lastMod = DateTime.Parse(match["mtime"].ToString().Substring(5));
                if (lastMod != fort.GearModified)
                {
                    //form.Log("Downloading gear for " + fort.Name);
                    string gearUrl = config.ImageLocation + "/" + fort.NameEncoded + ".png";
                    response = await httpClient.GetAsync(gearUrl);
                    var stream = await response.Content.ReadAsStreamAsync();
                    var test = await response.Content.ReadAsStringAsync();
                    fort.GearImage = new Bitmap(stream);
                    fort.GearModified = lastMod;
                    fort.IsFaded = false;
                }
            }

            fortniters = fortniters.OrderBy(x => x.Name).ToList();
            for (int i = 0; i < 3; i++)
            {
                if (fortniters.Count - 1 >= i)
                {
                    form.SetSquadGear(i, fortniters[i].GearImage);
                    form.SetSquadName(i, fortniters[i].Name);
                }
                else
                {
                    form.SetSquadGear(i, null);
                    form.SetSquadName(i, "");
                }
            }
        }
    }

    public class Fortniter
    {
        public string Name { get; set; }
        public string NameEncoded => StringToHex(Name);
        public Bitmap GearImage { get; set; }
        public DateTime GearModified { get; set; }
        public bool IsFaded { get; set; } = false;
    }

    public class ProgramConfig
    {
        public string UploadEndpoint { get; set; }
        public string SecretKey { get; set; }
        public string ImageLocation { get; set; }
    }
}
