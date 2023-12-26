namespace OpenTransSharp;

/// <summary>
/// (Business partners)<br/>
/// <br/>
/// Reference to the business partners integrated in the process of the document flow.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class OrderPartiesReference
{
    /// <summary>
    /// <inheritdoc cref="OrderPartiesReference"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderPartiesReference()
    {
        BuyerIdRef = null!;
        SupplierIdRef = null!;
    }

    /// <summary>
    /// <inheritdoc cref="OrderPartiesReference"/>
    /// </summary>
    /// <param name="buyerIdRef"></param>
    /// <param name="supplierIdRef"></param>
    public OrderPartiesReference(BMEcatSharp.BuyerIdRef buyerIdRef, BMEcatSharp.SupplierIdRef supplierIdRef)
    {
        BuyerIdRef = buyerIdRef ?? throw new System.ArgumentNullException(nameof(buyerIdRef));
        SupplierIdRef = supplierIdRef ?? throw new System.ArgumentNullException(nameof(supplierIdRef));
    }

    /// <summary>
    /// (required) Reference to the buyer<br/>
    /// <br/>
    /// Reference to the buyer.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (PARTY element).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("BUYER_IDREF")]
    public global::BMEcatSharp.BuyerIdRef BuyerIdRef { get; set; }

    /// <summary>
    /// (required) Reference to supplier<br/>
    /// <br/>
    /// Reference to the supplier.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document(element PARTY).
    /// </summary>
    [BMEXmlElement("SUPPLIER_IDREF")]
    public global::BMEcatSharp.SupplierIdRef SupplierIdRef { get; set; }

    /// <summary>
    /// (optional) Reference to the recipient of the invoice<br/>
    /// <br/>
    /// Reference to an unique identifier to the recipient of the invoice.<br/>
    /// The element refers to a PARTY_ID of an invoice recipient in the same document.
    /// </summary>
    [OpenTransXmlElement("INVOICE_RECIPIENT_IDREF")]
    public InvoiceRecipientIdRef? InvoiceRecipientIdRef { get; set; }

    /// <summary>
    /// (optional) Shipment parties<br/>
    /// <br/>
    /// Refers to business partners integrated in the process of the goods delivery procedure.
    /// </summary>
    [OpenTransXmlElement("SHIPMENT_PARTIES_REFERENCE")]
    public ShipmentPartiesReference? ShipmentPartiesReference { get; set; }
}
