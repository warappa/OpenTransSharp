using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Group reference)<br/>
    /// <br/>
    /// This element contains a reference to the unique identifier of an existing group of the respective classification system.<br/>
    /// <br/>
    /// The group can also be referenced by its unique, though language-dependent name (see REFERENCE_FEATURE_GROUP_NAME).<br/>
    /// In this case, the REFERENCE_FEATURE_GROUP_ID element may not be used.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ReferenceFeatureGroupId
    {
        /// <summary>
        /// (optional) Codification<br/>
        /// <br/>
        /// Determines whether the group ID describes the position of the respective group in the hierarchy.<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [XmlIgnore]
        public ReferenceFeatureGroupIdType? Type { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("type")]
        public ReferenceFeatureGroupIdType TypeForSerializer { get => Type ?? ReferenceFeatureGroupIdType.Undefined; set => Type = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeForSerializerSpecified => Type.HasValue;

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 60
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
