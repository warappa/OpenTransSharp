namespace OpenTransSharp;

/// <summary>
/// (Manufacturer information)<br/>
/// <br/>
/// The element MANUFACTURER_INFO contains information assigned to the article by the manufacturer.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class ManufacturerInformation
{
    /// <summary>
    /// <inheritdoc cref="ManufacturerInformation"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ManufacturerInformation()
    {
        IdRef = null!;
        ProductId = null!;
    }

    /// <summary>
    /// <inheritdoc cref="ManufacturerInformation"/>
    /// </summary>
    /// <param name="idRef"></param>
    /// <param name="productId"></param>
    public ManufacturerInformation(BMEcatSharp.ManufacturerIdRef idRef, string productId)
    {
        if (string.IsNullOrWhiteSpace(productId))
        {
            throw new ArgumentException($"'{nameof(productId)}' cannot be null or whitespace.", nameof(productId));
        }

        IdRef = idRef ?? throw new ArgumentNullException(nameof(idRef));
        ProductId = productId;
    }

    /// <summary>
    /// (required) Reference to the manufacturer<br/>
    /// <br/>
    /// This element provides a reference to the manufacturer.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_IDREF")]
    public global::BMEcatSharp.ManufacturerIdRef IdRef { get; set; }

    /// <summary>
    /// (required) Product ID of the manufacturer<br/>
    /// <br/>
    /// Product ID of the manufacturer.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_PID")]
    public string ProductId { get; set; }

    /// <summary>
    /// (optional) Manufacturer type description<br/>
    /// <br/>
    /// The manufacturer’s type description is a name for the product which may, in certain circumstances, be more widely-known than the correct product name.<br/>
    /// When a manufacturer’s type description is specified, the name of the manufacturer must also be specified (MANUFACTURER_NAME).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MANUFACTURER_TYPE_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? TypeDescriptions { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TypeDescriptionsSpecified => TypeDescriptions?.Count > 0;
}
