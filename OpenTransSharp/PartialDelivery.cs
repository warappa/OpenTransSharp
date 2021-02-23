using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Partial shipment)<br/>
    /// <br/>
    /// The element specifies the expected shipment date (DELIVERY_DATE) and the planned quantity (QUANTITY) according to an outstanding partial shipment.
    /// </summary>
    public class PartialDelivery
    {
        /// <summary>
        /// (required) Quantity<br/>
        /// <br/>
        /// Quantity.
        /// </summary>
        [Required]
        [XmlElement("QUANTITY")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// (optional) Delivery date<br/>
        /// <br/>
        /// Date of shipment.<br/>
        /// <br/>
        /// The delivery date specifies the date the commissioned goods are accepted by the buyer. If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
        /// <br/>
        /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.
        /// </summary>
        [XmlElement("DELIVERY_DATE")]
        public DeliveryDate? DeliveryDate { get; set; }
    }
}
