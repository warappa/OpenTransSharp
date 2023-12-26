using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (IPP languages)<br/>
/// <br/>
/// This element contains a list of languages that are supported by the IPP application.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class IppLanguages : IppParamsBase
{
    /// <summary>
    /// <inheritdoc cref="IppLanguages"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IppLanguages() { }

    /// <summary>
    /// <inheritdoc cref="IppLanguages"/>
    /// </summary>
    /// <param name="languages"></param>
    public IppLanguages(IEnumerable<Language> languages)
    {
        if (languages is null)
        {
            throw new ArgumentNullException(nameof(languages));
        }

        Languages = languages.ToList();
    }

    /// <summary>
    /// (required) Languages<br/>
    /// <br/>
    /// Specification of used languages, especially the default language of all language-dependent information.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("LANGUAGE")]
    public List<Language> Languages { get; set; } = new List<Language>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool LanguagesSpecified => Languages?.Count > 0;
}
