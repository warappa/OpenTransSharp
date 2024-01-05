namespace BMEcatSharp;

/// <summary>
/// <br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Language
{
    /// <summary>
    /// <inheritdoc cref="Language"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Language()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Language"/>
    /// </summary>
    /// <param name="value"></param>
    public Language(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="Language"/>
    /// </summary>
    /// <param name="value"></param>
    public Language(LanguageCodes value)
        : this(value.ToString())
    {
    }

    /// <summary>
    /// <inheritdoc cref="Language"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isDefault"></param>
    public Language(string value, bool isDefault)
        : this(value)
    {
        Default = isDefault;
    }

    /// <summary>
    /// <inheritdoc cref="Language"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="isDefault"></param>
    public Language(LanguageCodes value, bool isDefault)
        : this(value.ToString(), isDefault)
    {
    }

    /// <summary>
    /// (optional) Default flag<br/>
    /// <br/>
    /// This element determines the default language of all language-dependent information in the document.
    /// </summary>
    [XmlIgnore]
    public bool? Default { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlAttribute("default")]
    public string? DefaultForSerializer { get => Default is null ? null : Default == true ? "true" : "false"; set => Default = value is null ? null : value.ToLowerInvariant() == "true"; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DefaultForSerializerSpecified => Default == true;

    /// <summary>
    /// (required)
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
