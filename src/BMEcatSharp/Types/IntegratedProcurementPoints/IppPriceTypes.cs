namespace BMEcatSharp;

/// <summary>
/// (IPP price types)<br/>
/// <br/>
/// This element contains a list of price types that are supported by the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppPriceTypes : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppPriceTypes"/>
    /// </summary>
    public IppPriceTypes() { }

    /// <summary>
    /// (optional) Price type<br/>
    /// <br/>
    /// This element determines the default price type for all products.<br/>
    /// The default price type can be replaced (or set) on the product level by the PRODUCT_PRICE --&gt; price_type attribute.<br/>
    /// <br/>
    /// See <see cref="ProductPriceTypeValues"/>.
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRICE_TYPE")]
    public List<string>? PriceTypes { get; set; } = new List<string>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PriceTypesSpecified => PriceTypes?.Count > 0;
}
