﻿namespace OpenTransSharp;

/// <summary>
/// (Summary of the original invoice)<br/>
/// <br/>
/// Summary of the original invoice.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class OriginalInvoiceSummary
{
    /// <summary>
    /// <inheritdoc cref="OriginalInvoiceSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OriginalInvoiceSummary()
    {
        TotalTax = null!;
    }

    /// <summary>
    /// <inheritdoc cref="OriginalInvoiceSummary"/>
    /// </summary>
    /// <param name="netValueGoods"></param>
    /// <param name="totalTax"></param>
    /// <param name="totalAmount"></param>
    public OriginalInvoiceSummary(decimal netValueGoods, TotalTax totalTax, decimal totalAmount)
    {
        NetValueGoods = netValueGoods;
        TotalTax = totalTax ?? throw new System.ArgumentNullException(nameof(totalTax));
        TotalAmount = totalAmount;
    }

    /// <summary>
    /// (required) Net value <br/>
    /// <br/>
    /// Total amout of all items in this invoice excluding taxes.
    /// </summary>
    [OpenTransXmlElement("NET_VALUE_GOODS")]
    public decimal NetValueGoods { get; set; }

    /// <summary>
    /// (required) Total taxes <br/>
    /// <br/>
    /// List of the tax amount.
    /// </summary>
    [OpenTransXmlElement("TOTAL_TAX")]
    public TotalTax TotalTax { get; set; }

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
    [OpenTransXmlElement("TOTAL_AMOUNT")]
    public decimal TotalAmount { get; set; }
}
