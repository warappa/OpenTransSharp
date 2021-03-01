using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Item line)<br/>
    /// <br/>
    /// The item line level contains information related to an invoice group bundeled in a summary.<br/>
    /// Any number of item lines is allowed but at least one item line must be used.
    /// </summary>
    public class RemittanceAdviceItem
    {
        /// <summary>
        /// (required) Item number<br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// <br/>
        /// Max length: 50
        /// </summary>
        [Required]
        [XmlElement("LINE_ITEM_ID")]
        public string LineItemId { get; set; }

        /// <summary>
        /// (optional) Reference to invoicing party<br/>
        /// <br/>
        /// Reference to an unique identifier of the invoicing party. The element refers to a PARTY_ID in the same document.<br/>
        /// </summary>
        [XmlElement("INVOICE_ISSUER_IDREF")]
        public InvoiceIssuerIdref? InvoiceIssuerIdref { get; set; }

        /// <summary>
        /// (optional) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [XmlElement("INVOICE_RECIPIENT_IDREF")]
        public InvoiceRecipientIdref? InvoiceRecipientIdref { get; set; }

        /// <summary>
        /// (required) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [Required]
        [XmlArray("RA_INVOICE_LIST")]
        [XmlArrayItem("RA_INVOICE_LIST_ITEM")]
        public List<RaInvoiceListItem> InvoiceList { get; set; } = new List<RaInvoiceListItem>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InvoiceListSpecified => InvoiceList?.Count > 0;

        /// <summary>
        /// (optional) Number of item lines<br/>
        /// <br/>
        /// Contains the total number of item lines in the business document.<br/>
        /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
        /// </summary>
        [XmlElement("TOTAL_ITEM_NUM")]
        public int? TotalItemCount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TotalItemCountSpecified => TotalItemCount.HasValue;

        /// <summary>
        /// (required) Number of item lines<br/>
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

        /// <summary>
        /// (optional) Aggregated original invoice total amounts<br/>
        /// <br/>
        /// Aggregated total amount of all original invoices to a remittee.
        /// </summary>
        [XmlElement("ORIGINAL_SUMMARY_AMOUNT")]
        public decimal? OriginalTotalAmount { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OriginalTotalAmountSpecified => OriginalTotalAmount.HasValue;

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// </summary>
        [XmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Remark<br/>
        /// <br/>
        /// Remark related to a business document.
        /// </summary>
        [XmlElement("REMARKS")]
        public List<Remark>? Remarks { get; set; } = new List<Remark>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemarksSpecified => Remarks?.Count > 0;

        /// <summary>
        /// (optional) User-defined extensions<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones.<br/>
        /// <br/>
        /// The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
        /// The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// Caution:<br/>
        /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// <br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML.
        /// </summary>
        [XmlArray("ITEM_UDX")]
        public List<object>? ItemUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ItemUdxSpecified => ItemUdx?.Count > 0;
    }
}
