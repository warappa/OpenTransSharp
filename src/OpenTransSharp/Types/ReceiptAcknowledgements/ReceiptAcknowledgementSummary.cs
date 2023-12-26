using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Summary)<br/>
/// <br/>The summary contains information on the number of item lines in the receipt acknowledgement.<br/>
/// This figure is used for control purposes to make sure that all items have been transferred.
/// </summary>
public class ReceiptAcknowledgementSummary
{
    /// <summary>
    /// <inheritdoc cref="ReceiptAcknowledgementSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ReceiptAcknowledgementSummary() { }

    /// <summary>
    /// <inheritdoc cref="ReceiptAcknowledgementSummary"/>
    /// </summary>
    /// <param name="totalItemCount"></param>
    public ReceiptAcknowledgementSummary(int totalItemCount)
    {
        TotalItemCount = totalItemCount;
    }
    /// <summary>
    /// (required) Number of item lines<br/>
    /// <br/>
    /// Contains the total number of item lines in the business document.<br/>
    /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
    /// </summary>
    [XmlElement("TOTAL_ITEM_NUM")]
    public int TotalItemCount { get; set; }
}
