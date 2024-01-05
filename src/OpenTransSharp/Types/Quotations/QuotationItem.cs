namespace OpenTransSharp;

/// <summary>
/// (Item line)<br/>
/// <br/>
/// An item line contains the quotation information about exactly one item.<br/>
/// Any number of item lines may be used, at least one item line must be used.
/// </summary>
public class QuotationItem
{
    /// <summary>
    /// <inheritdoc cref="QuotationItem"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public QuotationItem()
    {
        LineItemId = null!;
        ProductId = null!;
    }

    /// <summary>
    /// <inheritdoc cref="QuotationItem"/>
    /// </summary>
    /// <param name="lineItemId"></param>
    /// <param name="productId"></param>
    /// <param name="quantity"></param>
    /// <param name="orderUnit"></param>
    public QuotationItem(string lineItemId, ProductId productId, decimal quantity,
        BMEcatSharp.PackageUnit orderUnit)
    {
        if (string.IsNullOrWhiteSpace(lineItemId))
        {
            throw new System.ArgumentException($"'{nameof(lineItemId)}' cannot be null or whitespace.", nameof(lineItemId));
        }

        LineItemId = lineItemId;
        ProductId = productId ?? throw new System.ArgumentNullException(nameof(productId));
        Quantity = quantity;
        OrderUnit = orderUnit;
    }

    /// <summary>
    /// (required) Item number<br/>
    /// <br/>
    /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
    /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
    /// <br/>
    /// Example.: P100012
    /// </summary>
    [XmlElement("LINE_ITEM_ID")]
    public string LineItemId { get; set; }

    /// <summary>
    /// (required) Product number<br/>
    /// <br/>
    /// Identifier of the product.<br/>
    /// The included elements ensure the capability of a unique identification of a product.
    /// </summary>
    [XmlElement("PRODUCT_ID")]
    public ProductId ProductId { get; set; }

    /// <summary>
    /// (optional) Product features<br/>
    /// <br/>
    /// Description of the product by features and/or classification of the product.
    /// </summary>
    [OpenTransXmlElement("PRODUCT_FEATURES")]
    public global::BMEcatSharp.ProductFeatures? ProductFeatures { get; set; }

    /// <summary>
    /// (optional) Product components<br/>
    /// <br/>
    /// List of product componentes contained in a product.
    /// </summary>
    [OpenTransXmlArray("PRODUCT_COMPONENTS")]
    [OpenTransXmlArrayItem("PRODUCT_COMPONENT")]
    public List<ProductComponent>? ProductComponents { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ProductComponentsSpecified => ProductComponents?.Count > 0;

    /// <summary>
    /// (required) Quantity<br/>
    /// <br/>
    /// Quantity.
    /// </summary>
    [XmlElement("QUANTITY")]
    public decimal Quantity { get; set; }

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
    public BMEcatSharp.PackageUnit OrderUnit { get; set; }

    /// <summary>
    /// (optional) Determined product price<br/>
    /// <br/>
    /// A fixed product price.
    /// </summary>
    [XmlElement("PRODUCT_PRICE_FIX")]
    public ProductPriceFix? ProductPriceFix { get; set; }

    /// <summary>
    /// (optional) Total price of the position<br/>
    /// <br/>
    /// The total price of the item-line.<br/>
    /// In the normal case the value results from multiplying PRICE_AMOUNT and QUANTITY but has to be explicitly quoted.<br/>
    /// The element PRICE_LINE_AMOUNT can result from multiplying PRICE_AMOUNT and PRICE_UNIT_VALUE if the price is not connected to the ordered unit but to another price-unit.<br/>
    /// See PRICE_BASE_FIX for details.
    /// </summary>
    [XmlElement("PRICE_LINE_AMOUNT")]
    public decimal? PriceLineAmount { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PriceLineAmountSpecified => PriceLineAmount.HasValue;

    /// <summary>
    /// (optional) Reference to a skeleton agreement<br/>
    /// <br/>
    /// Information on the skeleton agreement which serves as a basis for the validity of the business document.
    /// </summary>
    [XmlElement("AGREEMENT")]
    public List<global::BMEcatSharp.Agreement>? Agreements { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AgreementsSpecified => Agreements?.Count > 0;

    /// <summary>
    /// (optional) Reference to an (electronic) product catalog<br/>
    /// <br/>
    /// Order reference to a catalog. This element can also be used as a reference to a price list.
    /// </summary>
    [XmlElement("CATALOG_REFERENCE")]
    public CatalogReference? CatalogReference { get; set; }

    /// <summary>
    /// (optional) Partial shipment allowed<br/>
    /// <br/>
    /// Flag to indicate whether partial shipment is allowed. If allowed the value is TRUE, FALSE otherwise.<br/>
    /// The flag is binding for the order, i.e. if the value is set to FALSE and only partial shipments can be made by the recipient of the order, the order shall be invalid.<br/>
    /// Additionally one can provide concrete dates for the shipment.<br/>
    /// <br/>
    /// In contrast to the general possibility for partial shipments one can use the element PARTIAL_DELIVERY_LIST for concrete dates for partial shipments. In this case the element PARTIAL_SHIPMENT_ALLOWED is not used.<br/>
    /// <br/>
    /// Caution:<br/>
    /// If the element is used in the context ORDER_HEADER, the element must not be used on item level ORDER_ITEM.
    /// </summary>
    [XmlIgnore]
    public bool? PartialShipmentAllowed { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlElement("PARTIAL_SHIPMENT")] // Yes, without "_ALLOWED"...
    public string? PartialShipmentAllowedForSerializer { get => PartialShipmentAllowed is null ? null : PartialShipmentAllowed == true ? "true" : "false"; set => PartialShipmentAllowed = value is null ? null : value.ToLowerInvariant() == "true"; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PartialShipmentAllowedForSerializerSpecified => PartialShipmentAllowed == true;

    /// <summary>
    /// (optional) Delivery date <br/>
    /// <br/>
    /// Date of shipment.<br/>
    /// <br/>
    /// The delivery date specifies the date the commissioned goods are accepted by the buyer. If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
    /// <br/>
    /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.
    /// </summary>
    [XmlElement("DELIVERY_DATE")]
    public DeliveryDate? DeliveryDate { get; set; }

    /// <summary>
    /// (optional) Partial shipment list<br/>
    /// <br/>
    /// Information related to items of outstanding partial shipments.
    /// </summary>
    [XmlElement("PARTIAL_DELIVERY_LIST")]
    public PartialDeliveryList? PartialDeliveryList { get; set; }

    /// <summary>
    /// (optional) Shipment parties<br/>
    /// <br/>
    /// Refers to business partners integrated in the process of the goods delivery procedure.
    /// </summary>
    [XmlElement("SHIPMENT_PARTIES_REFERENCE")]
    public ShipmentPartiesReference? ShipmentPartiesReference { get; set; }

    /// <summary>
    /// (optional) Transport<br/>
    /// <br/>
    /// Information about the terms of transport.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TRANSPORT")]
    public global::BMEcatSharp.Transport? Transport { get; set; }

    /// <summary>
    /// (optional) International delivery restrictions<br/>
    /// <br/>
    /// Details of international restrictions, e.g. compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("INTERNALTIONAL_RESTRICTIONS")]
    public List<global::BMEcatSharp.InternationalRestriction>? InternationalRestrictions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalRestrictionsSpecified => InternationalRestrictions?.Count > 0;

    /// <summary>
    /// (optional) Special treatment class<br/>
    /// <br/>
    /// Additional product classification used for hazardous goods or substances, primary pharmaceutical products, radioactive measuring equipment, etc. The "type" attribute specifies the dangerous goods classification scheme.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SPECIAL_TREATMENT_CLASS")]
    public List<global::BMEcatSharp.SpecialTreatmentClass>? SpecialTreatmentClasses { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SpecialTreatmentClassesSpecified => SpecialTreatmentClasses?.Count > 0;

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files.<br/>
    /// </summary>
    [XmlElement("MIME_INFO")]
    public OpenTransMimeInfo? MimeInfo { get; set; }

    /// <summary>
    /// (optional) Remark<br/>
    /// <br/>
    /// Remark related to a business document.
    /// </summary>
    [XmlElement("REMARKS")]
    public List<Remark>? Remarks { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemarksSpecified => Remarks?.Count > 0;

    /// <summary>
    /// (optional) User-defined extensions<br/>
    /// <br/>
    /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones.<br/>
    /// <br/>
    /// The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
    /// The structure of these elements can be very complex, though it must be valid XML.<br/>
    /// <br/>
    /// Caution:<br/>
    /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
    /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.<br/>
    /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
    /// <br/>
    /// The definition of user-defined extensions takes place by additional XML DTD or XML.
    /// </summary>
    [XmlArray("ITEM_UDX")]
    public List<object>? ItemUdx { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ItemUdxSpecified => ItemUdx?.Count > 0;
}
