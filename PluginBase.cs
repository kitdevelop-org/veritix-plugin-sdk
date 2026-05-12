using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Veritix.Plugin.SDK.Database;
using Veritix.Plugin.SDK.Frontend;
using Veritix.Plugin.SDK.Licensing;

namespace Veritix.Plugin.SDK;

/// <summary>
/// Clase base para plugins de Veritix.
/// Implementa comportamiento por defecto para que el desarrollador
/// solo sobreescriba lo que necesita.
/// </summary>
public abstract class PluginBase : IPlugin
{
    public abstract string PluginId { get; }
    public abstract string DisplayName { get; }
    public abstract string Version { get; }
    public abstract string Description { get; }
    public abstract string Author { get; }

    public virtual IReadOnlyList<string> SupportedLocales => ["es-DO"]; // Default base

    public virtual string? Icon => "Box"; // Default icon

    public virtual IReadOnlyList<string> RequiredPermissions => [];
    public virtual IReadOnlyList<string> Dependencies => [];

    public virtual IReadOnlyList<Type> BackgroundServices => [];

    public virtual IPluginMigrator? Migrator => null;

    public virtual IPluginFrontend? Frontend => null;

    public virtual IPluginLicenseValidator? LicenseValidator => null;

    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }
    public virtual void MapEndpoints(IApplicationBuilder app) { }

    public virtual Task OnEnabledAsync(Guid tenantId, CancellationToken ct = default)
        => Task.CompletedTask;

    public virtual Task OnDisabledAsync(Guid tenantId, CancellationToken ct = default)
        => Task.CompletedTask;

    public virtual Task OnInstalledAsync(Guid tenantId, CancellationToken ct = default)
        => Task.CompletedTask;

    public virtual Task OnUninstalledAsync(Guid tenantId, CancellationToken ct = default)
        => Task.CompletedTask;
}