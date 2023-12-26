using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Reference to the signature verifier)<br/>
/// <br/>
/// Reference to a unique identifier to the organization that verified the signature.<br/>
/// The element refers to a PARTY_ID in the same document.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class VerificationPartyIdRef : global::BMEcatSharp.PartyIdRefBase<VerificationPartyIdRef>
{
    /// <summary>
    /// <inheritdoc cref="VerificationPartyIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerificationPartyIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="VerificationPartyIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public VerificationPartyIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="VerificationPartyIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">The most common coding standards are predefined - see <see cref="BMEcatSharp.PartyTypeValues"/>.</param>
    public VerificationPartyIdRef(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) Coding standard<br/>
    /// <br/>
    /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.
    /// </summary>
    [XmlAttribute("type")]
    public override string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlText]
    public override string Value { get; set; }

    public static explicit operator global::BMEcatSharp.PartyId(VerificationPartyIdRef idRef)
    {
        if (idRef is null)
        {
            return null!;
        }

        return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
    }
}
