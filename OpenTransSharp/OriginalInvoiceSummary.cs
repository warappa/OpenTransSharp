using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Summary of the original invoice)<br/>
    /// <br/>
    /// Summary of the original invoice.
    /// </summary>
    public class OriginalInvoiceSummary
    {
        /// <summary>
        /// (required) Net value <br/>
        /// <br/>
        /// Total amout of all items in this invoice excluding taxes.
        /// </summary>
        [Required]
        [XmlElement("NET_VALUE_GOODS")]
        public decimal NetValueGoods { get; set; }

        /// <summary>
        /// (required) Total taxes <br/>
        /// <br/>
        /// List of the tax amount.
        /// </summary>
        [Required]
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
        [Required]
        [XmlElement("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }
    }
}
