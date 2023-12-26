using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="ClassificationSystemType.MappingType"/>.
/// </summary>
public enum MappingType
{
    /// <summary>
    /// Multiple mapping<br/>
    /// <br/>
    /// Indicates that each product can be mapped to one or many groups.
    /// </summary>
    [XmlEnum("multiple")]
    Multiple,

    /// <summary>
    /// Single mapping<br/>
    /// <br/>
    /// Indicates that each product has to be mapped to one group only.
    /// </summary>
    [XmlEnum("single")]
    Single
}
