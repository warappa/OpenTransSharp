namespace BMEcatSharp;

/// <summary>
/// (IPP input parameters)<br/>
/// <br/>
/// This element contains a list of input parameters that control the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppOutboundParams
{
    /// <summary>
    /// <inheritdoc cref="IppOutboundParams"/>
    /// </summary>
    public IppOutboundParams() { }

    /// <summary>
    /// (optional) IPP languages<br/>
    /// <br/>
    /// List of languages that are supported by the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_LANGUAGES")]
    public IppLanguages? Languages { get; set; } = new IppLanguages();

    /// <summary>
    /// (optional) IPP countries and regions<br/>
    /// <br/>
    /// List of languages that are supported by the IPP application<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_TERRITORIES")]
    public IppTerritories? Territories { get; set; }

    /// <summary>
    /// (optional) IPP currencies<br/>
    /// <br/>
    /// List of currencies that are supported by the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PRICE_CURRENCIES")]
    public IppPriceCurrencies? PriceCurrencies { get; set; }

    /// <summary>
    /// (optional) IPP price types<br/>
    /// <br/>
    /// List of price types that are supported by the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PRICE_TYPES")]
    public IppPriceTypes? PriceTypes { get; set; }

    /// <summary>
    /// (optional) IPP product ID<br/>
    /// <br/>
    /// Product identifier as input for the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_SUPPLIER_PID")]
    public IppSupplierPid? SupplierPid { get; set; }

    /// <summary>
    /// (optional) Reference to an IPP product configuration<br/>
    /// <br/>
    /// Reference to the unique identifier of a product configuration that is input for the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PRODUCTCONFIG_IDREF")]
    public IppProductconfigIdRef? ProductconfigIdRef { get; set; }

    /// <summary>
    /// (optional) Reference to an IPP shopping cart<br/>
    /// <br/>
    /// Specification if and how identifiers of product lists are used with an IPP application call.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PRODUCTLIST_IDREF")]
    public IppProductlistIdRef? ProductlistIdRef { get; set; }

    /// <summary>
    /// (optional) IPP user information<br/>
    /// <br/>
    /// Specification if and how user information are used with an IPP application call.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_USER_INFO")]
    public IppUserInfo? UserInfo { get; set; }

    /// <summary>
    /// (optional) IPP authentification information<br/>
    /// <br/>
    /// Specification if and how authentification information are used with an IPP application call.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_AUTHENTIFICATION_INFO")]
    public IppAuthentificationInfo? AuthentificationInfo { get; set; }

    /// <summary>
    /// (optional) Other IPP input parameters<br/>
    /// <br/>
    /// Specification if and how additional parameters have to be used in the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PARAM_DEFINITION")]
    public List<IppParamDefinition>? Definitions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DefinitionsSpecified => Definitions?.Count > 0;
}
