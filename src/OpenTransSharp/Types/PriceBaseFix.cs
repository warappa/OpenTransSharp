namespace OpenTransSharp;

/// <summary>
/// (Fixed price base)<br/>
/// <br/>
/// The element specifies on how the price is calculated based on the price-base.<br/>
/// The calculation relies on the price-factor, the price-unit and the amount/number of supplied price-units.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class PriceBaseFix
{
    /// <summary>
    /// <inheritdoc cref="PriceBaseFix"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PriceBaseFix()
    {
    }

    /// <summary>
    /// <inheritdoc cref="PriceBaseFix"/>
    /// </summary>
    /// <param name="unitValue"></param>
    /// <param name="unit"></param>
    public PriceBaseFix(decimal unitValue, BMEcatSharp.PackageUnit unit)
    {
        UnitValue = unitValue;
        Unit = unit;
    }

    /// <summary>
    /// (required) Number of price units<br/>
    /// <br/>
    /// Number of supplied price units.<br/>
    /// <br/>
    /// In the case of product prices not related to an order unit the total price of an item-line (PRICE_LINE_AMOUNT) is calculated using a price unit.<br/>
    /// Then the calculation of the total price of an item-line is the result of the multiplication of PRICE_UNIT_VALUE and PRICE_AMOUNT.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [OpenTransXmlElement("PRICE_UNIT_VALUE")]
    public decimal UnitValue { get; set; }

    /// <summary>
    /// (required) Price unit<br/>
    /// <br/>
    /// Unit of measurement on which the price is calculated.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRICE_UNIT")]
    public BMEcatSharp.PackageUnit Unit { get; set; }

    /// <summary>
    /// (optional) Price unit factor<br/>
    /// <br/>
    /// The price factor is the conversion factor for price unit and order unit.<br/>
    /// <br/>
    /// The underlying formula is: PRICE_UNIT equals PRICE_UNIT_FACTOR * ORDER_UNIT.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRICE_UNIT_FACTOR")]
    public decimal? UnitFactor { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool UnitFactorSpecified => UnitFactor.HasValue;
}
