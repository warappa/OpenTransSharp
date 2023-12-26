using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Data type restriction)<br/>
/// <br/>
/// This element defines a restriction on a data type, e.g., maximum length of a character string.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureFacet
{
    /// <summary>
    /// <inheritdoc cref="FeatureFacet"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FeatureFacet()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="FeatureFacet"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    public FeatureFacet(string value, FeatureFacetType type)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Type = type;
        Value = value;
    }

    /// <summary>
    /// (required) Restriction type<br/>
    /// <br/>
    /// This attribute contains the type of the restriction.
    /// </summary>
    [XmlAttribute("type")]
    public FeatureFacetType Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 20
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
