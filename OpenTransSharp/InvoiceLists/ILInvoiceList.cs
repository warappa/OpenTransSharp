using System.Collections.Generic;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice list)<br/>
    /// <br/>
    /// List of every single invoices in a group of invoices.
    /// </summary>
    public class ILInvoiceList
    {
        /// <summary>
        /// (required) Invoice list item summary<br/>
        /// <br/>
        /// Summary and reference to a single invoice in a list of invoices.
        /// </summary>
        [XmlElement("IL_INVOICE_LIST_ITEM")]
        public List<ILInvoiceListItem> Items { get; set; } = new List<ILInvoiceListItem>();
    }
}
