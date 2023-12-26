namespace OpenTransSharp;

/// <summary>
/// (Logistics information)<br/>
/// <br/>
/// The element contains logistical details in document level (HEADER).<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class LogisticDetailsInformation
{
    /// <summary>
    /// <inheritdoc cref="LogisticDetailsInformation"/>
    /// </summary>
    public LogisticDetailsInformation() { }

    /// <summary>
    /// (optional) Country of origin<br/>
    /// <br/>
    /// Contains the country of origin of the product.<br/>
    /// By using a subdivision code it is possible to reference a region.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("COUNTRY_OF_ORIGIN")]
    public List<global::BMEcatSharp.CountryCode>? CountriesOfOrigins { get; set; } = new List<global::BMEcatSharp.CountryCode>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CountriesOfOriginsSpecified => CountriesOfOrigins?.Count > 0;

    /// <summary>
    /// (optional) Transport<br/>
    /// <br/>
    /// Information about the terms of transport.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TRANSPORT")]
    public List<global::BMEcatSharp.Transport>? Transports { get; set; } = new List<global::BMEcatSharp.Transport>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TransportsSpecified => Transports?.Count > 0;

    /// <summary>
    /// (optional) Packaging information <br/>
    /// <br/>
    /// Information according to the packaging .
    /// </summary>
    [OpenTransXmlArray("PACKAGE_INFO")]
    [OpenTransXmlArrayItem("PACKAGE")]
    public List<Package>? Packages { get; set; } = new List<Package>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PackagesSpecified => Packages?.Count > 0;

    /// <summary>
    /// (optional) Means of transport <br/>
    /// <br/>
    /// Means of transport with which the goods to be delivered are transported.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MEANS_OF_TRANSPORT")]
    public List<global::BMEcatSharp.MeansOfTransport>? MeansOfTransports { get; set; } = new List<global::BMEcatSharp.MeansOfTransport>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool MeansOfTransportsSpecified => MeansOfTransports?.Count > 0;
}
