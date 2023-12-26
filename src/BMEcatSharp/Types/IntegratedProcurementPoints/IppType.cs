using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="IppDefinition.Type"/>.
/// </summary>
public enum IppType
{
    /// <summary>
    /// Availability request<br/>
    /// <br/>
    /// This IPP application starts a request for availability information.
    /// </summary>
    [XmlEnum("availability_request")]
    AvailabilityRequest,
    /// <summary>
    /// External catalog<br/>
    /// <br/>
    /// This IPP application starts an external catalog.
    /// </summary>
    [XmlEnum("external_catalog")]
    ExternalCatalog,
    /// <summary>
    /// Price request<br/>
    /// <br/>
    /// This IPP application starts a request for price information.
    /// </summary>
    [XmlEnum("price_request")]
    PriceRequest,
    /// <summary>
    /// Product request<br/>
    /// <br/>
    /// This IPP application starts a request for product information and validation respectively.
    /// </summary>
    [XmlEnum("product_request")]
    ProductRequest,
    /// <summary>
    /// Request for quotation<br/>
    /// <br/>
    /// This IPP application starts a request for quotation.
    /// </summary>
    [XmlEnum("rfq")]
    RequestForQuotation
}
