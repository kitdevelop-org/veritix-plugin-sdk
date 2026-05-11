namespace Veritix.Plugin.SDK.Performance;

public interface IAlertService
{
    Task NotifyAlertAsync(Guid tenantId, string key, string severity, string message);
}
