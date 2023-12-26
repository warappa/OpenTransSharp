﻿namespace OpenTransSharp;

/// <summary>
/// (Order history)<br/>
/// <br/>
/// In the element ORDER_HISTORY information is summarized on the procurement activities which preceded this order.<br/>
/// When the element ORDER_HISTORY is used, at least one of the following elements must be specified.
/// </summary>
public class OrderHistory
{
    /// <summary>
    /// <inheritdoc cref="OrderHistory"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderHistory()
    {
        OrderId = null!;
    }

    /// <summary>
    /// <inheritdoc cref="OrderHistory"/>
    /// </summary>
    /// <param name="orderId"></param>
    public OrderHistory(string orderId)
    {
        if (string.IsNullOrWhiteSpace(orderId))
        {
            throw new ArgumentException($"'{nameof(orderId)}' cannot be null or whitespace.", nameof(orderId));
        }

        OrderId = orderId;
    }
    /// <summary>
    /// (required) Order number of the buyer<br/>
    /// <br/>
    /// Unique order number of the buyer.
    /// </summary>
    [XmlElement("ORDER_ID")]
    public string OrderId { get; set; }

    /// <summary>
    /// (optional) Alternative order number of the buyer<br/>
    /// <br/>
    /// Further buyer order numbers which can be specified by the buyer.<br/>
    /// Relevant in the case of orders which are passed on again.<br/>
    /// Here the order number of the original ordering party can be set down.
    /// </summary>
    [XmlElement("ALT_CUSTOMER_ORDER_ID")]
    public List<string>? AlternativeCustomerOrderId { get; set; } = new List<string>();

    /// <summary>
    /// (optional) Supplier order number<br/>
    /// <br/>
    /// Unique order number of the supplier.
    /// </summary>
    [XmlElement("SUPPLIER_ORDER_ID")]
    public string? SupplierOrderId { get; set; }

    /// <summary>
    /// (optional) Date of the order<br/>
    /// <br/>
    /// Date of the order.
    /// </summary>
    [XmlElement("ORDER_DATE")]
    public DateTime? OrderDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderDateSpecified => OrderDate.HasValue;

    /// <summary>
    /// (optional) Description of the order<br/>
    /// <br/>
    /// Textual description of the order.
    /// </summary>
    [BMEXmlElement("ORDER_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? OrderDescription { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderDescriptionSpecified => OrderDescription?.Count > 0;

    /// <summary>
    /// (optional) Delivery note number<br/>
    /// <br/>
    /// Unique delivery note number.<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlElement("DELIVERYNOTE_ID")]
    public string? DeliverynoteId { get; set; }

    /// <summary>
    /// (optional) Date of the delivery note<br/>
    /// <br/>
    /// Dates of the delivery note.
    /// </summary>
    [XmlElement("DELIVERYNOTE_DATE", IsNullable = true)]
    public DateTime? DeliverynoteDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DeliverynoteDateSpecified => DeliverynoteDate.HasValue;

    /// <summary>
    /// (optional) Reference to a skeleton agreement<br/>
    /// <br/>
    /// Information on the skeleton agreement which serves as a basis for the validity of the business document.
    /// </summary>
    [XmlElement("AGREEMENT")]
    public List<global::BMEcatSharp.Agreement>? Agreements { get; set; } = new List<global::BMEcatSharp.Agreement>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AgreementsSpecified => Agreements?.Count > 0;

    /// <summary>
    /// (optional) Reference to an (electronic) product catalog<br/>
    /// <br/>
    /// Order reference to a catalog. This element can also be used as a reference to a price list.
    /// </summary>
    [XmlElement("CATALOG_REFERENCE")]
    public CatalogReference? CatalogReference { get; set; }
}
