namespace Veritix.Plugin.SDK.Frontend;

/// <summary>
/// El plugin implementa esto para declarar su micro-frontend.
/// El Shell React usa esta info para cargarlo dinámicamente.
/// </summary>
public interface IPluginFrontend
{
    string RemoteName { get; }        // "healthPlugin"
    string ExposedModule { get; }     // "./PluginApp"
    IReadOnlyList<string> Routes { get; }
    IReadOnlyList<PluginNavItem> NavItems { get; }
}

public class PluginNavItem
{
    public string Label { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public string? RequiredPermission { get; set; }
    public IReadOnlyList<PluginNavItem> Children { get; set; } = [];
}