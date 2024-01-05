namespace BMEcatSharp;

/// <summary>
/// (Other IPP input parameters)<br/>
/// <br/>
/// This element is used to define if and how additional parameters have to be used in the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppParamDefinition : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppParamDefinition"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IppParamDefinition()
    {
        Name = null!;
    }

    /// <summary>
    /// <inheritdoc cref="IppParamDefinition"/>
    /// </summary>
    /// <param name="name"></param>
    public IppParamDefinition(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    /// <summary>
    /// (required) Parameter name<br/>
    /// <br/>
    /// Name of the parameter.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PARAM_NAME")]
    public string Name { get; set; }

    /// <summary>
    /// (optional) Description of the parameter<br/>
    /// <br/>
    /// This element is used to describe the parameter.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("IPP_PARAM_DESCR")]
    public List<MultiLingualString>? Description { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;
}
