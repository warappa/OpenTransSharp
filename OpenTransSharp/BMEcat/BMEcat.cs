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
    public class BMEcat : IValidatable
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = SharedXmlNamespaces.XmlnsBMEcat;

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
        /// (required - choice NewCatalog/UpdateProducts/UpdatePrices) Transaction area 'new catalog'<br/>
        /// <br/>
        /// Transfer a of new catalog.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_NEW_CATALOG")]
        public NewCatalog? NewCatalog { get; set; }

        /// <summary>
        /// (required - choice NewCatalog/UpdateProducts/UpdatePrices) Transaction area 'product update'<br/>
        /// <br/>
        /// Updating of product data.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_UPDATE_PRODUCTS")]
        public UpdateProducts? UpdateProducts { get; set; }

        /// <summary>
        /// (required - choice NewCatalog/UpdateProducts/UpdatePrices) Transaction area 'price update'<br/>
        /// <br/>
        /// Updating of price information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("T_UPDATE_PRICES")]
        public UpdatePrices? UpdatePrices { get; set; }
    }
    /// <summary>
    /// (Catalog group system - deprecated)<br/>
    /// <br/>
    /// The purpose of a catalog group system is to structure a set of products hierarchically (e.g., division into chapters in printed catalogs, hierarchical browsing in on-line catalogs).<br/>
    /// A catalog group system can be constructed from the CATALOG_STRUCTURE elements using the CATALOG_GROUP_SYSTEM element.<br/>
    /// Product can then be attached to a catalog group (CATALOG_STRUCTURE) using the PRODUCT_TO_CATALOGGROUP_MAP element (in the context T_NEW_CATALOG) or PRODUCT_TO_CATALOGGROUP_MAP (in the context T_UPDATE_PRODUCTS).<br/>
    /// A catalog group system is built starting at the root and working up to its leaves.<br/>
    /// The structure is created one layer at a time by defining the required subgroup (subsection) for each catalog group.<br/>
    /// In BMEcat however, it is not the relevant subgroups which are specified for each catalog group but rather the other way around: the parent group (element PARENT_ID) belonging to each catalog subgroup is specified instead.<br/>
    /// The complete hierarchical catalog group system can be built up in this way.<br/>
    /// The order of CATALOG_STRUCTURE elements is irrelevant.<br/>
    /// Furthermore, not every branch of the catalog group system needs necessarily hang as low as all the others, i.e. the tree structure does not have to be balanced.<br/>
    /// <br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future.")]
    public class CatalogGroupSystem
    {
        /// <summary>
        /// (optional - deprecated) Catalog group system ID<br/>
        /// <br/>
        /// Identification of the catalog group system.<br/>
        /// The supplier must allocate a unique identification to his catalog group system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("GROUP_SYSTEM_ID")]
        public string? Id { get; set; }

        /// <summary>
        /// (optional - deprecated) Catalog group system name<br/>
        /// <br/>
        /// Name of the catalog group system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("GROUP_SYSTEM_NAME")]
        public MultiLingualString? Name { get; set; }

        /// <summary>
        /// (required - deprecated) Catalog structure element<br/>
        /// <br/>
        /// Information on a catalog group.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CATALOG_STRUCTURE")]
        public List<CatalogStructure>? CatalogStructures { get; set; } = new List<CatalogStructure>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CatalogStructuresSpecified => CatalogStructures?.Count > 0;

        /// <summary>
        /// (optional - deprecated) Group system description<br/>
        /// <br/>
        /// Description of the catalog group system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("GROUP_SYSTEM_DESCRIPTION")]
        public MultiLingualString? Description { get; set; }
    }
}
