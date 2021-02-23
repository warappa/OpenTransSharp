using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Business partners)<br/>
    /// <br/>
    /// Reference to the business partners integrated in the process of the document flow.
    /// </summary>
    public class OrderPartiesReference
    {
        /// <summary>
        /// (required) Reference to the buyer<br/>
        /// <br/>
        /// Reference to the buyer.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (PARTY element).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("BUYER_IDREF")]
        public BuyerIdref BuyerIdref { get; set; }

        /// <summary>
        /// (required) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document(element PARTY).
        /// </summary>
        [Required]
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [XmlElement("INVOICE_RECIPIENT_IDREF")]
        public InvoiceRecipientIdref? InvoiceRecipientIdref { get; set; }

        /// <summary>
        /// (optional) Shipment parties<br/>
        /// <br/>
        /// Refers to business partners integrated in the process of the goods delivery procedure.
        /// </summary>
        [XmlElement("SHIPMENT_PARTIES_REFERENCE")]
        public ShipmentPartiesReference? ShipmentPartiesReference { get; set; }
    }
}
