using OpenTransSharp.Xml;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Partial shipment)<br/>
    /// <br/>
    /// The element specifies the expected shipment date (DELIVERY_DATE) and the planned quantity (QUANTITY) according to an outstanding partial shipment.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class PartialDelivery
    {
        /// <summary>
        /// <inheritdoc cref="PartialDelivery"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PartialDelivery() { }

        /// <summary>
        /// <inheritdoc cref="PartialDelivery"/>
        /// </summary>
        /// <param name="quantity"></param>
        public PartialDelivery(decimal quantity)
        {
            Quantity = quantity;
        }

        /// <summary>
        /// (required) Quantity<br/>
        /// <br/>
        /// Quantity.
        /// </summary>
        [OpenTransXmlElement("QUANTITY")]
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
        [OpenTransXmlElement("DELIVERY_DATE")]
        public DeliveryDate? DeliveryDate { get; set; }
    }
}
