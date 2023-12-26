namespace OpenTransSharp;

/// <summary>
/// (Means of transport)<br/>
/// <br/>
/// Means of transport with which the goods to be delivered are transported.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class MeansOfTransportIdRef
{
    /// <summary>
    /// <inheritdoc cref="MeansOfTransportIdRef"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public MeansOfTransportIdRef()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="MeansOfTransportIdRef"/>
    /// </summary>
    /// <param name="value"></param>
    public MeansOfTransportIdRef(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 50
    /// </summary>
    [XmlText]
    public string Value { get; set; }
}
