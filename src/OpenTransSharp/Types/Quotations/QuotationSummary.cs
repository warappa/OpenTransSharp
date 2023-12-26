using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Summary)<br/>
/// <br/>
/// The header is specified by the QUOTATION_HEADER element.<br/>
/// QUOTATION_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (QUOTATION).
/// </summary>
public class QuotationSummary
{
    /// <summary>
    /// <inheritdoc cref="QuotationSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public QuotationSummary() { }

    /// <summary>
    /// <inheritdoc cref="QuotationSummary"/>
    /// </summary>
    /// <param name="totalItemCount"></param>
    public QuotationSummary(int totalItemCount)
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

    /// <summary>
    /// (optional) Total amount<br/>
    /// <br/>
    /// Total amount covering all items in this business document.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Changed definition:<br/>
    /// Gross price including surcharges, deductions and all taxes.<br/>
    /// Where no price per item can be given as the item level (e.g.bills of materials where explosion is not possible), the total price can be entered here.
    /// </summary>
    [XmlElement("TOTAL_AMOUNT")]
    public decimal? TotalAmount { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TotalAmountSpecified => TotalAmount.HasValue;
}
