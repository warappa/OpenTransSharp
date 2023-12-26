namespace BMEcatSharp;

/// <summary>
/// (Feature group)<br/>
/// <br/>
/// This element specifies a feature group, e.g., "Dimensions" as a group for the features "width", "length", and "heigth".<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureGroup
{
    /// <summary>
    /// <inheritdoc cref="FeatureGroup"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public FeatureGroup()
    {
        Id = null!;
    }

    /// <summary>
    /// <inheritdoc cref="FeatureGroup"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    public FeatureGroup(string id, IEnumerable<MultiLingualString> name)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        Id = id;
        Name = name.ToList();
    }


    /// <summary>
    /// (required) Feature group ID<br/>
    /// <br/>
    /// Specifies the unique identification of the feature group within the classification system; this identification is required for referencing the feature group when defining a feature.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FT_GROUP_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (required) Feature group name<br/>
    /// <br/>
    /// Specifies the name of the feature group; e.g., "Technical features".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FT_GROUP_NAME")]
    public List<MultiLingualString>? Name { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NameSpecified => Name?.Count > 0;

    /// <summary>
    /// (optional) Feature group description<br/>
    /// <br/>
    /// This element can be used to describe the feature group in more detail.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FT_GROUP_DESCR")]
    public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;

    /// <summary>
    /// (optional) Parent group of the feature group<br/>
    /// <br/>
    /// This element references the unique identification of the parent group for the respective feature group (FT_GROUP_ID).<br/>
    /// If there is no parent group for the group, this element must not be used.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FT_GROUP_PARENT_ID")]
    public List<string>? ParentIds { get; set; } = new List<string>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ParentIdsSpecified => ParentIds?.Count > 0;
}
