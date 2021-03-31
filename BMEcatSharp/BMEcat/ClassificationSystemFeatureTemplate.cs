using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Feature of the classification system)<br/>
    /// <br/>
    /// This element defines a feature of the classification system independently of its usage for a specific group.<br/>
    /// By it, multiple usage of the same or similar feature is enabled.<br/>
    /// <br/>
    /// Caution:<br/>
    /// Those parts of the definition, which depend on the group, can be described by the CLASSIFICATION_GROUP_FEATURE_TEMPLATE element<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationSystemFeatureTemplate
    {
        /// <summary>
        /// (required) Feature identifier<br/>
        /// <br/>
        /// Unique identifier of the feature.<br/>
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
        public List<MultiLingualString> Name { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (optional) Feature short name<br/>
        /// <br/>
        /// Short name of the feature in addition to its name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_SHORTNAME")]
        public List<MultiLingualString>? Shortname { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShortnameSpecified => Shortname?.Count > 0;

        /// <summary>
        /// (optional) Feature description<br/>
        /// <br/>
        /// Description of the feature and its semantics; it does not describe the value of the feature.<br/>
        /// This element is especially usefull for describing user-defined, non-standardized features.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

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
        /// (optional - choice GroupIdref/GroupName) Feature group ID reference<br/>
        /// <br/>
        /// Reference to the unique ID of a feature group.<br/>
        /// The reference must point to a FT_GROUP_ID, which has been defined in the FT_GROUP element for the respective classification system.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_GROUP_IDREF")]
        public string? GroupIdref { get; set; }

        /// <summary>
        /// (optional - choice GroupIdref/GroupName) Feature group name<br/>
        /// <br/>
        /// Specifies the name of the feature group; e.g., "Technical features".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FT_GROUP_NAME")]
        public List<MultiLingualString>? GroupName { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GroupNameSpecified => GroupName?.Count > 0;

        /// <summary>
        /// (optional) Feature dependencies<br/>
        /// <br/>
        /// List of features on which the current feature depends.<br/>
        /// Reference to the unique ID of a feature (seeCLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("FT_DEPENDENCIES")]
        [BMEXmlArrayItem("FT_IDREF")]
        public List<FeatureIdref>? Dependencies { get; set; } = new List<FeatureIdref>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DependenciesSpecified => Dependencies?.Count > 0;

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
