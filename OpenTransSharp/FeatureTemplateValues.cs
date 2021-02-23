using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature domain values)<br/>
    /// <br/>
    /// This element contains a list of allowed values for the feature (only available for enumerative features).
    /// </summary>
    public class FeatureTemplateValues
    {
        /// <summary>
        /// (required) Feature value<br/>
        /// <br/>
        /// Value being part of the list of values for this feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_VALUE")]
        public List<FeatureTemplateValue> Values { get; set; } = new List<FeatureTemplateValue>();
    }
}
