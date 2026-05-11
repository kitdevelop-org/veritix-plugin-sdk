using Microsoft.EntityFrameworkCore;

namespace Veritix.Plugin.SDK.Database;

/// <summary>
/// Base para migradores de plugins que usan EF Core.
/// El plugin hereda de esto y provee su DbContext.
/// </summary>
public abstract class PluginMigratorBase<TContext> : IPluginMigrator
    where TContext : DbContext, IPluginDbContext
{
    public abstract string PluginId { get; }
    
    // El plugin ya no define SchemaName libremente, se calcula por PluginId
    public string GetSchemaName(string? tenantPrefix = null) 
        => PluginNamingDefaults.GetSchemaName(PluginId, tenantPrefix);

    /// <summary>Crea el DbContext del plugin con la connection string dada</summary>
    protected abstract TContext CreateContext(string connectionString);

    public async Task MigrateAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default)
    {
        await using var context = CreateContext(connectionString);
        await context.Database.MigrateAsync(ct);
    }

    public async Task DropAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default)
    {
        await using var context = CreateContext(connectionString);
        var schema = GetSchemaName(tenantPrefix);

        // Elimina el schema completo del plugin
        await context.Database.ExecuteSqlRawAsync(
            $"DROP SCHEMA IF EXISTS {schema} CASCADE", ct);
    }

    public async Task<bool> IsUpToDateAsync(string connectionString, string? tenantPrefix = null, CancellationToken ct = default)
    {
        await using var context = CreateContext(connectionString);
        var pending = await context.Database.GetPendingMigrationsAsync(ct);
        return !pending.Any();
    }
}