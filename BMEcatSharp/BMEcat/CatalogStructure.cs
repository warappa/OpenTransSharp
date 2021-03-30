using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Catalog structure element - deprecated)<br/>
    /// <br/>
    /// This element serves the purpose of specifying a group within a catalog group system and linking the group into the hierarchical tree.<br/>
    /// This element will not be used in the future.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [Obsolete("This element will not be used in the future.")]
    public class CatalogStructure
    {
        /// <summary>
        /// (required) Catalog group type<br/>
        /// <br/>
        /// The "type" attribute specifies the position of the group within the catalog tree.<br/>
        /// The topmost group in the catalog structure is the only one on the top level and consequently has no parent.<br/>
        /// It forms the root from which all the other groups branch off and must therefore be the only CATALOG_STRUCTURE element to have the type "root".<br/>
        /// All groups with no children (on the bottom level), in other words all groups which are not referenced by any other groups, must have the type "leaf". All other groups, in other words those which have both parents and children, must be defined by the type "node".
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [XmlAttribute("type")]
        public CatalogStructureType Type { get; set; }

        /// <summary>
        /// (required - deprecated) Group ID<br/>
        /// <br/>
        /// The GROUP_ID is a unique designator which identifies the group.<br/>
        /// It is used to specify the parent-child relationship and to attach articles to the catalog group.<br/>
        /// The GROUP_ID in the topmost group (root) is "1".<br/>
        /// The GROUP_ID of all the other groups is freely selectable, whereby each GROUP_ID should only be assigned once.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("GROUP_ID")]
        public string? GroupId { get; set; }

        /// <summary>
        /// (required - deprecated) Group name<br/>
        /// <br/>
        /// The name of the catalog group is displayed in the target system and allows users to search for and find the group.<br/>
        /// The name is usually the generic term for all the other groups and articles below it.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("GROUP_NAME")]
        public List<MultiLingualString>? GroupName { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (required - deprecated) Group description <br/>
        /// <br/>
        /// This element can be used to describe the group in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("GROUP_DESCRIPTION")]
        public List<MultiLingualString> GroupDescription { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (required - deprecated) Superordinate leven<br/>
        /// <br/>
        /// This element specifies the ID of the parent catalog group.<br/>
        /// The group on the top level (root) represents an exception here because it has no parent.<br/>
        /// Here 0 must be set.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("PARENT_ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// (optional - deprecated) Catalog group order<br/>
        /// <br/>
        /// When catalog groups are listed they are always represented in ascending order (the first group is the one with the lowest number).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("GROUP_ORDER")]
        public int? GroupOrder { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GroupOrderSpecified => GroupOrder.HasValue;

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For example typical product illustrations or other group specific documents could be added here.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_INFO")]
        public BMEcatMimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) User-defined extension<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-BMEcat-elements; hence it is possible to extend the pre-defined set of BMEcat-elements by user-defined ones.<br/>
        /// <br/>
        /// The usage of those elements results in BMEcat catalog documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
        /// The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// USER_DEFINED_EXTENSIONS are defined exclusively as optional fields.<br/>
        /// Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the BMEcat standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML Schema files.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlArray("USER_DEFINED_EXTENSIONS")]
        public List<object>? UserDefinedExtensions { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UserDefinedExtensionsSpecified => UserDefinedExtensions?.Count > 0;

        /// <summary>
        /// (optional - deprecated) Keyword<br/>
        /// <br/>
        /// Keyword that supports product search in target systems.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Obsolete("This element will not be used in the future.")]
        [BMEXmlElement("KEYWORD")]
        public List<MultiLingualString>? Keywords { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeywordsSpecified => Keywords?.Count > 0;
    }
}