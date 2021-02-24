using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the RECEIPTACKNOWLEDGEMENT_HEADER element.<br/>
    /// RECEIPTACKNOWLEDGEMENT_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (RECEIPTACKNOWLEDGEMENT).
    /// </summary>
    public class ReceiptAcknowledgementHeader
    {
        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Dispatch notification information<br/>
        /// <br/>
        /// Information on the business partners and for identification of the business document.
        /// </summary>
        [Required]
        [XmlElement("RECEIPTACKNOWLEDGEMENT_INFO")]
        public ReceiptAcknowledgementInformation Information { get; set; } = new ReceiptAcknowledgementInformation();
    }
}
