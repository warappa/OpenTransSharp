using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp;

/// <summary>
/// (Predefined configuration)<br/>
/// <br/>
/// This element allows the specification of a predefined configuration.<br/>
/// These represent a product which has been specified with a full pass through all configuration steps with choosing or entering the different values.<br/>
/// The configuration or oredr code which has been assembled througout the pass identifies the predefined configuration (PREDEFINED_CONFIG_CODE).<br/>
/// By this means it is possible to present different standard configurations to the user, to describe them and to assign special prices and product numbers.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class PredefinedConfiguration
{
    /// <summary>
    /// <inheritdoc cref="PredefinedConfiguration"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PredefinedConfiguration()
    {
        Code = null!;
    }

    /// <summary>
    /// <inheritdoc cref="PredefinedConfiguration"/>
    /// </summary>
    /// <param name="code"></param>
    public PredefinedConfiguration(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException($"'{nameof(code)}' cannot be null or whitespace.", nameof(code));
        }

        Code = code;
    }

    /// <summary>
    /// (required) Configuration code<br/>
    /// <br/>
    /// The configuration code (or order code) contains the product number (SUPPLIER_PID) and the configuration codes (CONFIG_CODE) of all configuration steps and their values selected or entered in the predefined configuration process.<br/>
    /// The configuration code represents a fully configured product and is therefore identical with the configuration string which is built up during a identical manual configuration.It is the uique identifier for the element PREDEFINED_CONFIG.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG_CODE")]
    public string Code { get; set; }

    /// <summary>
    /// (optional) Name of the configuration<br/>
    /// <br/>
    /// This element is used to specify the name of the predefined product (e.g. standard laptop or laptop high end model).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG_NAME")]
    public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (optional) Description of the configuration<br/>
    /// <br/>
    /// This element is used to decribe the predefined product in detail (e.g. equipment or application range of the product).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG_DESCR")]
    public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;

    /// <summary>
    /// (optional) Configuration order<br/>
    /// <br/>
    /// Order in which the predefined configurations are represented in the target system.<br/>
    /// <br/>
    /// If the predefined configurations are listed they are listed in ascending order (the first predefined configuration corresponds to the PREDEFINED_CONFIG_ORDER with the lowest number).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG_ORDER")]
    public int? Order { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderSpecified => Order.HasValue;

    /// <summary>
    /// (optional) Price details<br/>
    /// <br/>
    /// Price information for the product.<br/>
    /// In this context the element is used to specify the price of the predefined configuration.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
    public ProductPriceDetails? ProductPriceDetails { get; set; }

    /// <summary>
    /// (optional) Supplier's product ID<br/>
    /// <br/>
    /// This element contains the product number issued by the supplier.<br/>
    /// It is determining for ordering the product; it identifies the product in the supplier catalog.<br/>
    /// In multi-supplier catalogs, however, only the combination of SUPPLIER_PID and SUPPLIER_IDREF identifies a product.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Some target systems are not able to accept all 32 characters (e.g., SAP max. 18 characters).<br/>
    /// It is therefore advisable to keep product identifications as short as possible.<br/>
    /// <br/>
    /// Are there different product variants (VARIANTS) the final product number is built via the concatenation of the (base) product number (SUPPLIER_PID) with the related product numbers supplements (SUPPLIER_AID_SUPPLEMENT).<br/>
    /// <br/>
    /// Caution:<br/>
    /// The (base) product number has to be distinct on its own even when variants or configurations are used.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_PID")]
    public SupplierPid? SupplierPid { get; set; }

    /// <summary>
    /// (optional - choice InternationPids/(obsolete)Ean) International product number<br/>
    /// <br/>
    /// Indicates an international product number (e.g., EAN).<br/>
    /// The underlying standard respectively organisation is given in the 'type' attribute.
    /// </summary>
    [BMEXmlElement("INTERNATIONAL_PID")]
    public List<InternationalPid>? InternationalPids { get; set; } = new List<InternationalPid>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool InternationalPidsSpecified => InternationalPids?.Count > 0;
}
