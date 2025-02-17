﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FortniteSquadOverlayClient
{
    internal static class MiscUtil
    {
        public static Regex uploadEndpointRegex = new Regex(@"^(https?://)?(.+\..+|localhost)(:\d+)?(\/.*)*\.php$", RegexOptions.Compiled);
        public static Regex imageLocationRegex = new Regex(@"^(https?://)?(.+\..+|localhost)(:\d+)?(\/.*)*\/$", RegexOptions.Compiled);

        private static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string configFolder = Path.Combine(localAppData, "FortniteOverlay");
        private static string fullConfigPath = Path.Combine(configFolder, "config.json");

        public static async Task<List<string>> GetOrder(HttpClient httpClient = null)
        {
            if (httpClient == null) { httpClient = new HttpClient(); }

            List<string> order = new List<string>();

            string url = "https://raw.githubusercontent.com/slinkstr/FortniteSquadOverlay/master/order-id.json";
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                var jarr = JArray.Parse(content);
                order = jarr.ToObject<List<string>>();
            }
            catch (Exception exc)
            {
                Program.Logger.LogError("Unable to get squad order. Error:\n" + exc.ToString());
            }
            Program.Logger.LogInfo($"Retrieved player order, {order.Count} entries.");

            return order;
        }

        public static int SortFortniters(FortnitePlayer first, FortnitePlayer second)
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

        public static int SettingsFullscreenMode()
        {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FortniteGame\\Saved\\Config\\WindowsClient";
            string configFile = "GameUserSettings.ini";
            if (!File.Exists(Path.Combine(configDir, configFile))) { return -1; }
            string configText = File.ReadAllText(Path.Combine(configDir, configFile));
            int index = configText.IndexOf("PreferredFullscreenMode=");
            if (index == -1) { return -1; }
            if (!int.TryParse(configText.Substring(index + 24, 1), out var mode))
            {
                return -1;
            }
            return mode;
        }

        // Don't know if it's possible to check if replays are enabled, GameUserSettings.ini doesn't have any options that mention "replay" or "demo"
        // Same with HUD scale...
        
        public static int MinMax(int min, int value, int max)
        {
            return Math.Min(Math.Max(min, value), max);
        }
        
        public static void OpenInDefaultBrowser(string url)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
            });
        }
    }
}
