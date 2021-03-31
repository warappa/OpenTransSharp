using OpenTransSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Sourcing information)<br/>
    /// <br/>
    /// The element SOURCING_INFO summarizes information about acquisition activities which have preceded this order.<br/>
    /// If the element SOURCING_INFO is used, at least one of the following elements has to be given.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class SourcingInformation
    {
        /// <summary>
        /// (optional) Supplier quotation number<br/>
        /// <br/>
        /// Unique quotation number allocated by the supplier.
        /// </summary>
        [OpenTransXmlElement("QUOTATION_ID")]
        public string? QuotationId { get; set; }

        /// <summary>
        /// (optional) Reference to a skeleton agreement<br/>
        /// <br/>
        /// Information on the skeleton agreement which serves as a basis for the validity of the business document.
        /// </summary>
        [OpenTransXmlElement("AGREEMENT")]
        public List<OpenTransAgreement>? Agreements { get; set; } = new List<OpenTransAgreement>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementsSpecified => Agreements?.Count > 0;

        /// <summary>
        /// (optional) Reference to an (electronic) product catalog<br/>
        /// <br/>
        /// Order reference to a catalog. This element can also be used as a reference to a price list.
        /// </summary>
        [OpenTransXmlElement("CATALOG_REFERENCE")]
        public CatalogReference? CatalogReference { get; set; }
    }
}
