using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FortniteSquadOverlayClient;

public class Logger
{
    private string _logFilePath;
    private StringBuilder _builder = new();
    
    public LogSeverity LogLevel { get; set; } = LogSeverity.Info;
    
    public Logger(string logFilePath)
    {
        _logFilePath = logFilePath;
        File.WriteAllText(_logFilePath, string.Empty);
        _ = LogToFileLoop();
    }
    
    public void Log(LogSeverity severity, string message)
    {
        if (severity > LogLevel) { return; }
        
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss zz}] [{severity}] {message}";
        
        _builder.AppendLine(logMessage);
        Console.WriteLine(logMessage);
        Program.MainWindow.Log(logMessage);
    }
    
    public void LogCritical(string message) => Log(LogSeverity.Critical, message);
    public void LogWarning (string message) => Log(LogSeverity.Warning , message);
    public void LogError   (string message) => Log(LogSeverity.Error   , message);
    public void LogInfo    (string message) => Log(LogSeverity.Info    , message);
    public void LogVerbose (string message) => Log(LogSeverity.Verbose , message);
    public void LogDebug   (string message) => Log(LogSeverity.Debug   , message);
    
    public enum LogSeverity
    {
        Critical = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        Verbose = 4,
        Debug = 5,
    }
    
    public void Flush()
    {
        if(_builder.Length == 0) { return; }
        File.AppendAllText(_logFilePath, _builder.ToString());
        _builder.Clear();
    }
    
    private async Task LogToFileLoop()
    {
        while(true)
        {
            await Task.Delay(1000);
            
            if(_builder.Length == 0) { continue; }
            await File.AppendAllTextAsync(_logFilePath, _builder.ToString());
            _builder.Clear();
        }
    }
}