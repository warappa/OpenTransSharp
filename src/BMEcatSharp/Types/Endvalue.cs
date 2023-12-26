using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (End value)<br/>
/// <br/>
/// This element sets the end value of the interval, thus the upper bound that is part of the interval.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Endvalue
{
    /// <summary>
    /// <inheritdoc cref="Endvalue"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Endvalue() { }

    /// <summary>
    /// <inheritdoc cref="Endvalue"/>
    /// </summary>
    /// <param name="value"></param>
    public Endvalue(decimal value)
    {
        Value = value;
    }

    /// <summary>
    /// (optional) Interval type<br/>
    /// <br/>
    /// This attribute indicates whether the value is part of the domain or not.
    /// </summary>
    [XmlIgnore]
    public Intervaltype? Intervaltype { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlAttribute("intervaltype")]
    public Intervaltype IntervaltypeForSerializer { get => Intervaltype ?? BMEcatSharp.Intervaltype.Undefined; set => Intervaltype = value; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IntervaltypeForSerializerSpecified => Intervaltype.HasValue;

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 20
    /// </summary>
    [XmlText]
    public decimal Value { get; set; }
}
