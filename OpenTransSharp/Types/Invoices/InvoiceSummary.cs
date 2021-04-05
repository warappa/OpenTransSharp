using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Summary)<br/>
    /// <br/>
    /// The INVOICE_SUMMARY contains information on the number of item lines in the invoice as well as the total sum and taxes.
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// <inheritdoc cref="InvoiceSummary"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InvoiceSummary()
        { }

        /// <summary>
        /// <inheritdoc cref="InvoiceSummary"/>
        /// </summary>
        /// <param name="totalItemCount"></param>
        /// <param name="netValueGoods"></param>
        /// <param name="totalAmount"></param>
        public InvoiceSummary(int totalItemCount, decimal netValueGoods, decimal totalAmount)
        {
            TotalItemCount = totalItemCount;
            NetValueGoods = netValueGoods;
            TotalAmount = totalAmount;
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
        /// (optional) Net value <br/>
        /// <br/>
        /// Total amout of all items in this invoice excluding taxes.
        /// </summary>
        [XmlElement("NET_VALUE_EXTRA")]
        public decimal? NetValueExtra { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NetValueExtraSpecified => NetValueExtra.HasValue;

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
        /// (optional) Fixed allowance or surcharges<br/>
        /// <br/>
        /// A list of fixed allowances or surcharges which are to be applied on the price.
        /// </summary>
        [XmlElement("ALLOW_OR_CHARGES_FIX")]
        public AllowOrChargesFix? AllowOrChargesFix { get; set; }

        /// <summary>
        /// (optional) Total taxes <br/>
        /// <br/>
        /// List of the tax amount.
        /// </summary>
        [XmlElement("TOTAL_TAX")]
        public TotalTax? TotalTax { get; set; }
    }
}
