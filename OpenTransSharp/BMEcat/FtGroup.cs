using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature group)<br/>
    /// <br/>
    /// This element specifies a feature group, e.g., "Dimensions" as a group for the features "width", "length", and "heigth".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FtGroup
    {
        /// <summary>
        /// (required) Feature group ID<br/>
        /// <br/>
        /// Specifies the unique identification of the feature group within the classification system; this identification is required for referencing the feature group when defining a feature.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_GROUP_ID")]
        public string FtGroupId { get; set; }

        /// <summary>
        /// (required) Feature group name<br/>
        /// <br/>
        /// Specifies the name of the feature group; e.g., "Technical features".<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_GROUP_NAME")]
        public MultiLingualString? FtGroupName { get; set; }

        /// <summary>
        /// (optional) Feature group description<br/>
        /// <br/>
        /// This element can be used to describe the feature group in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_GROUP_DESCR")]
        public MultiLingualString? FtGroupDescription { get; set; }

        /// <summary>
        /// (optional) Parent group of the feature group<br/>
        /// <br/>
        /// This element references the unique identification of the parent group for the respective feature group (FT_GROUP_ID).<br/>
        /// If there is no parent group for the group, this element must not be used.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("FT_GROUP_PARENT_ID")]
        public List<string> FtGroupParentIds { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FtGroupParentIdsSpecified => FtGroupParentIds?.Count > 0;
    }
}
