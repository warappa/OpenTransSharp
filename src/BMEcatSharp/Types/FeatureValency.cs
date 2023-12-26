namespace BMEcatSharp;

/// <summary>
/// For <see cref="FeatureContent.Valency"/>.
/// </summary>
public enum FeatureValency
{
    /// <summary>
    /// Univalent<br/>
    /// <br/>
    /// The feature can only have one value.
    /// </summary>
    [XmlEnum("univalent")]
    Univalent,
    /// <summary>
    /// Univalent<br/>
    /// <br/>
    /// The feature can have more than one value.
    /// </summary>
    [XmlEnum("multivalent")]
    Multivalent
}
