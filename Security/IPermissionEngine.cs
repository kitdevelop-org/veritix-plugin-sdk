namespace Veritix.Plugin.SDK.Security;

public interface IPermissionEngine
{
    Task<bool> HasPermissionAsync(Guid tenantId, Guid userId, string permission, CancellationToken ct = default);
    Task<bool> HasRoleAsync(Guid tenantId, Guid userId, string role, CancellationToken ct = default);
    Task<IReadOnlyList<string>> GetPermissionsAsync(Guid tenantId, Guid userId, CancellationToken ct = default);
    Task<IReadOnlyList<string>> GetRolesAsync(Guid tenantId, Guid userId, CancellationToken ct = default);
    Task InvalidateUserPermissionsAsync(Guid tenantId, Guid userId, CancellationToken ct = default);
    Task InvalidateTenantPermissionsAsync(Guid tenantId, CancellationToken ct = default);
}