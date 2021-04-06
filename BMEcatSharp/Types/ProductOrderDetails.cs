using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Order details)<br/>
    /// <br/>
    /// This element information on ordering and packing.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductOrderDetails
    {
        /// <summary>
        /// <inheritdoc cref="ProductOrderDetails"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProductOrderDetails()
        {
        }

        /// <summary>
        /// <inheritdoc cref="ProductOrderDetails"/>
        /// </summary>
        /// <param name="orderUnit"></param>
        /// <param name="contentUnit"></param>
        public ProductOrderDetails(PackageUnit orderUnit, PackageUnit contentUnit)
        {
            OrderUnit = orderUnit;
            ContentUnit = contentUnit;
        }

        /// <summary>
        /// (required) Order unit<br/>
        /// <br/>
        /// Unit in which the product can be ordered; it is only possible to order multiples of the product unit.<br/>
        /// The price also always refers to this unit (or to part of or multiples of it).<br/>
        /// <br/>
        /// Example: Crate of mineral water with 6 bottles<br/>
        /// Order unit: "crate", contents unit/unit of the article: "bottle"<br/>
        /// Packing quantity: "6"<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ORDER_UNIT")]
        public PackageUnit OrderUnit { get; set; }

        /// <summary>
        /// (required) Content of the unit<br/>
        /// <br/>
        /// Unit of the product related to the order unit.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONTENT_UNIT")]
        public PackageUnit ContentUnit { get; set; }

        /// <summary>
        /// (optional) Packing quantity<br/>
        /// <br/>
        /// Number of content units per order unit of the product.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("NO_CU_PER_OU")]
        public decimal? NumberContentUnitsPerOrderUnit { get; set; } = 1;

        /// <summary>
        /// (optional) Reference to a product number<br/>
        /// <br/>
        /// This element provides a reference to a product number of the supplier.<br/>
        /// It contains the unique identifier (SUPPLIER_PID) that is defined in the document.<br/>
        /// In this context the element is used to reference the product number of the content.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_PIDREF")]
        public string? SupplierPIdRef { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdRef? SupplierIdRef { get; set; }

        /// <summary>
        /// (optional) Price quantity<br/>
        /// <br/>
        /// If nothing is specified in this field the default value 1 is assumed, in other words the price refers to exactly one order unit.<br/>
        /// <br/>
        /// If specified, a multiple or a fraction of the order unit (element ORDER_UNIT) which indicates the quantity to which all the specified prices refer.<br/>
        /// <br/>
        /// Example: 10 (i.e. the specified price refers to 10 crates).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_QUANTITY")]
        public decimal? PriceQuantity { get; set; } = 1;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PriceQuantitySpecified => PriceQuantity.HasValue;

        /// <summary>
        /// (optional) Minimum quantity<br/>
        /// <br/>
        /// Minimum order quantity with respect to the order unit (ORDER_UNIT); if not specified, the minimum order quantity is 1.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("QUANTITY_MIN")]
        public decimal? MinimumQuantity { get; set; } = 1;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MinimumQuantitySpecified => MinimumQuantity.HasValue;

        /// <summary>
        /// (optional) Quantity interval<br/>
        /// <br/>
        /// Number indicating the quantity steps in which the articles can be ordered.<br/>
        /// The first step always corresponds to the minimum order quantity specified.<br/>
        /// The unit of the quantity interval is the same as the order unit.<br/>
        /// Example: 1 (i.e. 5, 6, 7, ... crates)<br/>
        /// Example: 2 (i.e. 4, 6, 8, ... crates)<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("QUANTITY_INTERVAL")]
        public decimal? QuantityInterval { get; set; } = 1;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool QuantityIntervalSpecified => QuantityInterval.HasValue;

        /// <summary>
        /// (optional) Maximum quantity<br/>
        /// <br/>
        /// Maximum order quantity with respect to the order unit (ORDER_UNIT); if not specified, the order quantity is not limited.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("QUANTITY_MAX")]
        public decimal? MaximumQuantity { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MaximumQuantitySpecified => MaximumQuantity.HasValue;

        /// <summary>
        /// (optional) Packing units<br/>
        /// <br/>
        /// Information on the dependency of the packing unit from the order unit.<br/>
        /// Example: Printing paper á 500 sheets has the order unit pack; ordering 5 packs results in a new packing unit, karton; ordering 50 packs or 10 cartons results in another packing unit, covering box; ordering 500 packs or 100 cartons results in the biggest packing unit here, palette.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PACKING_UNITS")]
        public List<PackingUnit>? PackingUnits { get; set; } = new List<PackingUnit>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PackingUnitsSpecified => PackingUnits?.Count > 0;
    }
}
