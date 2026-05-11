namespace Veritix.Plugin.SDK.Database;

/// <summary>
/// Contrato base para los DbContext de los plugins.
/// </summary>
public interface IPluginDbContext
{
    string PluginId { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}