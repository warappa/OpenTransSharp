using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the ORDERCHANGE_HEADER element.<br/>
    /// ORDERCHANGE_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level(ORDERCHANGE_ITEM).
    /// </summary>
    public class OrderChangeHeader
    {
        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Order change information<br/>
        /// <br/>
        /// Order information on this business document.
        /// </summary>
        [XmlElement("ORDERCHANGE_INFO")]
        public OrderChangeInformation Information { get; set; } = new OrderChangeInformation();
    }
}
