using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// <br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
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
    Hierarchy,
    [EditorBrowsable(EditorBrowsableState.Never)]
    Undefined
}
