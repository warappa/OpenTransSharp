using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Allowance or surcharge value)<br/>
/// <br/>
/// Choice<br/>
/// <br/>
/// A description of the structure of the allowance or surcharge.<br/>
/// The type is defined in the related sub-element.<br/>
/// Both allowances and surcharges are positiv values.<br/>
/// The attribute ALLOW_OR_CHARGE --&gt; type indicates an allowance or surcharge and thus indicates an increase or decrease of the original amount.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class AllowOrChargeValue
{
    public static AllowOrChargeValue Percentage(decimal percentage)
    {
        return new AllowOrChargeValue
        {
            AocPercentageFactor = percentage
        };
    }

    public static AllowOrChargeValue MonetaryAmount(decimal monetaryAmount)
    {
        return new AllowOrChargeValue
        {
            AocMonetaryAmount = monetaryAmount
        };
    }

    public static AllowOrChargeValue Units(AocOrderUnitsCount units)
    {
        return new AllowOrChargeValue
        {
            AocOrderUnitsCount = units
        };
    }

    public static AllowOrChargeValue AdditionalItems(string text)
    {
        return new AllowOrChargeValue
        {
            AocAdditionalItems = text
        };
    }

    /// <summary>
    /// (required) Prozentual value<br/>
    /// <br/>
    /// The share of the product-value (factor) to determine the allowance or charge.<br/>
    /// <br/>The allowance or charge is calculated by multiply the AOC_PERCENTAGE_FACTOR by the (interim-)product-value which was calculated at this stage of the document.<br/>
    /// The currency is not different to the currency of the product-price.
    /// </summary>
    [XmlElement("AOC_PERCENTAGE_FACTOR")]
    public decimal? AocPercentageFactor { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AocPercentageFactorSpecified => AocPercentageFactor.HasValue;

    /// <summary>
    /// (required) Monetary amount<br/>
    /// <br/>
    /// The allowance or charge is defined via an absolut value.<br/>
    /// The currency is identical with the product price currency.
    /// </summary>
    [XmlElement("AOC_MONETARY_AMOUNT")]
    public decimal? AocMonetaryAmount { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AocMonetaryAmountSpecified => AocMonetaryAmount.HasValue;

    /// <summary>
    /// (required) Number of rebates in kind units<br/>
    /// <br/>
    /// Number of rebates or charge in kind units.
    /// </summary>
    [XmlElement("AOC_ORDER_UNITS_COUNT")]
    public AocOrderUnitsCount? AocOrderUnitsCount { get; set; }

    /// <summary>
    /// (required) Additional Items<br/>
    /// <br/>
    /// Declaration if additional items are dilivered.<br/>
    /// <br/>
    /// This field can is only permitted in case of be intended for other items than the items of the parent-product and -order-unit(ORDER_UNIT).<br/>
    /// In case of the same product the field AOC_ORDER_UNITS_COUNT has to be used.
    /// </summary>
    [XmlElement("AOC_ADDITIONAL_ITEMS")]
    public string? AocAdditionalItems { get; set; }
}
