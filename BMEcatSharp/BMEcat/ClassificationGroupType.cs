using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="ClassificationGroup.Type"/>.
    /// </summary>
    public enum ClassificationGroupType
    {
        /// <summary>
        /// Leaf<br/>
        /// <br/>
        /// The group is on the lowest level of the hierarchy.
        /// </summary>
        [XmlEnum("leaf")]
        Leaf,

        /// <summary>
        /// Branch<br/>
        /// <br/>
        /// The group is a branch within the hierarchy, i.e. there is at least one group below this group. 
        /// </summary>
        [XmlEnum("node")]
        Node,
        [EditorBrowsable(EditorBrowsableState.Never)]
        Undefined
    }
}
