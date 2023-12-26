namespace BMEcatSharp;

/// <summary>
/// (Identification of the group)<br/>
/// <br/>
/// This element contains the unique identification of the group within the classification system.<br/>
/// <br/>
/// Caution:<br/>
/// When transferring the eCl@ss classification system, this element has to be filled with the eCl@ss field 'idcl' (primary key). For example: AAA223001.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ClassificationGroupId
{
    /// <summary>
    /// <inheritdoc cref="ClassificationGroupId"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClassificationGroupId()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="ClassificationGroupId"/>
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public ClassificationGroupId(ClassificationGroupIdType type, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Type = type;
        Value = value;
    }

    /// <summary>
    /// (optional) Codification<br/>
    /// <br/>
    /// Determines whether the group ID describes the position of the respective group in the hierarchy.<br/>
    /// <br/>
    /// <see cref="ClassificationGroupIdType"/>
    /// </summary>
    [XmlAttribute("type")]
    public ClassificationGroupIdType Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 60
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
