namespace Veritix.Plugin.SDK.Registry;

public class PermissionRegistry : IPermissionRegistry
{
    private readonly List<PluginPermission> _permissions = [];

    public void Register(string code, string description)
    {
        if (_permissions.Any(p => p.Code == code)) return;
        _permissions.Add(new PluginPermission { Code = code, Description = description });
    }

    public IReadOnlyList<PluginPermission> GetAll() => _permissions.AsReadOnly();
}