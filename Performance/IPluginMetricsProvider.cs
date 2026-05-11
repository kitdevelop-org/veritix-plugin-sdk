namespace Veritix.Plugin.SDK.Performance;

public record MetricValue(
    string Label, 
    string Value, 
    string? Trend = null, // "up", "down", "neutral"
    string? Color = null);

/// <summary>
/// Interfaz que permite a los plugins aportar métricas al Dashboard principal.
/// </summary>
public interface IPluginMetricsProvider
{
    /// <summary>
    /// Devuelve una lista de métricas clave para mostrar en el Dashboard.
    /// </summary>
    Task<IEnumerable<MetricValue>> GetMetricsAsync(Guid tenantId, CancellationToken ct = default);
}
