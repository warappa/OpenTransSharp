using System.Xml.Serialization;

namespace OpenTransSharp
{
    public enum ReferenceFeatureGroupIdType
    {
        /// <summary>
        /// Flat<br/>
        /// <br/>
        /// The group ID does not describe the position of the respective group in the hierarchy.
        /// </summary>
        [XmlEnum("flat")]
        Flat,
        /// <summary>
        /// Hierarchy<br/>
        /// <br/>
        /// The group ID describes the position of the respective group in the hierarchy.
        /// </summary>
        [XmlEnum("hierarchy")]
        Hierarchy
    }
}
