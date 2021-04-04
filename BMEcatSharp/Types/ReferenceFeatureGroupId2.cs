using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Additional group reference)<br/>
    /// <br/>
    /// This element provides an additional identifier of the same group which has already been referenced in the REFERENCE_FEATURE_GROUP_ID element.<br/>
    /// The element should be only if the classification system defines two different identifier for the same group.<br/>
    /// <br/>
    /// Caution:<br/>
    /// When classifying product according to eCl@ss, this element has to be filled with the eCl@ss field 'idcl' (primary key) and the 'type' attribute has to be set to 'flat'.
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ReferenceFeatureGroupId2
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReferenceFeatureGroupId2()
            : this(null!)
        { }
        
        public ReferenceFeatureGroupId2(string value)
        {
            Value = value;
        }

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
