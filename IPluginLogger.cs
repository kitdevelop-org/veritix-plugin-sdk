namespace Veritix.Plugin.SDK;

public interface IPluginLogger
{
    void Debug(string message, params object?[] args);
    void Info(string message, params object?[] args);
    void Warning(string message, params object?[] args);
    void Error(Exception exception, string message, params object?[] args);
    void Critical(Exception exception, string message, params object?[] args);
}