﻿namespace BMEcatSharp;

/// <summary>
/// (Feature source)<br/>
/// <br/>
/// This element contains the source for the feature definition which has been given in the FT_DESCR element; e.g.a reference to a document, standard or definition describing the feature.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureSource
{
    /// <summary>
    /// <inheritdoc cref="FeatureSource"/>
    /// </summary>
    public FeatureSource() { }

    /// <summary>
    /// (optional) Source description<br/>
    /// <br/>
    /// Description of the source, e.g., the name of the document or standard.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SOURCE_NAME")]
    public List<MultiLingualString>? Name { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (optional) URI of the source<br/>
    /// <br/>
    /// URI of the source, e.g., pointing to the document or standard.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SOURCE_URI")]
    public string? Uri { get; set; }

    /// <summary>
    /// (optional) Reference to a business partner<br/>
    /// <br/>
    /// Reference to a business partner.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
    /// <br/>
    /// In this context the element is used to reference the organisation which is responsible for the specification of the element.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PARTY_IDREF")]
    public PartyIdRef? PartyIdRef { get; set; }
}
