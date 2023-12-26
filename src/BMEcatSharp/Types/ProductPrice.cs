namespace BMEcatSharp;

/// <summary>
/// (Product price)<br/>
/// <br/>
/// This element defines a price for the product.
/// </summary>
public class ProductPrice
{
    /// <summary>
    /// <inheritdoc cref="ProductPrice"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ProductPrice()
    {
        Type = null!;
    }

    /// <summary>
    /// <inheritdoc cref="ProductPrice"/>
    /// </summary>
    /// <param name="type"></param>
    public ProductPrice(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
        }

        Type = type;
    }

    /// <summary>
    /// (required) Price type<br/>
    /// <br/>
    /// Attribute which specifies the type of price.<br/>
    /// See <see cref="ProductPriceTypeValues"/>.
    /// </summary>
    [XmlAttribute("price_type")]
    public string Type { get; set; }

    /// <summary>
    /// (optional) Price amount<br/>
    /// <br/>
    /// Amount of the price.
    /// </summary>
    [BMEXmlElement("PRICE_AMOUNT")]
    public decimal? Amount { get; set; }
    public bool AmountSpecified => Amount.HasValue;

    /// <summary>
    /// (optional) Price formula<br/>
    /// <br/>
    /// Formel for price calculation.
    /// </summary>
    [BMEXmlElement("PRICE_FORMULA")]
    public PriceFormula? Formula { get; set; }

    /// <summary>
    /// (optional) Price currency<br/>
    /// <br/>
    /// Currency of the price.<br/>
    /// If nothing is specified in this field, the currency defined in the document header (HEADER) in the element CURRENCY is used for all prices.
    /// </summary>
    [BMEXmlElement("PRICE_CURRENCY")]
    public string? Currency { get; set; }

    /// <summary>
    /// (optional) Tax details<br/>
    /// <br/>
    /// Specification of one applicapable tax.
    /// </summary>
    [BMEXmlElement("TAX_DETAILS")]
    public List<TaxDetails>? TaxDetails { get; set; } = new List<TaxDetails>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TaxDetailsSpecified => TaxDetails?.Count > 0;

    /// <summary>
    /// (optional) Tax rate<br/>
    /// <br/>
    /// Factor for tax applicable to this price.<br/>
    /// Example: "0.16", corresponds to 16 percent.
    /// </summary>
    [BMEXmlElement("TAX")]
    public decimal? Tax { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TaxSpecified => Tax.HasValue;

    /// <summary>
    /// (optional) Price factor<br/>
    /// <br/>
    /// The (discount) factor always multiplied by the price specified in this element in order to determine the end price.<br/>
    /// The value of this element overwrites the default price factor, if such a default has been defined in the context of CATALOG.
    /// </summary>
    [BMEXmlElement("PRICE_FACTOR")]
    public decimal? Factor { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FactorSpecified => Factor.HasValue;

    /// <summary>
    /// (optional) Lower quantity bound<br/>
    /// <br/>
    /// Lower quantity limit for graduated prices.<br/>
    /// The unit for the graduated price limit is the order unit(ORDER_UNIT).<br/>
    /// <br/>
    /// Note: the upper graduated price limit is determined by the LOWER_BOUND value of the next price.<br/>
    /// If there are no more graduations, the price applies to all quantities which are higher than the lower graduated price limit.
    /// </summary>
    [BMEXmlElement("LOWER_BOUND")]
    public decimal? LowerBound { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool LowerBoundSpecified => LowerBound.HasValue;

    /// <summary>
    /// (optional) Territory<br/>
    /// <br/>
    /// Territory (i.e. country, state, region) coded according to ISO 3166.<br/>
    /// <br/>
    /// The element specifies in which territories (regions, states, countries, continents) the prices are vaild which means that the products from the catalog are available.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TERRITORY")]
    public List<CountryCode>? Territories { get; set; } = new List<CountryCode>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TerritoriesSpecified => Territories?.Count > 0;

    /// <summary>
    /// (optional) Area references<br/>
    /// <br/>
    /// List of references to areas.<br/>
    /// <br/>
    /// Areas, where the prices are valid which means that the products from the catalog are available.
    /// </summary>
    [BMEXmlArray("AREA_REFS")]
    [BMEXmlArrayItem("AREA_IDREF")]
    public List<string>? AreaRefs { get; set; } = new List<string>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreaRefsSpecified => AreaRefs?.Count > 0;

    /// <summary>
    /// (optional) Price base<br/>
    /// <br/>
    /// Contains the price basis consisting of price unit and price factor, it defines the basis of a price.
    /// </summary>
    [BMEXmlElement("PRICE_BASE")]
    public PriceBase? Base { get; set; }

    /// <summary>
    /// (optional) Price flag<br/>
    /// <br/>
    /// Base of a price (e.g. with/without freight).
    /// </summary>
    [XmlElement("PRICE_FLAG")]
    public List<PriceFlag>? PriceFlags { get; set; } = new List<PriceFlag>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PriceFlagsSpecified => PriceFlags?.Count > 0;
}
