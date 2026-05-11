namespace Veritix.Plugin.SDK;

public interface IPluginEventPublisher
{
    Task PublishAsync<T>(T pluginEvent, CancellationToken ct = default) where T : class;
}