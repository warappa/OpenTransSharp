﻿namespace BMEcatSharp;

/// <summary>
/// (Transport)<br/>
/// <br/>
/// This element contains information about the terms of transport.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Transport
{
    /// <summary>
    /// <inheritdoc cref="Transport"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transport()
    {
        Incoterm = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Transport"/>
    /// </summary>
    /// <param name="incoterm"></param>
    public Transport(string incoterm)
    {
        if (string.IsNullOrWhiteSpace(incoterm))
        {
            throw new ArgumentException($"'{nameof(incoterm)}' cannot be null or whitespace.", nameof(incoterm));
        }

        Incoterm = incoterm;
    }

    /// <summary>
    /// (required) INCOTERM<br/>
    /// <br/>
    /// International coding of transport, costs and insurance according to INCOTERMS 2000, UN/ECE, Recommendation No.5 (ECE/TRADE/259), (see http://www.unece.org/cefact/recommendations/rec05/rec05_ecetrd259.pdf). <br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("INCOTERM")]
    public string Incoterm { get; set; }

    /// <summary>
    /// (optional) Location of goods transfer<br/>
    /// Transfer of the goods from supplier to buyer or vice versa.<br/>
    /// Dependent on INCOTERM.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("LOCATION")]
    public string? Location { get; set; }

    /// <summary>
    /// (optional) Remark<br/>
    /// Remark concerning the type of transport.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TRANSPORT_REMARK")]
    public List<MultiLingualString>? Remarks { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemarksSpecified => Remarks?.Count > 0;
}
