using System.Collections.Generic;

namespace OpenTransSharp
{
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
        /// (required) Predefined configuration<br/>
        /// <br/>
        /// Details for a predefined configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PREDEFINED_CONFIGS")]
        public List<PredefinedConfiguration>? Configurations { get; set; } = new List<PredefinedConfiguration>();

        /// <summary>
        /// (optional) Predefined configuration<br/>
        /// <br/>
        /// Details for a predefined configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PREDEFINED_CONFIG_COVERAGE")]
        public PredefinedConfigCoverage? PredefinedConfigCoverage { get; set; } = OpenTransSharp.PredefinedConfigCoverage.Partial;
    }
}
