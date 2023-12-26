[assembly: InternalsVisibleTo("OpenTransSharp")]

namespace BMEcatSharp;

public class MultiLingualString
{
    /// <summary>
    /// <inheritdoc cref="MultiLingualString"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiLingualString()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="MultiLingualString"/>
    /// </summary>
    /// <param name="value"></param>
    public MultiLingualString(string value)
    {
        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="MultiLingualString"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="language"></param>
    public MultiLingualString(string value, LanguageCodes language)
    {
        Value = value;
        Language = language;
    }

    [XmlAttribute("lang")]
    public LanguageCodes Language { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool LanguageSpecified => Language != LanguageCodes.Undefined;

    /// <summary>
    /// (required)
    /// </summary>
    [XmlText]
    public string Value { get; set; }

    public static implicit operator MultiLingualString(string value)
    {
        return new MultiLingualString(value);
    }
}
