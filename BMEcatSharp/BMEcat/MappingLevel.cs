using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="ClassificationSystemType.MappingLevel"/>
    /// </summary>
    public enum MappingLevel
    {
        /// <summary>
        /// Leaf mapping<br/>
        /// <br/>
        /// Indicates that products have to be mapped to groups on the leaf level only.
        /// </summary>
        [XmlEnum("leaf")]
        Leaf,

        /// <summary>
        /// Leaf or node mapping<br/>
        /// <br/>
        /// Indicates that products can be mapped to groups on the leaf or node leve.
        /// </summary>
        [XmlEnum("leaf_or_node")]
        LeafOrNode
    }
}
