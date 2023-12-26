using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Reference to IPP provider)<br/>
/// <br/>
/// This element provides a reference to the IPP provider.The reference must point to an existing PARTY_ID.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppOperatorIdRef : PartyIdRefBase<IppOperatorIdRef>
{
    /// <summary>
    /// <inheritdoc cref="IppOperatorIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IppOperatorIdRef() { }

    /// <summary>
    /// <inheritdoc cref="IppOperatorIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public IppOperatorIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="IppOperatorIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.</param>
    public IppOperatorIdRef(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) Coding standard<br/>
    /// <br/>
    /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.
    /// </summary>
    [XmlAttribute("type")]
    public override string? Type { get => base.Type; set => base.Type = value; }

    /// <summary>
    /// (required) Dieses Element enthält einen Verweis auf einen IPP-Anbieter.<br/>
    /// <br/>
    /// Der Verweis muss auf eine zuvor definierte PARTY_ID zeigen.
    /// regex: .{1,250}
    /// </summary>
    [XmlText]
    public override string Value { get => base.Value; set => base.Value = value; }
}
