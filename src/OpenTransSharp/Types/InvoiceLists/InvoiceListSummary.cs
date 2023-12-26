﻿namespace OpenTransSharp;

/// <summary>
/// (Summary)<br/>
/// <br/>
/// The summary contains information about the number of invoices and the total amount and taxes of all invoices in the invoice list.
/// </summary>
public class InvoiceListSummary
{
    /// <summary>
    /// <inheritdoc cref="InvoiceListSummary"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public InvoiceListSummary()
    { }

    /// <summary>
    /// <inheritdoc cref="InvoiceListSummary"/>
    /// </summary>
    /// <param name="totalItemCount"></param>
    /// <param name="netValueGoods"></param>
    /// <param name="totalAmount"></param>
    /// <param name="totalTax"></param>
    public InvoiceListSummary(int totalItemCount, decimal netValueGoods, decimal totalAmount, TotalTax totalTax)
    {
        TotalItemCount = totalItemCount;
        NetValueGoods = netValueGoods;
        TotalAmount = totalAmount;
        TotalTax = totalTax ?? throw new System.ArgumentNullException(nameof(totalTax));
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
    /// (required) Net value <br/>
    /// <br/>
    /// Total amout of all items in this invoice excluding taxes.
    /// </summary>
    [XmlElement("NET_VALUE_GOODS")]
    public decimal NetValueGoods { get; set; }

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

    /// <summary>
    /// (required) Total taxes <br/>
    /// <br/>
    /// List of the tax amount.
    /// </summary>
    [XmlElement("TOTAL_TAX")]
    public TotalTax TotalTax { get; set; } = new TotalTax();
}
