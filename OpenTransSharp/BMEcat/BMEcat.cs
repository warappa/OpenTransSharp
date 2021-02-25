using OpenTransSharp.Internal;
using System;
using System.ComponentModel.DataAnnotations;
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
    /// With the T_NEW_CATALOG transaction the target system reacts to the transferred data as follows depending on the CATALOG_ID, CATALOG_VERSION and LANGUAGE received: see documentation.<br/>
    /// <br/>
    /// When the T_NEW_CATALOG transaction is used, the CATALOG_VERSION new and the "T_NEW_CATALOG --&gt; prev_version" must be set to 0 at the next other transaction type(T_UPDATE_PRODUCTS, T_UPDATE_PRICES).<br/>
    /// See also: Example (combination of different transactions).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class NewCatalog
    {
    }
}
