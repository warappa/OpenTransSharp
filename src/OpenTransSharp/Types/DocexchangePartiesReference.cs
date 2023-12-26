using OpenTransSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace OpenTransSharp;

/// <summary>
/// (Document exchange parties)<br/>
/// <br/>
/// The element contains references to the partners woh take part in the document exchange.<br/>
/// <br/>
/// The first case to use this element is when various parties like intermediators, market-places or service providers are involved in parts of the processing (especially in the case of a centralized settlement). The second case is the usage of business documents which appear in different forms where the document-flow changes.<br/>
/// <br/>
/// Example:<br/>
/// In the case of a payment advice the roles do not specify if the payer sends the document to explain a remittance or the remittee sends the document to explain a direct debit.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class DocexchangePartiesReference
{
    /// <summary>
    /// <inheritdoc cref="DocexchangePartiesReference"/>
    /// </summary>
    public DocexchangePartiesReference() { }

    /// <summary>
    /// (optional) Reference to the document issuer<br/>
    /// <br/>
    /// The element refers to a unique identifier of the initiator or issuer of the business document.<br/>
    /// The element refers to a PARTY_ID in the same document.
    /// </summary>
    [OpenTransXmlElement("DOCUMENT_ISSUER_IDREF")]
    public DocumentIssuerIdRef? DocumentIssuerIdRef { get; set; }

    /// <summary>
    /// (optional) Reference to the document recipient<br/>
    /// <br/>
    /// The element refers to a unique identifier of the recipient of the business document.<br/>
    /// The element refers to a PARTY_ID in the same document.
    /// </summary>
    [OpenTransXmlElement("DOCUMENT_RECIPIENT_IDREF")]
    public List<DocumentRecipientIdRef>? DocumentRecipientIdRefs { get; set; } = new List<DocumentRecipientIdRef>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DocumentRecipientIdRefsSpecified => DocumentRecipientIdRefs?.Count > 0;
}
