﻿namespace OpenTransSharp;

/// <summary>
/// (Header level)<br/>
/// <br/>
/// The header is specified by the RFQ_HEADER element. RFQ_HEADER is used to transfer information about the business partners and the business document and enter default settings which can basically be overwritten on item level (RFQ_ITEM).<br/>
/// <br/>
/// Caution:<br/>
/// The exception for overwriting on item level (RFQ_ITEM) is the element PARTIAL_SHIPMENT_ALLOWED. In this case the value in the header overwrites the value on item level (RFQ_ITEM).
/// </summary>
public class RequestForQuotationHeader
{
    /// <summary>
    /// <inheritdoc cref="RequestForQuotationHeader"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public RequestForQuotationHeader() { }

    /// <summary>
    /// <inheritdoc cref="RequestForQuotationHeader"/>
    /// </summary>
    /// <param name="information"></param>
    public RequestForQuotationHeader(RequestForQuotationInformation information)
    {
        Information = information ?? throw new ArgumentNullException(nameof(information));
    }
    /// <summary>
    /// (optional) Control information<br/>
    /// <br/>
    /// Control information for the automatic processing of the business documents.
    /// </summary>
    [XmlElement("CONTROL_INFO")]
    public ControlInformation? ControlInformation { get; set; }

    /// <summary>
    /// (required) Request for quotation information<br/>
    /// <br/>
    /// Information about this business document.
    /// </summary>
    [XmlElement("RFQ_INFO")]
    public RequestForQuotationInformation Information { get; set; } = new RequestForQuotationInformation();
}
