using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Adjusted invoice summary)<br/>
/// <br/>
/// Total amount, net value and taxes of the revised invoice.
/// </summary>
public class AdjustedInvoiceSummary
{
    /// <summary>
    /// <inheritdoc cref="AdjustedInvoiceSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AdjustedInvoiceSummary() { }

    /// <summary>
    /// <inheritdoc cref="AdjustedInvoiceSummary"/>
    /// </summary>
    /// <param name="netValueGoods"></param>
    /// <param name="totalAmount"></param>
    public AdjustedInvoiceSummary(decimal netValueGoods, decimal totalAmount)
    {
        NetValueGoods = netValueGoods;
        TotalAmount = totalAmount;
    }

    /// <summary>
    /// (required) Net value <br/>
    /// <br/>
    /// Total amout of all items in this invoice excluding taxes.
    /// </summary>
    [XmlElement("NET_VALUE_GOODS")]
    public decimal NetValueGoods { get; set; }

    /// <summary>
    /// (optional) Total taxes <br/>
    /// <br/>
    /// List of the tax amount.
    /// </summary>
    [XmlElement("TOTAL_TAX")]
    public TotalTax? TotalTax { get; set; }

    /// <summary>
    /// (required) Total amount<br/>
    /// <br/>
    /// Total amount covering all items in this business document.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Changed definition:<br/>
    /// Gross price including surcharges, deductions and all taxes.<br/>
    /// Where no price per item can be given as the item level (e.g.bills of materials where explosion is not possible), the total price can be entered here.
    /// </summary>
    [XmlElement("TOTAL_AMOUNT")]
    public decimal TotalAmount { get; set; }
}
