namespace Veritix.Plugin.SDK.Fiscal.Events;

public record FiscalDocumentIssuedIntegrationEvent(
    Guid TenantId,
    string DocumentId,
    string CountryCode,
    decimal TotalAmount,
    DateTime IssuedAt);
