using OpenTransSharp.Xml;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the ORDER_HEADER element.<br/>
    /// ORDER_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (ORDER_ITEM).<br/>
    /// <br/>
    /// Caution:<br/>
    /// The exception for overwriting at the level (ORDER_ITEM) is the element PARTIAL_SHIPMENT_ALLOWED.<br/>
    /// In this case, the value in the header overwrites the value at the item level (ORDER_ITEM).
    /// </summary>
    public class OrderHeader
    {
        /// <summary>
        /// <inheritdoc cref="OrderHeader"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OrderHeader() { }

        /// <summary>
        /// <inheritdoc cref="OrderHeader"/>
        /// </summary>
        /// <param name="information"></param>
        public OrderHeader(OrderInformation information)
        {
            Information = information ?? throw new System.ArgumentNullException(nameof(information));
        }

        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [OpenTransXmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (optional) Sourcing information<br/>
        /// <br/>
        /// Information about previous quotations, catalog references, skeleton agreements.
        /// </summary>
        [OpenTransXmlElement("SOURCING_INFO")]
        public SourcingInformation? SourcingInformation { get; set; }

        /// <summary>
        /// (required) Buyer information<br/>
        /// <br/>
        /// Order information on this business document.
        /// </summary>
        [OpenTransXmlElement("ORDER_INFO")]
        public OrderInformation Information { get; set; } = new OrderInformation();
    }
}
