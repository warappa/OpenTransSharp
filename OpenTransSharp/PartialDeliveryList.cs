using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Partial shipment list)<br/>
    /// <br/>
    /// The element contains information related to items of outstanding partial shipments.<br/>
    /// Every partial shipment supposes a PARTIAL_DELIVERY element containing the expected delivery date (DELIVERY_DATE) and quantity (QUANTITY).<br/>
    /// <br/>
    /// Caution:<br/>
    /// The element is only allowed to be used if the element DELIVERY_COMPLETED specifies the value 'FALSE'.
    /// </summary>
    public class PartialDeliveryList
    {
        /// <summary>
        /// (required) Partial shipment<br/>
        /// <br/>
        /// Information to a partial shipment.
        /// </summary>
        [XmlElement("PARTIAL_DELIVERY")]
        public List<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();
    }
}
