using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FortniteSquadOverlayClient;

public class Updater(string releaseEndpoint, string installerFileName, HttpClient httpClient)
{
    private string? _latestVersion;
    private string? _latestInstallUrl;
    
    private HttpClient _httpClient = httpClient;

    public async Task<bool> CheckForUpdate()
    {
        var response = await _httpClient.GetAsync(releaseEndpoint);
        response.EnsureSuccessStatusCode();
        
        var content  = await response.Content.ReadAsStringAsync();
        var jObj    = JObject.Parse(content);
        _latestVersion     = jObj["tag_name"]?.ToString() ?? throw new Exception("Couldn't find tag_name in update response.");
        var latestVersion  = Version.Parse(_latestVersion.Substring(1));
        var currentVersion = Version.Parse(CurrentVersion());

        if (latestVersion.CompareTo(currentVersion) <= 0) { return false; }
        var assets = jObj["assets"] ?? throw new Exception("Couldn't find assets in update response.");
        foreach (var asset in assets)
        {
            if (asset["name"]                 == null)              { continue; }
            if (asset["browser_download_url"] == null)              { continue; }
            if (asset["name"].ToString()      != installerFileName) { continue; }
            _latestInstallUrl = asset["browser_download_url"].ToString();
            break;
        }

        if (_latestInstallUrl == null)
        {
            throw new Exception("Unable to find installer in latest release.");
        }

        return true;
    }

    public bool CanUpdate()
    {
        return _latestInstallUrl != null;
    }

    public async Task Update()
    {
        if (!CanUpdate()) { return; }

        string tempPath = Path.Combine(Path.GetTempPath(), installerFileName);
        var response = await _httpClient.GetAsync(_latestInstallUrl);
        using (Stream respStream = await response.Content.ReadAsStreamAsync())
        {
            using (FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                fs.SetLength(0);
                await respStream.CopyToAsync(fs);
            }
        }
        
        Process.Start(new ProcessStartInfo()
        {
            FileName = tempPath,
            Arguments = "/silent",
        });
        Environment.Exit(0);
    }

    public string CurrentVersion()
    {
        var ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        if (ver == null) { throw new Exception("Unable to get assembly version."); }
        return $"{ver.Major}.{ver.Minor}.{ver.Build}";
    }
    
    public string LatestVersion() 
    {
        if (String.IsNullOrWhiteSpace(_latestVersion))
        {
            return CurrentVersion();
        }
        
        return _latestVersion;
    }
}