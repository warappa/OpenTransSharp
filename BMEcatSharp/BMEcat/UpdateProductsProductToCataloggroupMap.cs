using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Mapping to catalog group)<br/>
    /// <br/>
    /// Once the catalog structure (CATALOG_GROUP_SYSTEM) has been built up, products can be attached to this tree.<br/>
    /// Since products often cannot clearly be assigned (mapped) to a single group, it is possible to map a product to several different groups.<br/>
    /// In this case, however, a PRODUCT_TO_CATALOGGROUP_MAP in context T_UPDATE_PRODUCTS element must be entered for each mapping.<br/>
    /// The order of the PRODUCT_TO_CATALOGGROUP_MAP in context T_UPDATE_PRODUCTS elements is not relevant.<br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future")]
    public class UpdateProductsProductToCataloggroupMap
    {
        /// <summary>
        /// (required) Mode<br/>
        /// <br/>
        /// Indicates whether the element is describing a new assignment or the deletion of an existing assignment.
        /// </summary>
        [XmlAttribute]
        public UpdateProductsProductToCataloggroupMapMode Mode { get; set; }

        /// <summary>
        /// (required - deprecated) Product ID<br/>
        /// <br/>
        /// Number of the product which belongs to the group.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future")]
        [BMEXmlElement("PROD_ID")]
        public string ProductId { get; set; }

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
        /// (required - deprecated) Catalog group<br/>
        /// <br/>
        /// Reference to the catalog group.<br/>
        /// It must point to a GROUP_ID (see definition of catalog groups by the CATALOG_STRUCTURE element).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future")]
        [BMEXmlElement("CATALOG_GROUP_ID")]
        public string CatalogGroupId { get; set; }

        /// <summary>
        /// (optional - deprecated) Product order<br/>
        /// <br/>
        /// Order in which the products are represented within a catalog group (CATALOG_STRUCTURE) in the target system.<br/>
        /// <br/>
        /// When the products are listed they are listed in ascending order (the first product corresponds to the lowest number).<br/>
        /// <br/>
        /// If products from several groups are represented, the products should be sorted according to PRODUCT_ORDER rather than to PRODUCT_TO_CATALOGGROUP_MAP_ORDER.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future")]
        [BMEXmlElement("PRODUCT_ORDER")]
        public int? ProductOrder { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ProductOrderSpecified => ProductOrder.HasValue;
    }
}
