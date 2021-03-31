using BMEcatSharp.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Classification system type)<br/>
    /// <br/>
    /// This element contains information about the structure of the classification system, especially about the class hierarchy.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationSystemType
    {
        /// <summary>
        /// (optional) Group identifier type<br/>
        /// <br/>
        /// This element specifies the type of the group identifiers contained in CLASSIFICATION_GROUP_ID elements:<br/>
        /// <br/>
        /// The value <c>true</c> indicates that the group ID describes the position of the group in the hierarchy, since it is a code built from the navigation path to the respective group.<br/>
        /// <br/>
        /// If the value is <c>false</c>, then the group ID can not be interpreted this way. If the element is missing, no statement about the group ID type is made.<br/>
        /// <br/>
        /// Caution:<br/>
        /// When transferring the eCl@ss classification system, this element must be set to 'false', because the first group ID given in the CLASSIFICATION_GROUP_ID element contains the eCl@ss field 'idcl' and the additional group ID given in the CLASSIFICATION_GROUP_ID2 element contains the eCl @ss field 'coded name' (e.g., 21011304).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlIgnore]
        public bool? GroupidHierarchy { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [BMEXmlElement("GROUPID_HIERARCHY")]
        public string GroupidHierarchyForSerializer { get => GroupidHierarchy is null ? null! : GroupidHierarchy == true ? "true" : "false"; set => GroupidHierarchy = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GroupidHierarchyForSerializerSpecified => GroupidHierarchy == true;

        /// <summary>
        /// (optional) Product mapping type<br/>
        /// <br/>
        /// Indicates how products have to be mapped to groups; to one or many groups of the hierarchy.<br/>
        /// <br/>
        /// Caution:<br/>
        /// If products may be mapped to multiple group, the respective system is no longer a classification system; this may cause problems how the interprete the product features.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MAPPING_TYPE")]
        public MappingType MappingType { get; set; }

        /// <summary>
        /// (optional) Product mapping level<br/>
        /// <br/>
        /// Indicates how products have to be mapped to groups; to leafs or nodes of the hierarchy.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MAPPING_LEVEL")]
        public MappingLevel MappingLevel { get; set; }

        /// <summary>
        /// (optional) Balanced tree<br/>
        /// <br/>
        /// Indicates whether the classification tree is balanced (i.e. all sub-trees on the first level have the same number of subordinate levels).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlIgnore]
        public bool? Balancedtree { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [BMEXmlElement("BALANCEDTREE")]
        public string BalancedtreeForSerializer { get => Balancedtree is null ? null! : Balancedtree == true ? "true" : "false"; set => Balancedtree = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool BalancedtreeForSerializerSpecified => Balancedtree == true;

        /// <summary>
        /// (optional) Feature inheritance<br/>
        /// <br/>
        /// Indicates whether feature definitions on higher levels are inheritated to groups on lower levels.<br/>
        /// In this case, the features with all their characteristics will be inherited; the characteristics may be further specified respectively limited on the lower level.<br/>
        /// The actual usage of feature inheritance is subject of the respective classification system which determines how to interpret this concept.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>

        [XmlIgnore]
        public bool? Inheritance { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [BMEXmlElement("INHERITANCE")]
        public string InheritanceForSerializer { get => Inheritance is null ? null! : Inheritance == true ? "true" : "false"; set => Inheritance = value?.ToLowerInvariant() == "true" ? true : false; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InheritanceSpecified => Inheritance.HasValue;
    }
}
