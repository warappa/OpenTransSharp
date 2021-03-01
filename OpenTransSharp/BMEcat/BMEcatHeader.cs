using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Header section)<br/>
    /// <br/>
    /// In the header, information on the catalog and the catalog document are transferred, and default values are set.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class BMEcatHeader
    {
        /// <summary>
        /// (optional) Generator information<br/>
        /// <br/>
        /// Information about the generator (manual or automatic) of the document.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("GENERATOR_INFO")]
        public string? GeneratorInformation { get; set; }

        /// <summary>
        /// (required) Catalog information<br/>
        /// <br/>
        /// Information on the identification and description of the catalog as well as its default values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CATALOG")]
        public Catalog Catalog { get; set; }

        /// <summary>
        /// (optional - optional choice: BuyerIdref/(deprecated)Buyer) Reference to the buyer<br/>
        /// <br/>
        /// Reference to the buyer.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (PARTY element ).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("BUYER_IDREF")]
        public BuyerIdref? BuyerIdref { get; set; }

        /// <summary>
        /// (optional - deprecated - optional choice: BuyerIdref/(deprecated)Buyer) Buyer information<br/>
        /// <br/>
        /// Information on the buyer.<br/>
        /// The element BUYER will be replaced by the element BUYER_IDREF together with the element PARTY in future versions and will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("The element BUYER will be replaced by the element BUYER_IDREF together with the element PARTY in future versions and will be omitted then.")]
        [BMEXmlElement("BUYER")]
        public Buyer? Buyer { get; set; }

        /// <summary>
        /// (optional - optional choice: Agreement/LegalInfo) Reference to a skeleton agreement<br/>
        /// <br/>
        /// Information on the skeleton agreement which serves as a basis for the validity of the business document.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AGREEMENT")]
        public List<Agreement>? Agreements { get; set; } = new List<Agreement>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementsSpecified => Agreements?.Count > 0;

        /// <summary>
        /// (optional - optional choice: Agreement/LegalInfo) Legal information<br/>
        /// <br/>
        /// Legal information for different areas or countries.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LEGAL_INFO")]
        public LegalInfo? LegalInfo { get; set; }

        /// <summary>
        /// (required - choice (deprecated)Supplier/SupplierIdref/DocumentCreatorIdref) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document(element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref SupplierIdref { get; set; }

        /// <summary>
        /// (required - choice (deprecated)Supplier/SupplierIdref/DocumentCreatorIdref) Supplier<br/>
        /// <br/>
        /// Information on the supplier.<br/>
        /// The element SUPPLIER will be replaced by the element SUPPLIER_IDREF together with the element PARTY in future versions and will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("The element SUPPLIER will be replaced by the element SUPPLIER_IDREF together with the element PARTY in future versions and will be omitted then.")]
        [BMEXmlElement("SUPPLIER_IDREF")]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// (required - choice (deprecated)Supplier/SupplierIdref/DocumentCreatorIdref) Document creator<br/>
        /// <br/>
        /// Reference to the document creator.<bre/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// This element should be used in multi-supplier catalogs, if it is not possible to name the supplier directly.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DOCUMENT_CREATOR_IDREF")]
        public DocumentCreatorIdref DocumentCreatorIdref { get; set; }

        /// <summary>
        /// (optional) Parties<br/>
        /// <br/>
        /// List of parties that are relevant to this business document.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("PARTIES")]
        [BMEXmlArrayItem("PARTY")]
        public List<Party> Parties { get; set; } = new List<Party>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PartiesSpecified => Parties?.Count > 0;

        /// <summary>
        /// (optional) Areas<br/>
        /// <br/>
        /// List of areas.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("AREAS")]
        [BMEXmlArrayItem("AREA")]
        public List<Area> Areas { get; set; } = new List<Area>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AreasSpecified => Areas?.Count > 0;

        /// <summary>
        /// (optional) User-defined extension<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-BMEcat-elements; hence it is possible to extend the pre-defined set of BMEcat-elements by user-defined ones.<br/>
        /// <br/>
        /// The usage of those elements results in BMEcat catalog documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
        /// The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// USER_DEFINED_EXTENSIONS are defined exclusively as optional fields.<br/>
        /// Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the BMEcat standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML Schema files.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("USER_DEFINED_EXTENSIONS")]
        public List<object>? UserDefinedExtensions { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UserDefinedExtensionsSpecified => UserDefinedExtensions?.Count > 0;
    }
}
