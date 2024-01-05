namespace BMEcatSharp;

/// <summary>
/// (Group source)<br/>
/// <br/>
/// This element provides information on the source of the definition that is given in CLASSIFICATION_GROUP_DESCR, e.g., a reference to a standard.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ClassificationGroupSource
{
    /// <summary>
    /// <inheritdoc cref="ClassificationGroupSource"/>
    /// </summary>
    public ClassificationGroupSource() { }

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
    /// (optional) Reference to a business partner.<br/>
    /// <br/>
    /// Reference to a business partner.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
    /// In this context the element is used to reference the organisation which is responsible for the specification of the element.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PARTY_IDREF")]
    public PartyIdRef? PartyIdRef { get; set; }
}
