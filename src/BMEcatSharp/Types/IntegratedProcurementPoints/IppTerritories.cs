﻿namespace BMEcatSharp;

/// <summary>
/// (IPP countries and regions)<br/>
/// <br/>
/// This element contais a list of languages that are supported by the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppTerritories : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppTerritories"/>
    /// </summary>
    public IppTerritories() { }

    /// <summary>
    /// (optional) Territory<br/>
    /// <br/>
    /// Territory (i.e. country, state, region) coded according to ISO 3166.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TERRITORY")]
    public List<CountryCode>? Territories { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TerritoriesSpecified => Territories?.Count > 0;
}
