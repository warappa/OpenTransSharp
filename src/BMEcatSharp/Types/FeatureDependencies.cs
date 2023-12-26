using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (Feature dependencies)<br/>
/// <br/>
/// This element contais a list of feature on which the current feature depends; hence it is possible to express, for instance, that the feature 'length' depends on the feature 'temperature'. The features that determine the current feature are referenced by their identifier.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureDependencies
{
    /// <summary>
    /// <inheritdoc cref="FeatureDependencies"/>
    /// </summary>
    public FeatureDependencies() { }

    /// <summary>
    /// <inheritdoc cref="FeatureDependencies"/>
    /// </summary>
    /// <param name="idRefs"></param>
    public FeatureDependencies(IEnumerable<string> idRefs)
    {
        if (idRefs is null)
        {
            throw new ArgumentNullException(nameof(idRefs));
        }

        IdRefs = idRefs.ToList();
    }

    /// <summary>
    /// (required) Feature reference<br/>
    /// <br/>
    /// Reference to the unique ID of a feature (see CLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FT_IDREF")]
    public List<string> IdRefs { get; set; } = new List<string>();
}
