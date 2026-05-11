namespace Veritix.Plugin.SDK.Security;

public interface ICurrentUser
{
    Guid UserId { get; }
    string Email { get; }
    string FullName { get; }
    string KeycloakUserId { get; }
    Guid TenantId { get; }
    IReadOnlyList<string> Roles { get; }
    IReadOnlyList<string> Permissions { get; }
    bool IsAuthenticated { get; }
    bool HasRole(string role);
    bool HasPermission(string permission);
}