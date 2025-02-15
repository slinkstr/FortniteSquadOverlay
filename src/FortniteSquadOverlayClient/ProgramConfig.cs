using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FortniteSquadOverlayClient;

public abstract class ProgramConfig
{
    [JsonIgnore]
    public string ConfigDirectory { get; set; } = Directory.GetCurrentDirectory();
    [JsonIgnore]
    public string ConfigFilename { get; set; } = "config.json";
    [JsonIgnore]
    public string ConfigPath => Path.Combine(ConfigDirectory, ConfigFilename);

    public ProgramConfig() { }
    public ProgramConfig(string directory, string filename)
    {
        ConfigDirectory = directory;
        ConfigFilename = filename;
    }

    public bool Exists()
    {
        return File.Exists(ConfigPath);
    }
    
    public void Load(string filename = "")
    {
        if (string.IsNullOrWhiteSpace(filename)) { filename = ConfigFilename; }

        var cfgText = string.Join("\n", File.ReadAllText(ConfigPath));
        JsonConvert.PopulateObject(cfgText, this);
    }
    
    public void Save(string filename = "")
    {
        if (string.IsNullOrWhiteSpace(filename)) { filename = ConfigFilename; }

        var cfgText = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(ConfigPath, cfgText);
    }
    
    public void OpenFolder()
    {
        System.Diagnostics.Process.Start("explorer.exe", ConfigDirectory);
    }
}