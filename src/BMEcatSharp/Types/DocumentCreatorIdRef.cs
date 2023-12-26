namespace BMEcatSharp;

/// <summary>
/// (Document creator)<br/>
/// <br/>
/// This element contains a reference to the document creator.<br/>
/// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class DocumentCreatorIdRef
{
    /// <summary>
    /// <inheritdoc cref="DocumentCreatorIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DocumentCreatorIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="DocumentCreatorIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public DocumentCreatorIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.</param>
    public DocumentCreatorIdRef(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) ID type Coding standard<br/>
    /// <br/>
    /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined.<br/>
    /// <br/>
    /// See <see cref="PartyTypeValues"/>.
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
