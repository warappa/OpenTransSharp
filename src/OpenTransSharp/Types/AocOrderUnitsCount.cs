using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Number of rebates in kind units)<br/>
/// <br/>
/// The number of rebates or charges in kind units indicates the number of units which are delivered for free.<br/>
/// The attribute AOC_ORDER_UNITS_COUNT -->type indicates a bonus or an additional charge.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class AocOrderUnitsCount
{
    /// <summary>
    /// <inheritdoc cref="AocOrderUnitsCount"/>
    /// </summary>
    public AocOrderUnitsCount() { }

    /// <summary>
    /// <inheritdoc cref="AocOrderUnitsCount"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    public AocOrderUnitsCount(decimal value, AocOrderUnitsCountType type)
    {
        Value = value;
        Type = type;
    }
    /// <summary>
    /// (required) Type of the rebate in kind<br/>
    /// <br/>
    /// Indicates a bonus or an additional unit.
    /// </summary>
    [XmlAttribute("type")]
    public AocOrderUnitsCountType Type { get; set; }

    /// <summary>
    /// (required)
    /// </summary>
    [XmlText]
    public decimal Value { get; set; }
}
