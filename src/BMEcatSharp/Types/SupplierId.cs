﻿namespace BMEcatSharp;

/// <summary>
/// (Supplier ID)<br/>
/// <br/>
/// This element contains the unique identifier of the supplier, which can be used by the buyer for internal processes; the "type" attribute determines the ID type.<br/>
/// This element will not be used in the future.
/// </summary>
//[Obsolete("This element will not be used in the future.")]
public class SupplierId
{
    /// <summary>
    /// <inheritdoc cref="SupplierId"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SupplierId()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="SupplierId"/>
    /// </summary>
    /// <param name="value"></param>
    public SupplierId(string value)
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
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.</param>
    public SupplierId(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) ID type Coding standard<br/>
    /// <br/>
    /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
