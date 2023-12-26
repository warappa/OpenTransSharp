﻿using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp;

/// <summary>
/// (Allowed value definition)<br/>
/// <br/>
/// This element defines an allowed value.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class AllowedValue
{
    /// <summary>
    /// <inheritdoc cref="AllowedValue"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AllowedValue()
    {
        Id = null!;
    }

    /// <summary>
    /// <inheritdoc cref="AllowedValue"/>
    /// </summary>
    /// <param name="id"></param>
    public AllowedValue(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        Id = id;
    }

    /// <summary>
    /// (required) Allowed value ID<br/>
    /// <br/>
    /// Unique identifier of the allowed value.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (required) Name of the allowed value<br/>
    /// <br/>
    /// This element contains the allowed value itself.<br/>
    /// The value can be language-specific, whereas the ID is independent from the language.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_NAME")]
    public List<MultiLingualString> Name { get; set; } = new List<MultiLingualString>();

    /// <summary>
    /// (optional) Version of the allowed value<br/>
    /// <br/>
    /// Detailled information on the version of the value.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_VERSION")]
    public AllowedValueVersion? Version { get; set; }

    /// <summary>
    /// (optional) Short name of the allowed value<br/>
    /// <br/>
    /// Short name of the allowed value in addition to its name, e.g. "Bin" for "Built-in".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_SHORTNAME")]
    public List<MultiLingualString>? Shortname { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShortnameSpecified => Shortname?.Count > 0;

    /// <summary>
    /// (optional) Description of the allowed value<br/>
    /// <br/>
    /// This element can be used to describe the allowed value in more detail.<br/>
    /// <br/>
    /// Example<br/>
    /// <c>&lt;ALLOWED_VALUE_DESCR&gt;crème white corresponds to RAL 9010&lt;/ALLOWED_VALUE_DESCR&gt;</c><br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_DESCR")]
    public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionSpecified => Description?.Count > 0;

    /// <summary>
    /// (optional) Allowed value synonyms<br/>
    /// <br/>
    /// List of synonyms of the allowed value.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlArray("ALLOWED_VALUE_SYNONYMS")]
    [BMEXmlArrayItem("SYNONYM")]
    public List<MultiLingualString>? Synonyms { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SynonymsSpecified => Synonyms?.Count > 0;

    /// <summary>
    /// (optional) Allowed value source<br/>
    /// <br/>
    /// Reference to a document, standard or definition describing the allowed value.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ALLOWED_VALUE_SOURCE")]
    public AllowedValueSource? Source { get; set; }
}
