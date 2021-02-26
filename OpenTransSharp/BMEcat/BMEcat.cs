using OpenTransSharp.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Root element)<br/>
    /// <br/>
    /// Every valid catalog document in BMEcat format starts with the root element BMECAT and consists of a header part (HEADER) and a transaction part (T_NEW_CATALOG, T_UPDATE_PRODUCTS or T_UPDATE_PRICES).<br/>
    /// <br/>
    /// The header contains global data that is valid for all types of catalog data interchange, for example further details about the supplier or information concerning a skeleton agreement of the kind that sometimes exists between the buying firm and the supplier.<br/>
    /// <br/>
    /// The transaction part specifies which parts of the catalog (e.g., complete catalog, or price update) are to be transferred.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlRoot("BMECAT", Namespace = "http://www.bmecat.org/bmecat/2005")]
    [Serializable]
    public class BMEcat
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = SharedXmlNamespaces.Xmlns;

        /// <summary>
        /// (required) Version<br/>
        /// <br/>
        /// Specifies the version of the BMEcat standard to which the catalog document corresponds.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [XmlAttribute("version")]
        public BMEcatVersion Version { get; set; } = BMEcatVersion.v2005;


        /// <summary>
        /// (required) Header section<br/>
        /// <br/>
        /// In the header, information on the catalog and the catalog document are transferred, and default values are set.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("HEADER")]
        public BMEcatHeader Header { get; set; } = new BMEcatHeader();

        /// <summary>
        /// (required - choice) Transaction area 'new catalog'<br/>
        /// <br/>
        /// Transfer a of new catalog.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_NEW_CATALOG")]
        public NewCatalog? NewCatalog { get; set; }

        /// <summary>
        /// (required - choice) Transaction area 'product update'<br/>
        /// <br/>
        /// Updating of product data.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_UPDATE_PRODUCTS")]
        public UpdateProducts? UpdateProducts { get; set; }

        /// <summary>
        /// (required - choice) Transaction area 'price update'<br/>
        /// <br/>
        /// Updating of price information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_UPDATE_PRICES")]
        public UpdatePrices? UpdatePrices { get; set; }
    }

    public class UpdatePrices
    {
    }

    public class UpdateProducts
    {
    }
    /// <summary>
    /// (Transaction area 'new catalog')<br/>
    /// <br/>
    /// This transaction is used to transfer a new product catalog.<br/>
    /// Therefore all the elements specified in the BMEcat standard can be used (with the exception of T_UPDATE_PRODUCTS and T_UPDATE_PRICES).<br/>
    /// With the T_NEW_CATALOG transaction the target system reacts to the transferred data as follows depending on the CATALOG_ID, CATALOG_VERSION and LANGUAGE received:<br/>
    /// <br/>
    /// * Is the CATALOG_ID of the respective supplier (SUPPLIER_NAME) already present in the target system?<br/>
    /// - No<br/>
    /// -> A new catalog is created and all data imported.<br/>
    /// - Yes<br/>
    /// ** Is the CATALOG_VERSION in the target system identical?<br/>
    /// -- No<br/>
    /// --> A new version of the existing catalog is created and all data imported<br/>
    /// -- Yes<br/>
    /// *** Does the language exist in the target system?<br/>
    /// --- Yes<br/>
    /// ---> Acceptance of the catalog will be refused by the target system and a corresponding error message given.<br/>
    /// --- No<br/>
    /// ---> The new language will be added to the existing catalog and all language-specific data imported.<br/>
    /// <br/>
    /// When the T_NEW_CATALOG transaction is used, the CATALOG_VERSION new and the "T_NEW_CATALOG --&gt; prev_version" must be set to 0 at the next other transaction type(T_UPDATE_PRODUCTS, T_UPDATE_PRICES).<br/>
    /// See also: Example (combination of different transactions).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class NewCatalog
    {
        /// <summary>
        /// (optional - deprecated) No of previous updates<br/>
        /// <br/>
        /// "prev_version" should not be entered with this transaction; the option of doing so exists here only for reasons of compatibility with 1.01 and "prev_version" must be ignored here; see also "T_UPDATE_PRODUCTS -->prev_version" with T_UPDATE_PRODUCTS and "T_UPDATE_PRICES -->prev_version" with T_UPDATE_PRICES.<br/>
        /// <br/>
        /// See also Example (Interaction of various transactions).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("The option of doing so exists here only for reasons of compatibility with 1.01 and 'prev_version' must be ignored here.")]
        [XmlAttribute("prev_version")]
        public int? PreviousVersion { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PreviousVersionSpecified => PreviousVersion.HasValue;

        /// <summary>
        /// (prohibited - deprecated) Feature group system<br/>
        /// <br/>
        /// This element was avaiable prior to BMEcat 2005.<br/>
        /// Because of its limitations in comparison to the CLASSIFICATION_SYSTEM element, it has been replaced fully by the revised CLASSIFICATION_SYSTEM element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("Because of its limitations in comparison to the CLASSIFICATION_SYSTEM element, it has been replaced fully by the revised CLASSIFICATION_SYSTEM element.")]
        [XmlAnyElement("FEATURE_SYSTEM")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlElement[]? FeatureSystem { get; set; }

        /// <summary>
        /// (optional) Classification system<br/>
        /// <br/>
        /// This element defines a classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_SYSTEM")]
        public List<ClassificationSystem>? ClassificationSystem { get; set; } = new List<ClassificationSystem>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClassificationSystemSpecified => ClassificationSystem?.Count > 0;

        /// <summary>
        /// (optional) Catalog group system<br/>
        /// <br/>
        /// With the element CATALOG_GROUP_SYSTEM it is possible to built up a hierarchical group structure to which products kann be mapped.<br/>
        /// This makes finding the products much easier.<br/>
        /// Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element CATALOG_GROUP_SYSTEM will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CATALOG_GROUP_SYSTEM")]
        public CatalogGroupSystem? CatalogGroupSystem { get; set; }

        /// <summary>
        /// (optional) Dictionary of formulas<br/>
        /// <br/>
        /// List of formulas that are specified in the document header.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FORMULAS")]
        public Formulas? Formulas { get; set; }

        /// <summary>
        /// (optional) IPP applications of the catalog<br/>
        /// <br/>
        /// IPP applications that are supported by the catalog.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_DEFINITIONS")]
        public IppDefinitions? IppDefinitions { get; set; }

        /// <summary>
        /// (optional) Product<br/>
        /// <br/>
        /// Information about a product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT")]
        public List<NewCatalogProduct>? Products { get; set; } = new List<NewCatalogProduct>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductsSpecified => Products?.Count > 0;

        /// <summary>
        /// (optional - deprecated) Mapping to catalog group<br/>
        /// <br/>
        /// Mapping of the product to a group of a catalog group system Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.<br/>
        /// The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_TO_CATALOGGROUP_MAP")]
        public List<NewCatalogProductToCataloggroupMap>? ProductToCataloggroupMap { get; set; } = new List<NewCatalogProductToCataloggroupMap>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductToCataloggroupMapSpecified => ProductToCataloggroupMap?.Count > 0;

        /// <summary>
        /// (optional - deprecated) Product<br/>
        /// <br/>
        /// Information about a product.<br/>
        /// This element has been replaced by the PRODUCT in context T_NEW_CATALOG element.<br/>
        /// It still may be used in this BMEcat version, though it will become obsolete in the next version.<br/>
        /// The element ARTICLE in context T_NEW_CATALOG will be replaced by the element PRODUCT in context T_NEW_CATALOG in future versions and will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ARTICLE")]
        public List<NewCatalogArticle>? Articles { get; set; } = new List<NewCatalogArticle>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ArticlesSpecified => Articles?.Count > 0;

        /// <summary>
        /// (optional - deprecated) Assigning products to catalog groups<br/>
        /// <br/>
        /// This element is used to assign a product to a group of a catalog group system.<br/>
        /// This element has been replaced by the new PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG element.<br/>
        /// The element can still be used in the current BMEcat version, but it will be not available in the next version.<br/>
        /// Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element ARTICLE_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("Article_TO_CATALOGGROUP_MAP")]
        public List<NewCatalogArticleToCataloggroupMap>? ArticleToCataloggroupMap { get; set; } = new List<NewCatalogArticleToCataloggroupMap>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ArticleToCataloggroupMapSpecified => ArticleToCataloggroupMap?.Count > 0;
    }

    public class NewCatalogArticleToCataloggroupMap
    {
    }

    public class NewCatalogArticle
    {
    }
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
        /// <code>
        /// |--Mode--|----Error---|--------Recommendation--------|<br/>
        /// | update | Wrong mode  | Error, do not import product |<br/>
        /// | delete | Wrong mode  | Error, do not import product |<br/>
        /// |----------------------------------------------------|<br/>
        /// </code>
        /// <br/>
        /// Therefore, if the T_NEW_CATALOG transaction uses the transfer mode(PRODUCT -->mode in context T_NEW_CATALOG) 'delete' or 'update', the mode is wrong, and the product should not be imported at all.
        /// </summary>
        [XmlAttribute("mode")]
        public NewCatalogProductMode? Mode { get; set; }
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
        public ProductDetails ProductDetails { get; set; }

        /// <summary>
        /// (optional) Product features<br/>
        /// <br/>
        /// Description of the product by features and/or classification of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_FEATURES")]
        public ProductFeatures? ProductFeatures { get; set; }

        /// <summary>
        /// (required) Order details<br/>
        /// <br/>
        /// Order information and packaging policies of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("PRODUCT_ORDER_DETAILS")]
        public ProductOrderDetails ProductOrderDetails { get; set; }

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
        public List<ProductPriceDetails> ProductPriceDetails { get; set; } = new List<ProductPriceDetails>();

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For instance the sceleton agreement of the document could be added.
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

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
        public List<ProductReference>? ProductReferences { get; set; } = new List<ProductReference>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductReferencesSpecified => ProductReferences?.Count > 0;

        /// <summary>
        /// (optional) Product contacts<br/>
        /// <br/>
        /// List of contact person for the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_CONTACTS")]
        public ProductContacts? ProductContacts { get; set; }

        /// <summary>
        /// (optional) IPP details<br/>
        /// <br/>
        /// Product-specific information on IPP applications.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_IPP_DETAILS")]
        public ProductIppDetails? ProductIppDetails { get; set; }

        /// <summary>
        /// (optional) Logistics information<br/>
        /// <br/>
        /// Logistic information on the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_LOGISTIC_DETAILS")]
        public ProductLogisticDetails? ProductLogisticDetails { get; set; }

        /// <summary>
        /// (optional) Product configuration information<br/>
        /// <br/>
        /// Configuration information on the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_CONFIG_DETAILS")]
        public ProductConfigDetails? ProductConfigDetails { get; set; }
    }

    public class ProductConfigDetails
    {
    }

    public class ProductIppDetails
    {
    }

    public class ManufacturerPid
    {
    }

    public class SupplierAltPid
    {
    }

    public class IppDefinitions
    {
    }

    public class Formulas
    {
    }

    public class CatalogGroupSystem
    {
    }

    public class ClassificationSystem
    {
    }
}
