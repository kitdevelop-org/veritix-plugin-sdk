using Veritix.Plugin.SDK.Fiscal.Models;

namespace Veritix.Plugin.SDK.Fiscal;

public interface IFiscalDocumentEngine
{
    string CountryCode { get; }
    Task<FiscalResult> IssueInvoiceAsync(Guid tenantId, FiscalInvoiceRequest request, CancellationToken ct = default);
}

public interface IFiscalDocumentEngineFactory
{
    IFiscalDocumentEngine GetEngine(string countryCode);
}
