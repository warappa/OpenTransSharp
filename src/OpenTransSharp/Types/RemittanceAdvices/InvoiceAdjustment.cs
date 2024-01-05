namespace OpenTransSharp;

/// <summary>
/// (Invoice correction)<br/>
/// <br/>
/// Correction of an invoice within the scope of a remittance advice.
/// </summary>
public class InvoiceAdjustment
{
    /// <summary>
    /// <inheritdoc cref="InvoiceAdjustment"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public InvoiceAdjustment()
    {
        AdjustedInvoiceSummary = null!;
    }

    /// <summary>
    /// <inheritdoc cref="InvoiceAdjustment"/>
    /// </summary>
    /// <param name="adjustedInvoiceSummary"></param>
    public InvoiceAdjustment(AdjustedInvoiceSummary adjustedInvoiceSummary)
    {
        AdjustedInvoiceSummary = adjustedInvoiceSummary ?? throw new ArgumentNullException(nameof(adjustedInvoiceSummary));
    }

    /// <summary>
    /// (required) Adjusted invoice summary<br/>
    /// <br/>
    /// Total amount, net value and taxes of the revised invoice.<br/>
    /// </summary>
    [XmlElement("ADJUSTED_INVOICE_SUMMARY")]
    public AdjustedInvoiceSummary AdjustedInvoiceSummary { get; set; }

    /// <summary>
    /// (optional) Reason for adjustment<br/>
    /// <br/>
    /// Textual description for the reason of the adjustment.
    /// </summary>
    [XmlElement("ADJUSTMENT_REASON_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? ReasonDescriptions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ReasonDescriptionsSpecified => ReasonDescriptions?.Count > 0;

    /// <summary>
    /// (optional) Adjustment reason<br/>
    /// <br/>
    /// Coded reason for the adjustment.<br/>
    /// </summary>
    [XmlElement("ADJUSTMENT_REASON_CODE")]
    public string? ReasonCode { get; set; }
}
