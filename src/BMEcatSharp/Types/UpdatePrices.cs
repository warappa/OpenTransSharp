﻿namespace BMEcatSharp;

/// <summary>
/// (Transaction area 'price update')<br/>
/// <br/>
/// This transaction transfers new price information on products to the target system.<br/>
/// All prices on the corresponding products already in the target system are deleted and replaced with the new prices.<br/>
/// Essentially, the transaction consists of the SUPPLIER_PID and PRODUCT_PRICE_DETAILS elements.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class UpdatePrices
{
    /// <summary>
    /// <inheritdoc cref="UpdatePrices"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public UpdatePrices() { }

    public UpdatePrices(int previousVersion, IEnumerable<UpdatePricesProduct> products)
    {
        if (products is null)
        {
            throw new ArgumentNullException(nameof(products));
        }

        PreviousVersion = previousVersion;
        Products = products.ToList();
    }

    /// <summary>
    /// (required) No of previous updates<br/>
    /// <br/>
    /// This attribute contains the number of previous updates or the number of the transferred updates (not the last version number).<br/>
    /// Counting begins at <b>0</b> after each T_NEW_CATALOG within the same version.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlAttribute("prev_version")]
    public int PreviousVersion { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PreviousVersionSpecified => PreviousVersion != 0;

    /// <summary>
    /// (optional) Dictionary of formulas<br/>
    /// <br/>
    /// List of formulas that are specified in the document header.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("FORMULAS")]
    [BMEXmlArrayItem("FORMULA")]
    public List<Formula>? Formulas { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FormulasSpecified => Formulas?.Count > 0;

    /// <summary>
    /// (required) Product<br/>
    /// <br/>
    /// Information about a product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PRODUCT")]
    public List<UpdatePricesProduct>? Products { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ProductsSpecified => Products?.Count > 0;

    /// <summary>
    /// (required - deprecated) Article<br/>
    /// <br/>
    /// Information about a product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("This element has been replaced by the PRODUCT in context T_UPDATE_PRICES element.")]
    [BMEXmlElement("ARTICLE")]
    public List<UpdatePricesArticle>? Articles { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ArticlesSpecified => Articles?.Count > 0;
}
