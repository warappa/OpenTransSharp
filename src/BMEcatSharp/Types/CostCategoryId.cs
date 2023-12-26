namespace BMEcatSharp;

/// <summary>
/// (Cost category)<br/>
/// <br/>
/// Number of the cost center to be charged or the project or work order to which the charge must be made.<br/>
/// The type of cost category is fixed by the attribute "type".<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class CostCategoryId
{
    /// <summary>
    /// <inheritdoc cref="CostCategoryId"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public CostCategoryId()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="CostCategoryId"/>
    /// </summary>
    /// <param name="value"></param>
    public CostCategoryId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="CostCategoryId"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    public CostCategoryId(string value, CostCategoryIdType type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) Type of cost category <br/>
    /// <br/>
    /// It is specified here whether the costs are to be charged to a cost center, project or work order.<br/>
    /// If the attribute is not used no exact specification is made.
    /// </summary>
    [XmlAttribute("type")]
    public CostCategoryIdType Type { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TypeSpecified => Type != CostCategoryIdType.Undefined;

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 64
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
