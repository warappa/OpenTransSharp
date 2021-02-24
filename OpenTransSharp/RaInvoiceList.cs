using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice list)<br/>
    /// <br/>
    /// List of all invoices in a group of invoices.
    /// </summary>
    public class RaInvoiceList
    {
        /// <summary>
        /// (required) Invoice summary<br/>
        /// <br/>
        /// Summary (original and if applicable correction) and reference to an invoice of a group of invoices.
        /// </summary>
        [Required]
        [XmlElement("RA_INVOICE_LIST_ITEM")]
        public List<RaInvoiceListItem> Items { get; set; }
    }
}
