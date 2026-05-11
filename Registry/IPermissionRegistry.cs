namespace Veritix.Plugin.SDK.Registry;

public interface IPermissionRegistry
{
    void Register(string code, string description);
    IReadOnlyList<PluginPermission> GetAll();
}

public class PluginPermission
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}