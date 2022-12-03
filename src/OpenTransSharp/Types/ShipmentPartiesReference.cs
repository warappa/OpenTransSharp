using OpenTransSharp.Xml;
using System;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Shipment parties)<br/>
    /// <br/>
    /// Refers to business partners integrated in the process of the goods delivery procedure.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class ShipmentPartiesReference
    {
        /// <summary>
        /// <inheritdoc cref="ShipmentPartiesReference"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShipmentPartiesReference() { }

        /// <summary>
        /// <inheritdoc cref="ShipmentPartiesReference"/>
        /// </summary>
        /// <param name="deliveryIdRef"></param>
        public ShipmentPartiesReference(DeliveryIdRef deliveryIdRef)
        {
            DeliveryIdRef = deliveryIdRef ?? throw new ArgumentNullException(nameof(deliveryIdRef));
        }

        /// <summary>
        /// (required) Reference to final recipient<br/>
        /// <br/>
        /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [OpenTransXmlElement("DELIVERY_IDREF")]
        public DeliveryIdRef DeliveryIdRef { get; set; } = new DeliveryIdRef();

        /// <summary>
        /// (optional) Reference to a final recipient<br/>
        /// <br/>
        /// Reference to a unique identifier of the final recipient.<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [OpenTransXmlElement("FINAL_DELIVERY_IDREF")]
        public FinalDeliveryIdRef? FinalDeliveryIdRef { get; set; }

        /// <summary>
        /// (optional) Reference to a carrier<br/>
        /// <br/>
        /// Reference to an unique identifier of a carrier.<br/>
        /// This element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [OpenTransXmlElement("DELIVERER_IDREF")]
        public DelivererIdRef? DelivererIdRef { get; set; }
    }
}
