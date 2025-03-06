using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FortniteSquadOverlayClient
{
    internal static class MiscUtil
    {
        public static async Task<List<string>> GetOrder(HttpClient httpClient = null)
        {
            httpClient ??= new HttpClient();

            List<string> order = [];

            string url = "https://raw.githubusercontent.com/slinkstr/FortniteSquadOverlay/master/order-id.json";
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var jarr = JArray.Parse(content);
                order = jarr.ToObject<List<string>>();
            }
            catch (Exception exc)
            {
                Program.Logger.LogError("Unable to get squad order. Error:\n" + exc);
            }
            Program.Logger.LogInfo($"Retrieved player order, {order.Count} entries.");

            return order;
        }

        public static int SortFortnitePlayers(FortnitePlayer first, FortnitePlayer second)
        {
            if (first.Index == -1)
            {
                return 1;
            }
            else if (second.Index == -1)
            {
                return -1;
            }
            else
            {
                return first.Index.CompareTo(second.Index);
            }
        }

        // TODO: explore automatically setting config from settings
        // GameUserSettings.ini doesn't have anything for HUD scale or replay settings
        // ClientSettings.sav might but it's a binary file and the public editors I found are broken, also might require pulling the cloud settings?
        /* GameUserSettings.ini interesting vars
         *  bShowFPS=True
         *  ResolutionSizeX=2560
         *  ResolutionSizeY=1440
         *  DesiredScreenWidth=2560
         *  DesiredScreenHeight=1440
         *  bUseHDRDisplayOutput=False
         *  HDRDisplayOutputNits=1000
         */
        
        //public static int SettingsFullscreenMode()
        //{
        //    string configDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FortniteGame\\Saved\\Config\\WindowsClient";
        //    string configFile = "GameUserSettings.ini";
        //    if (!File.Exists(Path.Combine(configDir, configFile))) { return -1; }
        //    string configText = File.ReadAllText(Path.Combine(configDir, configFile));
        //    int index = configText.IndexOf("PreferredFullscreenMode=");
        //    if (index == -1) { return -1; }
        //    if (!int.TryParse(configText.Substring(index + 24, 1), out var mode))
        //    {
        //        return -1;
        //    }
        //    return mode;
        //}
        
        public static int MinMax(int min, int value, int max)
        {
            return Math.Min(Math.Max(min, value), max);
        }
        
        public static void OpenInDefaultBrowser(string url)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
            });
        }
    }
}
