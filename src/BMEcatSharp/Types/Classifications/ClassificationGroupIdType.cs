namespace BMEcatSharp;

/// <summary>
/// For <see cref="ClassificationGroupId.Type"/>.
/// </summary>
public enum ClassificationGroupIdType
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
