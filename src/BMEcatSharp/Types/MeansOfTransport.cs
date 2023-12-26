using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Means of transport)<br/>
/// <br/>
/// Means of transport with which the goods to be delivered are transported<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class MeansOfTransport
{
    /// <summary>
    /// <inheritdoc cref="MeansOfTransport"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public MeansOfTransport()
    {
        Id = null!;
        Type = null!;
    }

    /// <summary>
    /// <inheritdoc cref="MeansOfTransport"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    public MeansOfTransport(string id, string type)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
        }

        Id = id;
        Type = type;
    }

    /// <summary>
    /// (required) Type of transport means.<br/>
    /// <br/>
    /// Specifies the type of transport means.<br/>
    /// <br/>The pre-defined values follow UN/ECE Recommendation 19 - TRADE/CEFACT/2001/19 (see http://www.unece.org/cefact/recommendations/rec19/rec19_01cf19e.pdf). <br/>
    /// See <see cref="MeansOfTransportTypeValues"/>.
    /// <br/>
    /// Max length: 50
    /// </summary>
    [XmlAttribute("type")]
    public string Type { get; set; }

    /// <summary>
    /// (required) Means of transport ID<br/>
    /// <br/>
    /// ID for the means of transport.<br/>
    /// <br/>
    /// Max length: 50
    /// </summary>
    [BMEXmlElement("MEANS_OF_TRANSPORT_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (optional) Name of the means of transport<br/>
    /// <br/>
    /// Name of the means of transport.<br/>
    /// <br/>
    /// Max length: 50
    /// </summary>
    [BMEXmlElement("MEANS_OF_TRANSPORT_NAME")]
    public string? Name { get; set; }
}
