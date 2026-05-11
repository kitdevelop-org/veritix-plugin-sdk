namespace Veritix.Plugin.SDK;

public interface IPluginNotificationService
{
    Task NotifyPluginReloadedAsync(string pluginId, string version);
}
