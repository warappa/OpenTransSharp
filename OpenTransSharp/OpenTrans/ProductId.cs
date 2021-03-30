using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Product number)<br/>
    /// <br/>
    /// Identifier of the product.<br/>
    /// The included elements ensure the capability of a unique identification of a product.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class ProductId
    {
        /// <summary>
        /// (optional) Supplier's product ID<br/>
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
        [BMEXmlElement("SUPPLIER_PID")]
        public global::BMEcatSharp.SupplierPid? SupplierPid { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public global::BMEcatSharp.SupplierIdref? SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Configurationcode<br/>
        /// <br/>
        /// The code describes the product in case of configurable or parameterizable products.<br/>
        /// The code can be determined via a configuration process or a remote call of a catalog (IPP).
        /// </summary>
        [OpenTransXmlElement("CONFIG_CODE_FIX")]
        public string? ConfigurationCodeFix { get; set; }

        /// <summary>
        /// (optional) Lot number<br/>
        /// <br/>
        /// Unique identifier of the lot where the product is originated.<br/>
        /// The usage of the term is common, however the lot number is a character sequence and therefore can contain alphanumeric characters.
        /// </summary>
        [OpenTransXmlElement("LOT_NUMBER")]
        public List<string>? LotNumbers { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LotNumbersSpecified => LotNumbers?.Count > 0;

        /// <summary>
        /// (optional) Serial number<br/>
        /// <br/>
        /// Unique identifier for a single product (product instance).<br/>
        /// The term is commonly used, nevertheless a serial number can alos consist of alphanumeric characters.
        /// </summary>
        [OpenTransXmlElement("SERIAL_NUMBER")]
        public List<string>? SerialNumbers { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SerialNumbersSpecified => SerialNumbers?.Count > 0;

        /// <summary>
        /// (optional) International product number<br/>
        /// <br/>
        /// Indicates an international product number (e.g., EAN).<br/>
        /// The underlying standard respectively organisation is given in the 'type' attribute.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("INTERNATIONAL_PID")]
        public List<global::BMEcatSharp.InternationalPid>? InternationalPids { get; set; } = new List<global::BMEcatSharp.InternationalPid>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InternationalPidsSpecified => InternationalPids?.Count > 0;

        /// <summary>
        /// (optional) Product ID of the buying company<br/>
        /// <br/>
        /// Product number used by the buying firm.<br/>
        /// The "type" attribute specifies the type of ID.<br/>
        /// If the element is used multiple, the values of the attribute "type" must differ.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("BUYER_PID")]
        public List<global::BMEcatSharp.BuyerPid>? BuyerPids { get; set; } = new List<global::BMEcatSharp.BuyerPid>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BuyerPidsSpecified => BuyerPids?.Count > 0;

        /// <summary>
        /// (optional) Short description<br/>
        /// <br/>
        /// This element contains the short description of the product.<br/>
        /// In general, the description should be short and, whithin the first 40 characters, unique and meaningful, because many software systems can only interpret these 40 characters(i.e.SAP-OCI, SAP R/3).<br/>
        /// Detailed descriptions are beneficial to product search, especially if many products are quite similar and differ only in specific details.<br/>
        /// In these cases, product search returns a list of products from which the right product can easily be determined.<br/>
        /// Abbreviations of essential product characteristics should be avoided (e.g., bw for black and white).<br/>
        /// However, abbreviations of organisations and standards can be used(e.g., ISO, VDE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DESCRIPTION_SHORT")]
        public List<global::BMEcatSharp.MultiLingualString>? DescriptionShorts { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionShortsSpecified => DescriptionShorts?.Count > 0;

        /// <summary>
        /// (optional ) Long description<br/>
        /// <br/>
        /// This element contains the long description of the product.<br/>
        /// <br/>
        /// Format:<br/>
        /// The following HTML tags are supported: &lt;b&gt; for bold, &lt;i&gt; for italic, &lt;p&gt; for paragraphs, &lt;br&gt; for line break and&lt;ul&gt;/&lt;li> for lists.<br/>
        /// In order to transfer these, the characters '&lt;' and '&gt;' must be enclosed in quotation marks, or the BMEcat DTD will not be accepted by the XML parser (see also chapter Character encoding in XML).<br/>
        /// <br/>
        /// Example: '&lt;' = &lt; or '&gt;' = &gt;<br/>
        /// <br/>
        /// Caution:<br/>
        /// The target system must support the interpretation of the day in order to achieve the desired formatting.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("DESCRIPTION_LONG")]
        public List<global::BMEcatSharp.MultiLingualString>? DescriptionLongs { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionLongsSpecified => DescriptionLongs?.Count > 0;

        /// <summary>
        /// (optional) Manufacturer information<br/>
        /// <br/>
        /// Information assigned to the article by the manufacturer is stored here.
        /// </summary>
        [OpenTransXmlElement("MANUFACTURER_INFO")]
        public ManufacturerInformation? ManufacturerInfo { get; set; }

        /// <summary>
        /// (optional) Product type<br/>
        /// <br/>
        /// Characterizes the product with regard to its general type, i.e. being tangible or service.
        /// </summary>
        [BMEXmlElement("PRODUCT_TYPE")]
        public global::BMEcatSharp.ProductType? ProductType { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductTypeSpecified => ProductType != null;
    }
}
