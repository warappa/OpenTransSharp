using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="CatalogStructure.Type"/>.
    /// </summary>
    public enum CatalogStructureType
    {
        /// <summary>
        /// Leaf<br/>
        /// <br/>
        /// The lowest hierarchical level in a branch of the catalog group system; products are only allowed to be attached to leaves.
        /// </summary>
        [XmlEnum("leaf")]
        Leaf,
        /// <summary>
        /// Branch<br/>
        /// <br/>
        /// The lowest hierarchical level in a branch of the catalog group system; products are only allowed to be attached to leaves.
        /// </summary>
        [XmlEnum("node")]
        Branch,
        /// <summary>
        /// Root<br/>
        /// <br/>
        /// The root of a catalog group system; all other groups and subgroups of the catalog group system branch off from this root. The root is only allowed to occur once within each catalog group system.
        /// </summary>
        [XmlEnum("root")]
        Root
    }
}
