﻿namespace OpenTransSharp;

/// <summary>
/// (Reference to a final recipient)<br/>
/// <br/>
/// Reference to a unique identifier of the final recipient.<br/>
/// The element has to refer to a PARTY_ID in the same document.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class FinalDeliveryIdRef : global::BMEcatSharp.PartyIdRefBase<FinalDeliveryIdRef>
{
    /// <summary>
    /// <inheritdoc cref="FinalDeliveryIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FinalDeliveryIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="FinalDeliveryIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public FinalDeliveryIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined - see <see cref="BMEcatSharp.PartyTypeValues"/>. Custom values can also be used.</param>
    public FinalDeliveryIdRef(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined - see <see cref="BMEcatSharp.PartyTypeValues"/>. Custom values can also be used.<br/>
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

    public static explicit operator global::BMEcatSharp.PartyId(FinalDeliveryIdRef idRef)
    {
        if (idRef is null)
        {
            return null!;
        }

        return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
    }
}
