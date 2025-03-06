using System;

namespace FortniteSquadOverlayClient;

public class Config(string directory, string filename) : ProgramConfig(directory, filename)
{
    private string _secretKey = "SECRET_KEY_HERE";
    public string SecretKey
    {
        get => _secretKey;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(nameof(SecretKey) + " cannot be blank."); }
            _secretKey = value;
        }
    }

    private string _uploadEndpoint = "https://example.com/fortnitegear/upload.php";
    public string UploadEndpoint
    {
        get => _uploadEndpoint;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(nameof(UploadEndpoint) + " cannot be blank."); }
            if (!IsValidHttpUrl(value))           { throw new ArgumentException(nameof(UploadEndpoint) + " not a valid URL."); }
            _uploadEndpoint = value;
        }
    }

    private string _imageLocation = "https://example.com/fortnitegear/images/";
    public string ImageLocation
    {
        get => _imageLocation;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(nameof(ImageLocation) + " cannot be blank."); }
            if (!IsValidHttpUrl(value))           { throw new ArgumentException(nameof(ImageLocation) + " not a valid URL."); }
            _imageLocation = value;
        }
    }

    private int _uploadInterval = 5;
    public int UploadInterval
    {
        get => _uploadInterval;
        set
        {
            if (value < 1) { throw new ArgumentException(nameof(UploadInterval) + " must be positive."); }
            _uploadInterval = value;
        }
    }

    private int _downloadInterval = 5;
    public int DownloadInterval
    {
        get => _downloadInterval;
        set
        {
            if (value < 1) { throw new ArgumentException(nameof(DownloadInterval) + " must be positive."); }
            _downloadInterval = value;
        }
    }

    private int _hudScale = 100;
    public int HudScale
    {
        get => _hudScale;
        set
        {
            if (value is < 25 or > 150) { throw new ArgumentException(nameof(HudScale) + " must be between 25 and 150 inclusive."); }
            _hudScale = value;
        }
    }

    private int _overlayOpacity = 85;
    public int OverlayOpacity
    {
        get => _overlayOpacity;
        set
        {
            if (value is < 0 or > 100) { throw new ArgumentException(nameof(OverlayOpacity) + " must be between 0 and 100 inclusive."); }
            _overlayOpacity = value;
        }
    }
    
    public bool ShowConsole    { get; set; } = true;
    public bool EnableOverlay  { get; set; } = true;
    public bool MinimizeToTray { get; set; } = true;
    public bool StartMinimized { get; set; } = false;
    public bool AlwaysOnTop    { get; set; } = false;

    public Config(Config oldConfig) : this(oldConfig.ConfigDirectory, oldConfig.ConfigFilename) { }
    
    private static bool IsValidHttpUrl(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)) { return false; }
        return uri.Scheme is "http" or "https";
    }
}