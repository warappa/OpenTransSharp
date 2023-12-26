using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Summary)<br/>
/// <br/>
/// Summary of the payment advice information like the number of item lines and the total amount.<br/>
/// Usually the information in this element is redundant.
/// </summary>
public class RemittanceAdviceSummary
{
    /// <summary>
    /// <inheritdoc cref="RemittanceAdviceSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RemittanceAdviceSummary() { }

    /// <summary>
    /// <inheritdoc cref="RemittanceAdviceSummary"/>
    /// </summary>
    /// <param name="totalItemCount"></param>
    /// <param name="originalSummaryAmount"></param>
    /// <param name="adjustedSummaryAmount"></param>
    public RemittanceAdviceSummary(int totalItemCount, decimal originalSummaryAmount, decimal adjustedSummaryAmount)
    {
        TotalItemCount = totalItemCount;
        OriginalSummaryAmount = originalSummaryAmount;
        AdjustedSummaryAmount = adjustedSummaryAmount;
    }

    /// <summary>
    /// (required) Number of item lines<br/>
    /// <br/>
    /// Contains the total number of item lines in the business document.<br/>
    /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
    /// </summary>
    [XmlElement("TOTAL_ITEM_NUM")]
    public int TotalItemCount { get; set; }

    /// <summary>
    /// (required) Aggregated original invoice total amounts<br/>
    /// <br/>
    /// Aggregated total amount of all original invoices to a remittee.
    /// </summary>
    [XmlElement("ORIGINAL_SUMMARY_AMOUNT")]
    public decimal OriginalSummaryAmount { get; set; }

    /// <summary>
    /// (required) Adjusted invoice total amount<br/>
    /// <br/>
    /// Sum of all single payment advices related to a remittee, that means it is the sum of all adjusted amounts.
    /// </summary>
    [XmlElement("ADJUSTED_SUMMARY_AMOUNT")]
    public decimal AdjustedSummaryAmount { get; set; }
}
