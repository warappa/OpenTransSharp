﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (ID of the buying company - deprecated)<br/>
/// <br/>
/// This element contains the unique number of the buying company; the optional attribute "type" determines the type of ID.<br/>
/// This element will not be used in the future.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
//[Obsolete("This element will not be used in the future.")]
public class BuyerId
{
    /// <summary>
    /// <inheritdoc cref="BuyerId"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BuyerId()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="BuyerId"/>
    /// </summary>
    /// <param name="value"></param>
    public BuyerId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="BuyerId"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.</param>
    public BuyerId(string value, string? type)
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
    //[Obsolete("This element will not be used in the future.")]
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    //[Obsolete("This element will not be used in the future.")]
    [XmlText]
    public string Value { get; set; }
}
