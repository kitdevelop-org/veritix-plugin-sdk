namespace Veritix.Plugin.SDK;

public class PluginDependency
{
    public string PluginId { get; set; } = string.Empty;
    public string VersionRange { get; set; } = ">=1.0.0"; // Soporta: ">=1.0.0", "[1.0.0, 2.0.0)", etc.
}

public class PluginManifest
{
    public string PluginId { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string AssemblyName { get; set; } = string.Empty;
    public string EntryType { get; set; } = string.Empty;
    public string MinCoreVersion { get; set; } = "1.0.0";
    public List<PluginDependency> Dependencies { get; set; } = new();
    public IReadOnlyList<string> RequiredPermissions { get; set; } = [];
    public Dictionary<string, string> Metadata { get; set; } = [];

    // Frontend
    public string? RemoteName { get; set; }
    public string? ExposedModule { get; set; }
    public bool HasFrontend { get; set; }

    // Licenciamiento por plugin (estilo JetBrains)
    public bool RequiresLicense { get; set; }
    public string? LicenseValidatorType { get; set; }  // tipo que implementa IPluginLicenseValidator

    // Soporte y Ciclo de Vida
    public DateTime? DeprecatedAt { get; set; }
    public DateTime? SupportEndsAt { get; set; }
}
