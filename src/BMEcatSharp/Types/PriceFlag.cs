using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Price flag)<br/>
/// <br/>
/// This element is used to specify the base of a price (e.g.with/without freight).<br/>
/// Where these fields have not been filled out, no statement on the various components of the price base will be made.<br/>
/// <br/>
/// Example:<br/>
/// &lt;PRICE_FLAG type="incl_freight"&gt;true&lt;/PRICE_FLAG&gt; means that freight costs are included in the related price.<br/>
/// &lt;PRICE_FLAG type="incl_freight"&gt;false&lt;/PRICE_FLAG&gt; means that the freight costs are not included in the related price.<br/>
/// <br/>
/// Where the element PRICE_FLAG does not occur with the attribute "incl_freight", there is no indication of whether the prices are with or without freight.<br/>
/// This must therefore be stipulated elsewhere (e.g. in the skeleton agreement).
/// </summary>
public class PriceFlag
{
    /// <summary>
    /// <inheritdoc cref="PriceFlag"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PriceFlag()
    {
        Type = null!;
    }

    /// <summary>
    /// <inheritdoc cref="PriceFlag"/>
    /// </summary>
    /// <param name="type">This attribute specifies the pool of costs which have an indication of whether or not they contribute to
    /// price formation. See <see cref="PriceFlagTypes"/>.<br/></param>
    /// <param name="value"></param>
    public PriceFlag(string type, bool value)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
        }

        Value = value;
        Type = type;
    }

    /// <summary>
    /// (required) Type of costs includes<br/>
    /// <br/>
    /// This attribute specifies the pool of costs which have an indication of whether or not they contribute to price formation. See <see cref="PriceFlagTypes"/>. Custom values can be used.<br/>
    /// <br/>
    /// Max length: 20
    /// </summary>
    [XmlAttribute("type")]
    public string Type { get; set; }

    /// <summary>
    /// (required)
    /// </summary>
    [XmlIgnore]
    public bool Value { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlText]
    public string ValueForSerializer { get => Value == true ? "true" : "false"; set => Value = value.ToLowerInvariant() == "true" ? true : false; }
}
