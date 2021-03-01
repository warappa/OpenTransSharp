using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice list item summary)<br/>
    /// <br/>
    /// Summary and reference to a single invoice in a list of invoices.
    /// </summary>
    public class ILInvoiceListItem
    {
        /// <summary>
        /// (required) Invoice reference<br/>
        /// <br/>
        /// Information according to the invoice reference.<br/>
        /// </summary>
        [XmlElement("INVOICE_REFERENCE")]
        public InvoiceReference InvoiceReference { get; set; }

        /// <summary>
        /// (optional) Foreign currency<br/>
        /// <br/>
        /// Provides a foreign currency.<brt/>
        /// When using this element the header element currency (CURRENCY) should be filled out to have a referenced standard-currency.
        /// </summary>
        [XmlElement("FOREIGN_CURRENCY")]
        public string? ForeignCurrency { get; set; }

        /// <summary>
        /// (optional) Amount of the currency referred to FOREIGN_CURRENCY.
        /// </summary>
        [XmlElement("FOREIGN_AMOUNT")]
        public decimal? ForeignAmount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ForeignAmountSpecified => ForeignAmount.HasValue;

        /// <summary>
        /// (optional) Exchange rate<br/>
        /// <br/>
        /// Exchange rate related to the foreign currency (FOREIGN_CURRENCY).
        /// </summary>
        [XmlElement("EXCHANGE_RATE")]
        public decimal? ExchangeRate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ExchangeRateSpecified => ExchangeRate.HasValue;

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
        /// (optional) Fixed allowance or surcharges<br/>
        /// <br/>
        /// A list of fixed allowances or surcharges which are to be applied on the price.
        /// </summary>
        [XmlElement("ALLOW_OR_CHARGES_FIX")]
        public AllowOrChargesFix AllowOrChargesFix { get; set; }

        /// <summary>
        /// (required) Total taxes <br/>
        /// <br/>
        /// List of the tax amount.
        /// </summary>
        [XmlElement("TOTAL_TAX")]
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
        [XmlElement("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// (optional) Rewards <br/>
        /// <br/>
        /// This element provides the possibilty to publish the rewards points which appeared with transactions.<br/>
        /// The element can be used directly for transactions in IL_INVOICE_LIST_ITEM and as summary in the element INVOICELIST_ITEM.
        /// </summary>
        [XmlElement("REWARDS")]
        public List<Rewards>? Rewards { get; set; } = new List<Rewards>();
    }
}
