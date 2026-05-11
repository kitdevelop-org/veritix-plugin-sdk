namespace Veritix.Plugin.SDK.Licensing;

/// <summary>
/// El plugin implementa esto si requiere su propia licencia.
/// Veritrix llama a ValidateAsync antes de habilitar el plugin.
/// </summary>
public interface IPluginLicenseValidator
{
    string PluginId { get; }

    /// <summary>
    /// Valida la licencia del plugin.
    /// La licencia puede ser validada localmente (RSA) o contra un servidor externo.
    /// </summary>
    Task<PluginLicenseResult> ValidateAsync(
        Guid tenantId,
        string licenseKey,
        CancellationToken ct = default);
}

public class PluginLicenseResult
{
    public bool IsValid { get; init; }
    public string? Reason { get; init; }
    public DateTime? ExpiresAt { get; init; }

    public static PluginLicenseResult Valid(DateTime? expiresAt = null) =>
        new() { IsValid = true, ExpiresAt = expiresAt };

    public static PluginLicenseResult Invalid(string reason) =>
        new() { IsValid = false, Reason = reason };
}