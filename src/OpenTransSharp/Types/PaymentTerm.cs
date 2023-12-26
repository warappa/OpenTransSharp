using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// <br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class PaymentTerm
{
    /// <summary>
    /// <inheritdoc cref="PaymentTerm"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PaymentTerm()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="PaymentTerm"/>
    /// </summary>
    /// <param name="value"></param>
    public PaymentTerm(string value)
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
    /// <param name="type">For predefined values see <see cref="PaymentTermTypeValues"/>. Custom values can be used.</param>
    public PaymentTerm(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) Term of payment.<br/>
    /// <br/>
    /// <br/>Procedure according to which the term of payment is coded.<br/>
    /// <br/>
    /// For predefined values see <see cref="PaymentTermTypeValues"/>. Custom values can be used.
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
