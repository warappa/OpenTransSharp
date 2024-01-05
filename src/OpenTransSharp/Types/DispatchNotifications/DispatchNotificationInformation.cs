﻿namespace OpenTransSharp;

/// <summary>
/// (Dispatch notification information)<br/>
/// <br/>
/// The DISPATCHNOTIFICATION_INFO element summarizes administrative information about this request for quotation.
/// </summary>
public class DispatchNotificationInformation
{
    /// <summary>
    /// <inheritdoc cref="DispatchNotificationInformation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DispatchNotificationInformation()
    {
        Id = null!;
        SupplierIdRef = null!;
    }

    /// <summary>
    /// <inheritdoc cref="DispatchNotificationInformation"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parties"></param>
    /// <param name="supplierIdRef"></param>
    /// <param name="shipmentPartiesReference"></param>
    public DispatchNotificationInformation(string id, IEnumerable<OpenTransParty> parties, SupplierIdRef supplierIdRef,
        ShipmentPartiesReference shipmentPartiesReference)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (parties is null)
        {
            throw new ArgumentNullException(nameof(parties));
        }

        Id = id;
        Parties = parties.ToList();
        SupplierIdRef = supplierIdRef ?? throw new ArgumentNullException(nameof(supplierIdRef));
        ShipmentPartiesReference = shipmentPartiesReference ?? throw new ArgumentNullException(nameof(shipmentPartiesReference));
    }

    /// <summary>
    /// (required) Dispatch notification number<br/>
    /// <br/>
    /// Unique dispatch notification number of the supplier.
    /// </summary>
    [XmlElement("DISPATCHNOTIFICATION_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (optional) Date of order dispatch<br/>
    /// <br/>
    /// Date of the dispatch of the order.
    /// </summary>
    [XmlElement("DISPATCHNOTIFICATION_DATE")]
    public DateTime? Date { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DateSpecified => Date.HasValue;

    /// <summary>
    /// (optional) Language<br/>
    /// <br/>
    /// Specification of used languages, especially the default language of all language-dependent information<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("LANGUAGE")]
    public List<global::BMEcatSharp.Language>? Languages { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool LanguagesSpecified => Languages?.Count > 0;

    /// <summary>
    /// (optional) MIME root directory<br/>
    /// <br/>
    /// A relative directory can be entered here (and/or a URI), i.e. one to which the relative paths in MIME_SOURCE refer.<br/>
    /// <br/>
    /// Max length: 250<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_ROOT")]
    public global::BMEcatSharp.MultiLingualString? MimeRoot { get; set; }

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
    /// (required) Parties<br/>
    /// <br/>
    /// List of parties that are relevant to this business document.
    /// </summary>
    [XmlArray("PARTIES")]
    [XmlArrayItem("PARTY")]
    public List<OpenTransParty> Parties { get; set; } = [];

    /// <summary>
    /// (required) Reference to supplier<br/>
    /// <br/>
    /// Reference to the supplier.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_IDREF")]
    public global::BMEcatSharp.SupplierIdRef SupplierIdRef { get; set; }

    /// <summary>
    /// (optional) Reference to the buyer<br/>
    /// <br/>
    /// Reference to the buyer.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (PARTY element).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("BUYER_IDREF")]
    public global::BMEcatSharp.BuyerIdRef? BuyerIdRef { get; set; }

    /// <summary>
    /// (required) Shipment parties<br/>
    /// <br/>
    /// Refers to business partners integrated in the process of the goods delivery procedure.
    /// </summary>
    [XmlElement("SHIPMENT_PARTIES_REFERENCE")]
    public ShipmentPartiesReference ShipmentPartiesReference { get; set; } = new ShipmentPartiesReference();

    /// <summary>
    /// (optional) Shipment ID<br/>
    /// <br/>
    /// The element contains the ID for the physical shipment of the goods and is usually assigned by the carrier.
    /// </summary>
    [XmlElement("SHIPMENT_ID")]
    public string? ShipmentId { get; set; }

    /// <summary>
    /// (optional) Tracking and Tracing URL<br/>
    /// <br/>
    /// URL to a Track and Tracing functionality.<br/>
    /// Ususally the shipment-ID can be used to track and trace a shipment via a web-based tool.
    /// </summary>
    [XmlElement("TRACKING_TRACING_URL")]
    public string? TrackingTracingUrl { get; set; }

    /// <summary>
    /// (optional) Document exchange parties<br/>
    /// <br/>
    /// Reference to the business partners who take part in the document exchange.
    /// </summary>
    [XmlElement("DOCEXCHANGE_PARTIES_REFERENCE")]
    public DocexchangePartiesReference? DocexchangePartiesReference { get; set; }

    /// <summary>
    /// (optional) Logistics information<br/>
    /// <br/>
    /// The element contains logistical details in document level (HEADER).
    /// </summary>
    [XmlElement("LOGISTIC_DETAILS_INFO")]
    public LogisticDetailsInformation? LogisticDetailsInformation { get; set; }

    /// <summary>
    /// (optional) International delivery restrictions<br/>
    /// <br/>
    /// Details of international restrictions, e.g. compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("INTERNALTIONAL_RESTRICTIONS")]
    public List<global::BMEcatSharp.InternationalRestriction> InternationalRestrictions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalRestrictionsSpecified => InternationalRestrictions?.Count > 0;

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files.
    /// </summary>
    [XmlElement("MIME_INFO")]
    public OpenTransMimeInfo? MimeInfo { get; set; }

    /// <summary>
    /// (optional) Remark<br/>
    /// <br/>
    /// Remark related to a business document.
    /// </summary>
    [XmlElement("REMARKS")]
    public List<Remark> Remarks { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemarksSpecified => Remarks?.Count > 0;

    /// <summary>
    /// (optional) User-defined extension<br/>
    /// <br/>
    /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones. The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions. The structure of these elements can be very complex, though it must be valid XML.<br/>
    /// <br/>
    /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
    /// <br/>
    /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
    /// <br/>
    /// The definition of user-defined extensions takes place by additional XML DTD or XML-Schema files.
    /// </summary>
    [XmlArray("HEADER_UDX")]
    public List<object>? HeaderUdx { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HeaderUdxSpecified => HeaderUdx?.Count > 0;
}
