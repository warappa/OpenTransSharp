namespace OpenTransSharp;

/// <summary>
/// (Fixed allowance or surcharges)<br/>
/// <br/>
/// A list of fixed allowances or surcharges which are to be applied on the price.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class AllowOrChargesFix
{
    /// <summary>
    /// <inheritdoc cref="AllowOrChargesFix"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AllowOrChargesFix() { }

    /// <summary>
    /// <inheritdoc cref="AllowOrChargesFix"/>
    /// </summary>
    /// <param name="list"></param>
    public AllowOrChargesFix(IEnumerable<AllowOrCharge> list)
    {
        if (list is null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        List = list.ToList();
    }
    /// <summary>
    /// (required) Fixed charge or allowance<br/>
    /// <br/>
    /// Description of a fixed surcharge or allowance. Please notice the usage-advice at ALLOW_OR_CHARGE.
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE")]
    public List<AllowOrCharge> List { get; set; } = [];

    /// <summary>
    /// (optional) Total amount of the allowances and surcharges<br/>
    /// <br/>
    /// Sum of all allowances and surcharges which lead to a monetary amount.<br/>
    /// Only those allowances and surcharges are considered which have a real amount(AOC_MONETARY_AMOUNT) in ALLOW_OR_CHARGE_VALUE or can be calculated via a percentage(AOC_PERCENTAGE_FACTOR).
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGES_TOTAL_AMOUNT")]
    public decimal? TotalAmount { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TotalAmountSpecified => TotalAmount.HasValue;

}
