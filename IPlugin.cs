using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veritix.Plugin.SDK.Database;
using Veritix.Plugin.SDK.Frontend;
using Veritix.Plugin.SDK.Licensing;

namespace Veritix.Plugin.SDK;

/// <summary>
/// Contrato principal que todo plugin de Veritix debe implementar.
/// </summary>
public interface IPlugin
{
    /// <summary>Identificador único del plugin. Ej: "Health", "Payroll", "CRM"</summary>
    string PluginId { get; }

    /// <summary>Nombre legible del plugin</summary>
    string DisplayName { get; }

    /// <summary>Versión semántica del plugin</summary>
    string Version { get; }

    /// <summary>Icono descriptivo del plugin (Lucide icon name)</summary>
    string? Icon { get; }

    /// <summary>Descripción del plugin</summary>
    string Description { get; }

    /// <summary>Autor o empresa que desarrolló el plugin</summary>
    string Author { get; }

    /// <summary>Módulos/permisos que este plugin requiere del core</summary>
    IReadOnlyList<string> RequiredPermissions { get; }

    /// <summary>Plugins de los que depende este plugin</summary>
    IReadOnlyList<string> Dependencies { get; }

    /// <summary>
    /// Workers/BackgroundServices que el plugin necesita registrar.
    /// Se registran junto con los demás servicios del plugin.
    /// </summary>
    IReadOnlyList<Type> BackgroundServices { get; }

    /// <summary>
    /// Migrador del schema de base de datos del plugin.
    /// Null si el plugin no necesita base de datos.
    /// </summary>
    IPluginMigrator? Migrator { get; }

    /// <summary>
    /// Declaración del micro-frontend del plugin.
    /// Null si el plugin no tiene UI.
    /// </summary>
    IPluginFrontend? Frontend { get; }

    /// <summary>
    /// Validador de licencia del plugin.
    /// Null si el plugin no requiere licencia propia.
    /// </summary>
    IPluginLicenseValidator? LicenseValidator { get; }

    /// <summary>Registra los servicios del plugin en el DI container</summary>
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);

    /// <summary>Mapea los endpoints HTTP del plugin</summary>
    void MapEndpoints(IApplicationBuilder app);

    /// <summary>Se ejecuta cuando el plugin es habilitado para un tenant</summary>
    Task OnEnabledAsync(Guid tenantId, CancellationToken ct = default);

    /// <summary>Se ejecuta cuando el plugin es deshabilitado para un tenant</summary>
    Task OnDisabledAsync(Guid tenantId, CancellationToken ct = default);

    /// <summary>Se ejecuta al instalar el plugin (crear tablas, seed data, etc.)</summary>
    Task OnInstalledAsync(Guid tenantId, CancellationToken ct = default);

    /// <summary>Se ejecuta al desinstalar el plugin (limpiar datos si aplica)</summary>
    Task OnUninstalledAsync(Guid tenantId, CancellationToken ct = default);
}