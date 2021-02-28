using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Product reference)<br/>
    /// <br/>
    /// A product reference allows it to point from one product to another product.<br/>
    /// These references have a specific meaning, in other words they define a semantic relationship between the two products.<br/>
    /// <br/>
    /// Each product can reference any number of other products (even products contained in other product catalogs).<br/>
    /// The various reference types can be used more than once (e.g., multiple spare parts).<br/>
    /// <br/>
    /// The reference types are pre-defined and it is not possible to extend the given number of reference types.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductReference
    {
        /// <summary>
        /// (required) Reference type<br/>
        /// <br/>
        /// The reference type describes the relationship between the two products.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlAttribute("type")]
        public ProductReferenceType Type { get; set; }

        /// <summary>
        /// (optional) Quantity<br/>
        /// <br/>
        /// The attribute "quantity" describes how many products are being referenced.<br/>
        /// Use of this attribute is only useful for some reference types (e.g., "consists_of").<br/>
        /// If there is nothing entered for the attribute "quantity", the quantity is unspecified or is not important in this context.Refer also to Example 3.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool QuantitySpecified => Quantity != 0;

        /// <summary>
        /// (required) Reference product<br/>
        /// <br/>
        /// This is the unique number (SUPPLIER_PID) of the product to which a reference is made.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("PROD_ID_TO")]
        public string ProductIdTo { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document(element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref? SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Catalog ID<br/>
        /// <br/>
        /// Unique catalog identification. This ID is usually assigned by the supplier when the catalog is generated and remains unchanged throughout the entire lifecycle of the catalog.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CATALOG_ID")]
        public string? CatalogId { get; set; }

        /// <summary>
        /// (optional) Catalog version<br/>
        /// <br/>
        /// Version number of the catalog.<br/>
        /// May only be reset on the target system in conjunction with a T_NEW_CATALOG transaction and not in the case of updates, see also example (Interaction of various transactions).<br/>
        /// <br/>
        /// Format: "MajorVersion"."MinorVersion" (maximum xxx.yyy)<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlIgnore]
        public Version? CatalogVersion { get; set; }
        [BMEXmlElement("CATALOG_VERSION")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string? CatalogVersionString
        {
            get => CatalogVersion.ToString();
            set => CatalogVersion = value is null ? null : new Version(value);
        }

        /// <summary>
        /// (optional) Dieses Element kann genutzt werden, um die Produktreferenz zu beschreiben.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("REFERENCE_DESCR")]
        public MultiLingualString? ReferenceDescription { get; set; }

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// In this context the MIME-files can be used to describe the reference (e.g. usage of a accessory).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public BMEcatMimeInfo? MimeInfo { get; set; }
    }
}
