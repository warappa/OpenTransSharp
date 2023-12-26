using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (Predefined configurations)<br/>
/// <br/>
/// This element contains a list of predefined configurations and allows to specify wether this list covers all valid configurations or only parts.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class PredefinedConfigurations
{
    /// <summary>
    /// <inheritdoc cref="PredefinedConfigurations"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PredefinedConfigurations() { }

    /// <summary>
    /// <inheritdoc cref="PredefinedConfigurations"/>
    /// </summary>
    /// <param name="configurations"></param>
    public PredefinedConfigurations(IEnumerable<PredefinedConfiguration> configurations)
    {
        if (configurations is null)
        {
            throw new ArgumentNullException(nameof(configurations));
        }

        Configurations = configurations.ToList();
    }

    /// <summary>
    /// (required) Predefined configuration<br/>
    /// <br/>
    /// Details for a predefined configuration.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG")]
    public List<PredefinedConfiguration>? Configurations { get; set; } = new List<PredefinedConfiguration>();

    /// <summary>
    /// (optional) Predefined configuration<br/>
    /// <br/>
    /// Details for a predefined configuration.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PREDEFINED_CONFIG_COVERAGE")]
    public PredefinedConfigurationCoverage? Coverage { get; set; } = PredefinedConfigurationCoverage.Partial;
}
