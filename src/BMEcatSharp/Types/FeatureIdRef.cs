using System;
using System.ComponentModel;
using System.Xml.Serialization;
// TODO: recheck
namespace BMEcatSharp;

/// <summary>
/// Feature reference<br/>
/// <br/>
/// Reference to the unique ID of a feature (seeCLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureIdRef
{
    /// <summary>
    /// <inheritdoc cref="FeatureIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FeatureIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="FeatureIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public FeatureIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 60
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
