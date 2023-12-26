using OpenTransSharp.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Signature verification information)<br/>
/// <br/>
/// The element is used to use signatures in openTRANS-documents.<br/>
/// The underlying XML-structure follows the data type SignatureType and the recommendation of the w3c (see also http://www.w3.org/TR/2002/REC-xmldsig-core-20020212/).<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class Verification
{
    /// <summary>
    /// <inheritdoc cref="Verification"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Verification()
    {
        PartyIdRef = null!;
        Report = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Verification"/>
    /// </summary>
    /// <param name="partyIdRef"></param>
    /// <param name="success"></param>
    /// <param name="report"></param>
    public Verification(VerificationPartyIdRef partyIdRef, bool success, VerificationReport report)
    {
        PartyIdRef = partyIdRef ?? throw new System.ArgumentNullException(nameof(partyIdRef));
        Success = success;
        Report = report ?? throw new System.ArgumentNullException(nameof(report));
    }

    /// <summary>
    /// (required) Reference to the signature verifier<br/>
    /// <br/>
    /// Reference to a unique identifier to the organization that verified the signature.<br/>
    /// The element refers to a PARTY_ID in the same document.
    /// </summary>
    [OpenTransXmlElement("VERIFICATION_PARTY_IDREF")]
    public VerificationPartyIdRef PartyIdRef { get; set; }

    /// <summary>
    /// (required) Verification result<br/>
    /// <br/>
    /// The element summarizes the result of the signature verification.<br/>
    /// A successful verification evaluates to 'true' otherwise to 'false'.
    /// </summary>
    [XmlIgnore]
    public bool Success { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [OpenTransXmlElement("VERIFICATION_SUCCESS")]
    public string SuccessForSerializer { get => Success == true ? "true" : "false"; set => Success = value.ToLowerInvariant() == "true" ? true : false; }

    /// <summary>
    /// (required) Verification report<br/>
    /// <br/>
    /// Report related to the verification of a signature.
    /// </summary>
    [OpenTransXmlElement("VERIFICATION_REPORT")]
    public VerificationReport Report { get; set; }
}
