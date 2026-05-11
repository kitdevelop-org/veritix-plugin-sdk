namespace Veritix.Plugin.SDK.Fiscal.Models;

public record FiscalInvoiceRequest(
    string CustomerId,
    string CustomerName,
    decimal TotalAmount,
    decimal TaxAmount,
    string InvoiceType, // "B01", "B02", etc.
    List<FiscalItem> Items);

public record FiscalItem(
    string SKU,
    string Description,
    int Quantity,
    decimal UnitPrice,
    decimal TaxRate);

public record FiscalResult(
    bool Success,
    string DocumentId, // NCF, CUFE, CFDI
    string? SecurityCode,
    string? QRData,
    string? ErrorMessage);
