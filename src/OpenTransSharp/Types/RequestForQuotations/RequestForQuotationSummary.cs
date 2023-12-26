using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Summary)<br/>
/// <br/>
/// The summary contains information about the number of item lines in the request for quotation.<br/>
/// This figure is used for control purposes to make sure that all items have been transferred.
/// </summary>
public class RequestForQuotationSummary
{
    /// <summary>
    /// <inheritdoc cref="RequestForQuotationSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RequestForQuotationSummary() { }

    /// <summary>
    /// <inheritdoc cref="RequestForQuotationSummary"/>
    /// </summary>
    /// <param name="totalItemCount"></param>
    public RequestForQuotationSummary(int totalItemCount)
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
