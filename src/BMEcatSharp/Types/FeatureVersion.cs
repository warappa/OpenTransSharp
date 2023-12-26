using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// (Version of the feature)<br/>
/// <br/>
/// This element contains detailled information on the version of the feature and its version history.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class FeatureVersion
{
    /// <summary>
    /// <inheritdoc cref="FeatureVersion"/>
    /// </summary>
    public FeatureVersion()
    {
        Version = null!;
    }

    /// <summary>
    /// <inheritdoc cref="FeatureVersion"/>
    /// </summary>
    /// <param name="version"></param>
    public FeatureVersion(Version version)
    {
        Version = version ?? throw new ArgumentNullException(nameof(version));
    }

    /// <summary>
    /// (required) Version<br/>
    /// <br/>
    /// Detailled information on the version<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlIgnore]
    public Version Version { get; set; }

    [BMEXmlElement("VERSION")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string? VersionForSerialization { get => Version?.ToString(); set => Version = new Version(value); }

    /// <summary>
    /// (optional) Version date<br/>
    /// <br/>
    /// Date of the given version.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("VERSION_DATE")]
    public DateTime? VersionDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool VersionDateSpecified => VersionDate.HasValue;

    /// <summary>
    /// (optional) Revision<br/>
    /// <br/>
    /// Revision number of the given version.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REVISION")]
    public string? Revision { get; set; }

    /// <summary>
    /// (optional) Revision date<br/>
    /// <br/>
    /// Date of the latest revision.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("REVISION_DATE")]
    public DateTime? RevisionDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RevisionDateSpecified => RevisionDate.HasValue;

    /// <summary>
    /// (optional) Original date<br/>
    /// <br/>
    /// Date of the first version in its first revision.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("ORIGINAL_DATE")]
    public DateTime? OriginalDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OriginalDateSpecified => OriginalDate.HasValue;
}
