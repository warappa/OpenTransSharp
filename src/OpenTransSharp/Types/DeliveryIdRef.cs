using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Reference to final recipient)<br/>
/// <br/>
/// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
/// The element has to refer to a PARTY_ID in the same document.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class DeliveryIdRef : global::BMEcatSharp.PartyIdRefBase<DeliveryIdRef>
{
    /// <summary>
    /// <inheritdoc cref="DeliveryIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DeliveryIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="DeliveryIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public DeliveryIdRef(string value)
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
    public DeliveryIdRef(string value, string? type)
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

    public static explicit operator global::BMEcatSharp.PartyId(DeliveryIdRef idRef)
    {
        if (idRef is null)
        {
            return null!;
        }

        return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
    }
}
