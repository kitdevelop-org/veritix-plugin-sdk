using Veritix.Plugin.SDK.Performance;

namespace Veritix.Plugin.SDK.Performance;

public interface IVtxMetricsService
{
    /// <summary>
    /// Registra una métrica en el historial para análisis BI y evalúa triggers de alertas.
    /// </summary>
    Task RecordAsync(string pluginId, string key, double value, Dictionary<string, string>? dimensions = null);
    
    /// <summary>
    /// Crea un trigger de alerta personalizado.
    /// </summary>
    Task CreateTriggerAsync(Guid tenantId, string key, string op, double threshold, string severity);
}
