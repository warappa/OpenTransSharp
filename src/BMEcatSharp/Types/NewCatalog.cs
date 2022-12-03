using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
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
        /// <inheritdoc cref="NewCatalog"/>
        /// </summary>
        public NewCatalog() { }

        /// <summary>
        /// (optional - deprecated) No of previous updates<br/>
        /// <br/>
        /// "prev_version" should not be entered with this transaction; the option of doing so exists here only for reasons of compatibility with 1.01 and "prev_version" must be ignored here; see also "T_UPDATE_PRODUCTS -->prev_version" with T_UPDATE_PRODUCTS and "T_UPDATE_PRICES -->prev_version" with T_UPDATE_PRICES.<br/>
        /// <br/>
        /// See also Example (Interaction of various transactions).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        //[Obsolete("The option of doing so exists here only for reasons of compatibility with 1.01 and 'prev_version' must be ignored here.")]
        [XmlAttribute("prev_version")]
        public int PreviousVersion { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
        public bool PreviousVersionSpecified => PreviousVersion > 0;
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// (prohibited - deprecated) Feature group system<br/>
        /// <br/>
        /// This element was avaiable prior to BMEcat 2005.<br/>
        /// Because of its limitations in comparison to the CLASSIFICATION_SYSTEM element, it has been replaced fully by the revised CLASSIFICATION_SYSTEM element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        //[Obsolete("Because of its limitations in comparison to the CLASSIFICATION_SYSTEM element, it has been replaced fully by the revised CLASSIFICATION_SYSTEM element.")]
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
#pragma warning disable CS0618 // Type or member is obsolete
        public CatalogGroupSystem? CatalogGroupSystem { get; set; }
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// (optional) Dictionary of formulas<br/>
        /// <br/>
        /// List of formulas that are specified in the document header.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("FORMULAS")]
        [BMEXmlArrayItem("FORMULA")]
        public List<Formula>? Formulas { get; set; } = new List<Formula>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FormulasSpecified => Formulas?.Count > 0;

        /// <summary>
        /// (optional) IPP applications of the catalog<br/>
        /// <br/>
        /// IPP applications that are supported by the catalog.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("IPP_DEFINITIONS")]
        [BMEXmlArrayItem("IPP_DEFINITION")]
        public List<IppDefinition>? IppDefinitions { get; set; } = new List<IppDefinition>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IppDefinitionsSpecified => IppDefinitions?.Count > 0;

        /// <summary>
        /// (optional - choice Product/Article) Product<br/>
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
        /// (optional - deprecated - use with Product) Mapping to catalog group<br/>
        /// <br/>
        /// Mapping of the product to a group of a catalog group system Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.<br/>
        /// The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        //[Obsolete("Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.")]
        [BMEXmlElement("PRODUCT_TO_CATALOGGROUP_MAP")]
        public List<NewCatalogProductToCataloggroupMap>? ProductToCataloggroupMap { get; set; } = new List<NewCatalogProductToCataloggroupMap>();
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
        public bool ProductToCataloggroupMapSpecified => ProductToCataloggroupMap?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// (optional - deprecated - choice Product/Article) Article<br/>
        /// <br/>
        /// Information about a product.<br/>
        /// This element has been replaced by the PRODUCT in context T_NEW_CATALOG element.<br/>
        /// It still may be used in this BMEcat version, though it will become obsolete in the next version.<br/>
        /// The element ARTICLE in context T_NEW_CATALOG will be replaced by the element PRODUCT in context T_NEW_CATALOG in future versions and will be omitted then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        //[Obsolete("This element has been replaced by the PRODUCT in context T_NEW_CATALOG element.")]
        [BMEXmlElement("ARTICLE")]
        public List<NewCatalogArticle>? Articles { get; set; } = new List<NewCatalogArticle>();
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
        public bool ArticlesSpecified => Articles?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// (optional - deprecated - use with (deprecated) <see cref="Articles"/>) Assigning products to catalog groups<br/>
        /// <br/>
        /// This element is used to assign a product to a group of a catalog group system.<br/>
        /// This element has been replaced by the new PRODUCT_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG element.<br/>
        /// The element can still be used in the current BMEcat version, but it will be not available in the next version.<br/>
        /// Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element ARTICLE_TO_CATALOGGROUP_MAP in context T_NEW_CATALOG will be omitted then.The mapping of products to group is realized only with the element REFERENCE_FEATURE_GROUP_ID then.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        //[Obsolete("Catalog group systems will be transfered only with the element CLASSIFICATION_SYSTEM in future versions, therefore the element ARTICLE_TO_CATALOGGROUP_MAPin context T_NEW_CATALOG will be omitted then.")]
        [BMEXmlElement("Article_TO_CATALOGGROUP_MAP")]
        public List<NewCatalogArticleToCataloggroupMap>? ArticleToCataloggroupMap { get; set; } = new List<NewCatalogArticleToCataloggroupMap>();
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
        public bool ArticleToCataloggroupMapSpecified => ArticleToCataloggroupMap?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
