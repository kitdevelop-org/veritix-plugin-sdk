namespace Veritix.Plugin.SDK;

/// <summary>
/// Contexto que el ERP provee al plugin.
/// Es la única puerta de entrada a los servicios del core.
/// Los plugins NO pueden inyectar servicios del core directamente.
/// </summary>
public interface IPluginContext
{
    /// <summary>Tenant actual que está usando el plugin</summary>
    Guid TenantId { get; }

    /// <summary>ID del usuario actual</summary>
    Guid UserId { get; }

    /// <summary>Logger estructurado con contexto del plugin</summary>
    IPluginLogger Logger { get; }

    /// <summary>Acceso al cache del tenant</summary>
    IPluginCache Cache { get; }

    /// <summary>Publicador de eventos de dominio</summary>
    IPluginEventPublisher EventPublisher { get; }

    /// <summary>Verifica si el usuario tiene un permiso específico</summary>
    Task<bool> HasPermissionAsync(string permission, CancellationToken ct = default);

    /// <summary>
    /// Permite obtener un servicio registrado en el sistema.
    /// Útil para consumir contratos expuestos por otros plugins.
    /// </summary>
    T? GetService<T>() where T : class;
}