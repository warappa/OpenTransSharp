using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Bank code)<br/>
/// <br/>
/// Bank identification number; the attribute "type" indicates the coding of this number.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class BankCode
{
    /// <summary>
    /// <inheritdoc cref="BankCode"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BankCode()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="BankCode"/>
    /// </summary>
    /// <param name="value"></param>
    public BankCode(string value)
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
    /// <param name="type">For predefined values see <see cref="BankCodeTypeValues"/>.<br/>
    /// Custom values can also be used.</param>
    public BankCode(string value, string? type)
        : this(value)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
        }

        Type = type;
    }

    /// <summary>
    /// (optional) Coding of the bank identification number<br/>
    /// <br/>
    /// The attribute indicates the coding of the bank code<br/>
    /// <br/>
    /// Max length: 20
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 50
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
