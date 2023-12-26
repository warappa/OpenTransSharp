using BMEcatSharp.Xml;
using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp;

/// <summary>
/// (Product component)<br/>
/// <br/>
/// Products which are part of other products are specified via this element.<br/>
/// Product components with related price informations only have an informative character.<br/>
/// Prices related to product components are not used to integrate in the price calculation of the higher level product.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class ProductComponent
{
    /// <summary>
    /// <inheritdoc cref="ProductComponent"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProductComponent()
    {
        ProductId = null!;
        ProductFeatures = null!;
    }

    /// <summary>
    /// <inheritdoc cref="ProductComponent"/>
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="productFeatures"></param>
    /// <param name="quantity"></param>
    /// <param name="orderUnit"></param>
    public ProductComponent(ProductId productId, BMEcatSharp.ProductFeatures productFeatures, decimal quantity,
        BMEcatSharp.PackageUnit orderUnit)
    {
        ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
        ProductFeatures = productFeatures ?? throw new ArgumentNullException(nameof(productFeatures));
        Quantity = quantity;
        OrderUnit = orderUnit;
    }

    /// <summary>
    /// (required) Product number<br/>
    /// <br/>
    /// Identifier of the product. The included elements ensure the capability of a unique identification of a product.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    [OpenTransXmlElement("PRODUCT_ID")]
    public ProductId ProductId { get; set; }

    /// <summary>
    /// (required) Product features<br/>
    /// <br/>
    /// Description of the product by features and/or classification of the product.
    /// </summary>
    [OpenTransXmlElement("PRODUCT_FEATURES")]
    public global::BMEcatSharp.ProductFeatures? ProductFeatures { get; set; }

    /// <summary>
    /// (optional) Product components<br/>
    /// <br/>
    /// List of product componentes contained in a product.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    [OpenTransXmlArray("PRODUCT_COMPONENTS")]
    [OpenTransXmlArrayItem("PRODUCT_COMPONENT")]
    public List<ProductComponent>? ProductComponents { get; set; } = new List<ProductComponent>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ProductComponentsSpecified => ProductComponents?.Count > 0;

    /// <summary>
    /// (required) Quantity<br/>
    /// <br/>
    /// Quantity.
    /// </summary>
    [OpenTransXmlElement("QUANTITY")]
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
    /// A fixed product price.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    [OpenTransXmlElement("PRODUCT_PRICE_FIX")]
    public ProductPriceFix? ProductPriceFix { get; set; }
}
