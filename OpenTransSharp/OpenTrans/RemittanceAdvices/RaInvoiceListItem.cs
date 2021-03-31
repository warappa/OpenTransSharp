using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice summary)<br/>
    /// <br/>
    /// Summary (original and if applicable correction) and reference to an invoice of a group of invoices.
    /// </summary>
    public class RaInvoiceListItem
    {
        /// <summary>
        /// (required) Invoice reference<br/>
        /// <br/>
        /// Information according to the invoice reference.<br/>
        /// </summary>
        [XmlElement("INVOICE_REFERENCE")]
        public InvoiceReference InvoiceReference { get; set; }
        /// <summary>
        /// (required) Summary of the original invoice<br/>
        /// <br/>
        /// Summary of the original invoice.<br/>
        /// </summary>
        [XmlElement("ORIGINAL_INVOICE_SUMMARY")]
        public OriginalInvoiceSummary OriginalInvoiceSummary { get; set; }

        /// <summary>
        /// (optional) Invoice correction<br/>
        /// <br/>
        /// Correction of an invoice within the scope of a remittance advice.<br/>
        /// </summary>
        [XmlElement("INVOICE_ADJUSTMENT")]
        public InvoiceAdjustment? InvoiceAdjustment { get; set; }
    }
}
