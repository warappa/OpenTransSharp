namespace OpenTransSharp;

/// <summary>
/// (Delivery reference)<br/>
/// <br/>
/// The DELIVERY_REFERENCE element summarizes information on the delivery of the article to which the invoice relates.<br/>
/// Where the element DELIVERY_REFERENCE is used, at least one of the following elements must be specified.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class DeliveryReference
{
    /// <summary>
    /// <inheritdoc cref="DeliveryReference"/>
    /// </summary>
    public DeliveryReference() { }

    /// <summary>
    /// (optional) Delivery note number<br/>
    /// <br/>
    /// Unique delivery note number.<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [OpenTransXmlElement("DELIVERYNOTE_ID")]
    public string? DeliverynoteId { get; set; }

    /// <summary>
    /// (optional) Item number<br/>
    /// <br/>
    /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
    /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
    /// <br/>
    /// Example.: P100012
    /// <br/>
    /// Max length: 50
    /// </summary>
    [OpenTransXmlElement("LINE_ITEM_ID")]
    public string? LineItemId { get; set; }

    /// <summary>
    /// (optional) Delivery date<br/>
    /// <br/>
    /// Date of shipment.<br/>
    /// <br/>
    /// The delivery date specifies the date the commissioned goods are accepted by the buyer.<br/>
    /// If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
    /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.
    /// </summary>
    [OpenTransXmlElement("DELIVERY_DATE")]
    public DeliveryDate? Date { get; set; }

    /// <summary>
    /// (optional) Reference to final recipient<br/>
    /// <br/>
    /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
    /// The element has to refer to a PARTY_ID in the same document.
    /// </summary>
    [OpenTransXmlElement("DELIVERY_IDREF")]
    public DeliveryIdRef? IdRef { get; set; }
}
