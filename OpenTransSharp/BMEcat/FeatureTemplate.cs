using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature definition)<br/>
    /// <br/>
    /// This element defines a feature, it does not define the feature value though.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureTemplate
    {
        /// <summary>
        /// (required) Feature identifier<br/>
        /// <br/>
        /// Unique identifier of the feature.<br/>
        /// <br/>
        /// This identifier ist required for referencing the feature from a classification group.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) Feature name<br/>
        /// <br/>
        /// This element defines the feature name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_NAME")]
        public MultiLingualString Name { get; set; }

        /// <summary>
        /// (optional) Feature short name<br/>
        /// <br/>
        /// Short name of the feature in addition to its name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_SHORTNAME")]
        public MultiLingualString? ShortName { get; set; }

        /// <summary>
        /// (optional) Feature description<br/>
        /// <br/>
        /// Description of the feature and its semantics; it does not describe the value of the feature.<br/>
        /// <br/>
        /// This element is especially usefull for describing user-defined, non-standardized features.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_DESCR")]
        public MultiLingualString? Description { get; set; }

        /// <summary>
        /// (optional) Version of the feature<br/>
        /// <br/>
        /// Detailled information on the version of the feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_VERSION")]
        public FeatureVersion? Version { get; set; }

        /// <summary>
        /// (optional) Feature group ID reference<br/>
        /// <br/>
        /// Reference to the unique ID of a feature group.<br/>
        /// The reference must point to a FT_GROUP_ID, which has been defined in the FT_GROUP element for the respective classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_GROUP_IDREF")]
        public string? GroupIdref { get; set; }

        /// <summary>
        /// (optional) Feature group name<br/>
        /// <br/>
        /// Specifies the name of the feature group; e.g., "Technical features".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_GROUP_NAME")]
        public MultiLingualString? GroupName { get; set; }

        /// <summary>
        /// (optional) Feature dependencies<br/>
        /// <br/>
        /// List of features on which the current feature depends.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_DEPENDENCIES")]
        public FeatureDependencies? Dependencies { get; set; }

        /// <summary>
        /// (optional) Feature content definition<br/>
        /// <br/>
        /// Detailled information on the feature content, e.g., data type, unit of measurement, domain of values, synonyms, and many more characteristics.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FEATURE_CONTENT")]
        public FeatureContent? Content { get; set; }
    }
}
