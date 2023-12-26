namespace OpenTransSharp;

/// <summary>
/// <br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class DocumentRecipientIdRef : global::BMEcatSharp.PartyIdRefBase<DocumentRecipientIdRef>
{
    /// <summary>
    /// <inheritdoc cref="DocumentRecipientIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DocumentRecipientIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="DocumentRecipientIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public DocumentRecipientIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="DocumentRecipientIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined - see <see cref="BMEcatSharp.PartyTypeValues"/>. Custom values can also be used.</param>
    public DocumentRecipientIdRef(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// The most common coding standards are predefined - see <see cref="BMEcatSharp.PartyTypeValues"/>. Custom values can also be used.<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlAttribute("type")]
    public override string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlText]
    public override string Value { get; set; }

    public static explicit operator global::BMEcatSharp.PartyId(DocumentRecipientIdRef idRef)
    {
        if (idRef is null)
        {
            return null!;
        }

        return new global::BMEcatSharp.PartyId(idRef.Value, idRef.Type);
    }
}
