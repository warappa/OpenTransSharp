using OpenTransSharp.Internal;
using System;
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

    public class Formula
    {
    }

    public class ProductConfigDetails
    {
    }

    public class ProductIppDetails
    {
    }


    public class IppDefinitions
    {
    }

    public class CatalogGroupSystem
    {
    }
}
