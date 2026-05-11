namespace Veritix.Plugin.SDK.Database;

/// <summary>
/// El plugin implementa esto para gestionar sus propias migraciones.
/// El runtime llama a MigrateAsync cuando el plugin se instala o actualiza.
/// </summary>
public interface IPluginMigrator
{
    string PluginId { get; }
    
    string GetSchemaName(string? tenantPrefix = null);

    /// <summary>Crea o actualiza el schema del plugin para un tenant</summary>
    Task MigrateAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default);

    /// <summary>Elimina el schema del plugin para un tenant (al desinstalar)</summary>
    Task DropAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default);

    /// <summary>Verifica si el schema está actualizado</summary>
    Task<bool> IsUpToDateAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default);
}