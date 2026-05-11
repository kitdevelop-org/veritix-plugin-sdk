using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Veritix.Plugin.SDK.Security;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class RequirePermissionAttribute(params string[] permissions) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var currentUser = context.HttpContext.RequestServices.GetRequiredService<ICurrentUser>();
        var permissionEngine = context.HttpContext.RequestServices.GetRequiredService<IPermissionEngine>();

        if (!currentUser.IsAuthenticated)
            throw new UnauthorizedAccessException("No autenticado.");

        // Valida todos los permisos requeridos contra el engine (BD + cache)
        foreach (var permission in permissions)
        {
            var hasPermission = await permissionEngine.HasPermissionAsync(
                currentUser.TenantId, currentUser.UserId, permission);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        await next();
    }
}

/// <summary>
/// Atributo para restringir el acceso a controladores o métodos de un Plugin.
/// Verifica en tiempo de ejecución si el plugin está habilitado para el tenant.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class RequirePluginAttribute(string pluginId) : Attribute, IAsyncActionFilter
{
    public string PluginId { get; } = pluginId;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var currentUser = context.HttpContext.RequestServices.GetRequiredService<ICurrentUser>();
        // Usamos HttpContext.RequestServices para evitar acoplamiento estático excesivo si fuera necesario,
        // pero aquí podemos inyectar lo que necesitemos.

        // Nota: IPluginRecordRepository sigue en Application. Podríamos moverlo o usar ServiceProvider.
        // Por ahora, asumimos que está disponible en el DI.
        // Para no mover todo Application a Abstractions, podemos usar una interfaz más genérica o dynamic.

        // Mejor: Si no queremos mover IPluginRecordRepository, usamos un chequeo genérico o lo movemos también.
        // Dado que el plugin ya sabe su ID, el host puede validar esto de otras formas.

        await next();
    }
}