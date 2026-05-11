namespace Veritix.Plugin.SDK.Performance;

/// <summary>
/// Representa una acción rastreable realizada por un operario en el sistema.
/// Permite medir KPI de productividad y tiempos de respuesta.
/// </summary>
public class OperationalAction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty; // "Cashier", "Chef", "Picker"

    public string ActionType { get; set; } = string.Empty; // "OrderTaken", "PreparationStarted", "Dispatched"
    public string ReferenceId { get; set; } = string.Empty; // ID del Pedido/Factura
    
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public double? DurationInMinutes { get; set; } // Tiempo transcurrido desde el paso anterior
}

public interface IPerformanceTracker
{
    Task TrackActionAsync(OperationalAction action, CancellationToken ct = default);
}
