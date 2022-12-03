using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header level)<br/>
    /// <br/>
    /// The header is specified by the INVOICELIST_HEADER element.<br/>
    /// INVOICELIST_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level(INVOICELIST_ITEM).
    /// </summary>
    public class InvoiceListHeader
    {
        /// <summary>
        /// <inheritdoc cref="InvoiceListHeader"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InvoiceListHeader() { }

        /// <summary>
        /// <inheritdoc cref="InvoiceListHeader"/>
        /// </summary>
        /// <param name="information"></param>
        public InvoiceListHeader(InvoiceListInformation information)
        {
            Information = information ?? throw new System.ArgumentNullException(nameof(information));
        }

        /// <summary>
        /// (optional) Control information<br/>
        /// <br/>
        /// Control information for the automatic processing of the business documents.
        /// </summary>
        [XmlElement("CONTROL_INFO")]
        public ControlInformation? ControlInformation { get; set; }

        /// <summary>
        /// (required) Buyer information<br/>
        /// <br/>
        /// Order information on this business document.
        /// </summary>
        [XmlElement("INVOICELIST_INFO")]
        public InvoiceListInformation Information { get; set; } = new InvoiceListInformation();

    }
}
