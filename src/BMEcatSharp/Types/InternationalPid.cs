namespace BMEcatSharp;

/// <summary>
/// (International product number)<br/>
/// <br/>
/// This element contains an international product number (e.g., EAN).<br/>
/// The underlying standard respectively organisation is given in the 'type' attribute.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class InternationalPid
{
    /// <summary>
    /// <inheritdoc cref="InternationalPid"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public InternationalPid()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="InternationalPid"/>
    /// </summary>
    /// <param name="value"></param>
    public InternationalPid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="InternationalPid"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">Specification of the underlying standard respectively organisation.<br/>
    /// <br/>
    /// See <see cref="InternationalPidTypeValues"/></param>
    public InternationalPid(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional)<br/>
    /// <br/>
    /// Specification of the underlying standard respectively organisation.
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 100
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
