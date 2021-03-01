using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Delivery date)<br/>
    /// <br/>
    /// Date of shipment. The delivery date specifies the date the commissioned goods are accepted by the buyer.<br/>
    /// If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
    /// <br/>
    /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class DeliveryDate
    {
        /// <summary>
        /// (optional) Type of delivery date<br/>
        /// <br/>
        /// Specifies the delivery date.
        /// </summary>
        [OpenTransXmlAttribute("type")]
        public DeliveryDateType Type { get; set; } = DeliveryDateType.Fixed;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeSpecified => Type != DeliveryDateType.Fixed;

        /// <summary>
        /// (required) Start of the delivery period<br/>
        /// <br/>
        /// Unique date for the start of the delivery period.<br/>
        /// If an exact delivery date has to be determined, e.g. in the RECEIPTACKNOWLEDGEMENT-document, DELIVERY_START_DATE = DELIVERY_END_DATE is set.
        /// </summary>
        [OpenTransXmlElement("DELIVERY_START_DATE")]
        public DateTime DeliveryStartDate { get; set; }

        /// <summary>
        /// (required) End of the delivery period<br/>
        /// <br/>
        /// Unique date for the end of the delivery period.<br/>
        /// If an exact delivery date has to be determined, e.g. in the RECEIPTACKNOWLEDGEMENT-document, DELIVERY_START_DATE = DELIVERY_END_DATE is set.
        /// </summary>
        [OpenTransXmlElement("DELIVERY_END_DATE")]
        public DateTime DeliveryEndDate { get; set; }
    }
}
