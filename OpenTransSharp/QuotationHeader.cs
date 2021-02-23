using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the QUOTATION_HEADER element. QUOTATION_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (QUOTATION_ITEM).<br/>
    /// </summary>
    public class QuotationHeader
    {
        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Buyer's information<br/>
        /// <br/>
        /// Order information on this business document.
        /// </summary>
        [Required]
        [XmlElement("QUOTATION_INFO")]
        public QuotationInformation Information { get; set; } = new QuotationInformation();
    }
}
