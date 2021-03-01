using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Classification group)<br/>
    /// <br/>
    /// This element defines a group of the classification system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationGroup
    {
        /// <summary>
        /// (optional) Group type<br/>
        /// <br/>
        /// This attribute specifies whether the group is on the lowest level of the classification system.<br/>
        /// <br/>
        /// See <see cref="ClassificationGroupType"/>.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlAttribute("type")]
        public ClassificationGroupType Type { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeSpecified => Type != ClassificationGroupType.Undefined;

        /// <summary>
        /// (optional) Hierarchy level<br/>
        /// <br/>
        /// This attribute specifies the hierarchy level of the group as an integer.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlAttribute("level")]
        public int Level { get; set; }
        public bool LevelSpecified => Level != 0;

        /// <summary>
        /// (required) Identification of the group<br/>
        /// <br/>
        /// Unique identification of the group within the classification system.<br/>
        /// When transferring the eCl@ss classification system, this element has to be filled with the eCl@ss field 'idcl' (primary key).<br/>
        /// For example: AAA223001.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_ID")]
        public ClassificationGroupId Id { get; set; }

        /// <summary>
        /// (optional) Additional group ID<br/>
        /// <br/>Additional identifier of the group.<br/>
        /// This element can be used if the classification system defines two different identifiers for the same group.<br/>
        /// When transferring the eCl@ss classification system, this element has to be filled with the eCl@ss field 'coded name' (eCl@ss number).<br/>
        /// For example: 24-01-04-01.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_ID2")]
        public ClassificationGroupId? Id2 { get; set; }

        /// <summary>
        /// (optional) Group version<br/>
        /// <br/>
        /// Detailed information about the version of the group.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_VERSION")]
        public ClassificationGroupVersion? Version { get; set; }

        /// <summary>
        /// (required) Specifies the unique name of the group within the classification system.<br/>
        /// <br/>
        /// The name of a group is language-specific, the identification is not.<br/>
        /// Example:<br/>
        /// <c>&lt;CLASSIFICATION_GROUP_NAME&gt;NV halogen lamp&lt;/CLASSIFICATION_GROUP_NAME&gt;</c><br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_NAME")]
        public MultiLingualString Name { get; set; }

        /// <summary>
        /// (optional) Group short name<br/>
        /// <br/>
        /// Short name of the group in addition to its group name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_SHORTNAME")]
        public MultiLingualString? Shortname { get; set; }

        /// <summary>
        /// (optional) Additional description of the group<br/>
        /// This element can be used to describe the group in more detail.<br/>
        /// <br/>
        /// Example:<br/>
        /// <c>&lt;CLASSIFICATION_GROUP_DESCR&gt;Halogen lamp up to 12 V&lt;/CLASSIFICATION_GROUP_DESCR&gt;</c><br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_DESCR")]
        public MultiLingualString? Description { get; set; }

        /// <summary>
        /// (optional) Group source<br/>
        /// <br/>
        /// Information on the source of the definition that is given in CLASSIFICATION_GROUP_DESCR, e.g., a reference to a standard.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_SOURCE")]
        public ClassificationGroupSource? Source { get; set; }

        /// <summary>
        /// (optional) Classification group note<br/>
        /// <br/>
        /// Note giving additional information about the group and its definition.<br/>
        /// The note should be taken from the source document of the definition (CLASSIFICATION_GROUP_SOURCE).<br/>
        /// This element has been adopted from ISO 13584.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_NOTE")]
        public MultiLingualString? Note { get; set; }

        /// <summary>
        /// (optional) Group remark<br/>
        /// <br/>
        /// Remark giving additional information about the group and its definition.<br/>
        /// The remark contains supplementing information, i.e. it describes a specific aspect that is relevant for using the respective group.<br/>
        /// This element has been adopted from ISO 13584.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_REMARK")]
        public MultiLingualString? Remark { get; set; }

        /// <summary>
        /// (optional) Classification group contacts<br/>
        /// <br/>
        /// The contacts referenced by this element are responsible for the respective group, i.e. for purchasing these types of products.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_CONTACTS")]
        public ClassificationGroupContacts? Contacts { get; set; }

        /// <summary>
        /// (optional) Group order<br/>
        /// <br/>
        /// Order number for the graphical user interface.<br/>
        /// When groups are listed they are always represented in ascending order (the first group is the one with the lowest number)..<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_ORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For example typical product illustrations or other group specific documents could be added here.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Group synonyms<br/>
        /// <br/>
        /// List of synonyms for the group name.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("CLASSIFICATION_GROUP_SYNONYMS")]
        [BMEXmlArrayItem("SYNONYM")]
        public List<string>? Synonyms { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SynonymsSpecified => Synonyms?.Count > 0;

        /// <summary>
        /// (optional) Features of the group<br/>
        /// <br/>
        /// Contains the features of the group.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("CLASSIFICATION_GROUP_FEATURE_TEMPLATES")]
        [BMEXmlArrayItem("CLASSIFICATION_GROUP_FEATURE_TEMPLATE")]
        public List<string>? FeatureTemplates { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FeatureTemplatesSpecified => FeatureTemplates?.Count > 0;

        /// <summary>
        /// (optional) Parent group<br/>
        /// <br/>
        /// This element references the unique identification of the parent group (CLASSIFICATION_GROUP_ID).<br/>
        /// <br/>
        /// Caution:<br/>
        /// If there is no parent group for the group, this element must not be used.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CLASSIFICATION_GROUP_PARENT_ID")]
        public string? ParentId { get; set; }

        /// <summary>
        /// (optional) User-defined extensions<br/>
        /// <br/>
        /// This element marks the area in which user-defined elements can be added to a catalog document.<br/>
        /// In this way it is possible for supplier and purchasing organization to exchange additional data which is not specified in the standard.<br/>
        /// The structures of the elements may be complicated.<br/>
        /// Any XML expressions are permitted.<br/>
        /// <br/>
        /// In the various contexts in which they can occur, USER_DEFINED_EXTENSIONS are defined exclusively as Can fields.<br/>
        /// Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// <br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the BMEcat standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// When user-defined elements are to be transferred, the entity USERDEFINES, which is defined in the bmecat_base.dtd, must be newly-defined in the XML document.<br/>
        /// This enables the user to define even complex structures according to his own requirements.
        /// </summary>
        [XmlArray("CLASSIFICATION_GROUP_UDX")]
        public List<object>? Udx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UdxSpecified => Udx?.Count > 0;
    }
}
