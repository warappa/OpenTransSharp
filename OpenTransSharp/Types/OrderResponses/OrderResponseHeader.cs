using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the ORDERRESPONSE_HEADER element.<br/>
    /// ORDERRESPONSE_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (ORDERRESPONSE_ITEM).
    /// </summary>
    public class OrderResponseHeader
    {
        /// <summary>
        /// <inheritdoc cref="OrderResponseHeader"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OrderResponseHeader() { }

        /// <summary>
        /// <inheritdoc cref="OrderResponseHeader"/>
        /// </summary>
        /// <param name="information"></param>
        public OrderResponseHeader(OrderResponseInformation information)
        {
            Information = information ?? throw new ArgumentNullException(nameof(information));
        }
        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Information on the business document<br/>
        /// <br/>
        /// Order information on this business document
        /// </summary>
        [XmlElement("ORDERRESPONSE_INFO")]
        public OrderResponseInformation Information { get; set; } = new OrderResponseInformation();
    }
}
