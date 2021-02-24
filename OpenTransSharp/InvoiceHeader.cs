using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    public class InvoiceHeader
    {
        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Invoice information<br/>
        /// <br/>
        /// Invoice information on the business document.
        /// </summary>
        [Required]
        [XmlElement("INVOICE_INFO")]
        public InvoiceInformation Information { get; set; } = new InvoiceInformation();

        /// <summary>
        /// (required) Order history<br/>
        /// <br/>
        /// Information on previous orders, catalog references, skeleton agreements.
        /// </summary>
        [Required]
        [XmlElement("ORDER_HISTORY")]
        public OrderHistory OrderHistory { get; set; } = new OrderHistory();
    }
}
