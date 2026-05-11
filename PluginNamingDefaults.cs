namespace Veritix.Plugin.SDK;

/// <summary>
/// Única fuente de verdad para las convenciones de nombres de la plataforma.
/// </summary>
public static class PluginNamingDefaults
{
    /// <summary>
    /// Genera el nombre del esquema siguiendo la máscara: t_{tenantId}_{pluginId}
    /// </summary>
    public static string GetSchemaName(string pluginId, string? tenantPrefix = null)
    {
        if (string.IsNullOrWhiteSpace(pluginId))
            throw new ArgumentException("El PluginId no puede estar vacío.", nameof(pluginId));

        // Limpieza de caracteres no deseados (máscara de seguridad)
        var safePluginId = pluginId.Trim().ToLowerInvariant()
            .Replace("veritix.plugin.", "") // Limpiamos prefijos comunes de namespace
            .Replace(".", "_")
            .Replace(" ", "_");

        return string.IsNullOrEmpty(tenantPrefix) 
            ? safePluginId 
            : $"{tenantPrefix.ToLowerInvariant()}_{safePluginId}";
    }
}