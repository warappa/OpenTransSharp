using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Product)<br/>
    /// <br/>
    /// This element contains information about a product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class NewCatalogProduct
    {
        /// <summary>
        /// (optional) Transfer mode<br/>
        /// <br/>
        /// Determines how the transferred data should be processed by the target system (insert, update, delete);<br/>
        /// see also example(combination of different transactions)"<br/>
        /// <br/>
        /// If the transfer mode for the T_NEW_CATALOGtransaction is set in a not allowed way, the following procedure is recommended:<br/>
        /// <list type="table">
        ///     <listheader>
        ///         <term>Mode</term>
        ///         <term>Error</term>
        ///         <term>Recommendation</term>
        ///     </listheader>
        ///     <item>
        ///         <term>update</term>
        ///         <term>Wrong mode</term>
        ///         <term>Error, do not import product</term>
        ///     </item>
        ///     <item>
        ///         <term>delete</term>
        ///         <term>Wrong mode</term>
        ///         <term>Error, do not import product</term>
        ///     </item>
        /// </list>
        /// <br/>
        /// Therefore, if the T_NEW_CATALOG transaction uses the transfer mode(PRODUCT -->mode in context T_NEW_CATALOG) 'delete' or 'update', the mode is wrong, and the product should not be imported at all.
        /// </summary>
        [XmlAttribute("mode")]
        public NewCatalogProductMode Mode { get; set; } = NewCatalogProductMode.New;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ModeSpecified => Mode != NewCatalogProductMode.New;

        /// <summary>
        /// (required) Supplier's product ID<br/>
        /// <br/>
        /// This element contains the product number issued by the supplier.<br/>
        /// It is determining for ordering the product; it identifies the product in the supplier catalog.<br/>
        /// In multi-supplier catalogs, however, only the combination of SUPPLIER_PID and SUPPLIER_IDREF identifies a product.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Some target systems are not able to accept all 32 characters (e.g., SAP max. 18 characters).<br/>
        /// It is therefore advisable to keep product identifications as short as possible.<br/>
        /// <br/>
        /// Are there different product variants (VARIANTS) the final product number is built via the concatenation of the (base) product number (SUPPLIER_PID) with the related product numbers supplements (SUPPLIER_AID_SUPPLEMENT).<br/>
        /// <br/>
        /// Caution:<br/>
        /// The (base) product number has to be distinct on its own even when variants or configurations are used.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("SUPPLIER_PID")]
        public SupplierPid SupplierPid { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref? SupplierIdref { get; set; }

        /// <summary>
        /// (required) Product details<br/>
        /// <br/>
        /// Identification and description of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("PRODUCT_DETAILS")]
        public ProductDetails Details { get; set; }

        /// <summary>
        /// (optional) Product features<br/>
        /// <br/>
        /// Description of the product by features and/or classification of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_FEATURES")]
        public List<ProductFeatures>? Features { get; set; } = new List<ProductFeatures>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductFeaturesSpecified => Features?.Count > 0;

        /// <summary>
        /// (required) Order details<br/>
        /// <br/>
        /// Order information and packaging policies of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("PRODUCT_ORDER_DETAILS")]
        public ProductOrderDetails OrderDetails { get; set; }

        /// <summary>
        /// (required) Order details<br/>
        /// <br/>
        /// Price information for the product.<br/>
        /// In this context the lement is used to specify the price of a product.<br/>
        /// If the product is configurable the price is a base price which could be modified within the configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
        public List<ProductPriceDetails> PriceDetails { get; set; } = new List<ProductPriceDetails>();

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For instance the sceleton agreement of the document could be added.
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public BMEcatMimeInfo? MimeInfo { get; set; }

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

        /// <summary>
        /// (optional) Product reference<br/>
        /// <br/>
        /// Reference to another product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_REFERENCE")]
        public List<ProductReference>? References { get; set; } = new List<ProductReference>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReferencesSpecified => References?.Count > 0;

        /// <summary>
        /// (optional) Product contacts<br/>
        /// <br/>
        /// List of contact person for the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_CONTACTS")]
        public ProductContacts? Contacts { get; set; }

        /// <summary>
        /// (optional) IPP details<br/>
        /// <br/>
        /// Product-specific information on IPP applications.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_IPP_DETAILS")]
        public ProductIppDetails? IppDetails { get; set; }

        /// <summary>
        /// (optional) Logistics information<br/>
        /// <br/>
        /// Logistic information on the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_LOGISTIC_DETAILS")]
        public ProductLogisticDetails? LogisticDetails { get; set; }

        /// <summary>
        /// (optional) Product configuration information<br/>
        /// <br/>
        /// Configuration information on the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_CONFIG_DETAILS")]
        public ProductConfigurationDetails? ConfigDetails { get; set; }
    }
}
