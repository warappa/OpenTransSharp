namespace BMEcatSharp;

/// <summary>
/// (Configuration feature)<br/>
/// <br/>
/// This element defines a feature to which product configuration assignes a value, i.e.by selection from a list of allowed value, or user input.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ConfigurationFeature
{
    /// <summary>
    /// <inheritdoc cref="ConfigurationFeature"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ConfigurationFeature()
    { }

    /// <summary>
    /// <inheritdoc cref="ConfigurationFeature"/>
    /// </summary>
    /// <param name="featureReference"></param>
    public ConfigurationFeature(FeatureReference featureReference)
    {
        FeatureReference = featureReference ?? throw new ArgumentNullException(nameof(featureReference));
    }

    /// <summary>
    /// <inheritdoc cref="ConfigurationFeature"/>
    /// </summary>
    /// <param name="featureTemplate"></param>
    public ConfigurationFeature(FeatureTemplate featureTemplate)
    {
        FeatureTemplate = featureTemplate ?? throw new ArgumentNullException(nameof(featureTemplate));
    }

    /// <summary>
    /// (required - choice FeatureReference/FeatureTemplate) Reference to a feature<br/>
    /// <br/>
    /// Reference to a feature which is defined in a classification system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FREF")]
    public FeatureReference? FeatureReference { get; set; }

    /// <summary>
    /// (required - choice FeatureReference/FeatureTemplate) Feature definition<br/>
    /// <br/>
    /// Definition of the feature.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("FTEMPLATE")]
    public FeatureTemplate? FeatureTemplate { get; set; }

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files.<br/>
    /// For example an illustration which clarifies the measurements relevant for the feature or any other feature related document could be added here.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_INFO")]
    public BMEcatMimeInfo? MimeInfo { get; set; }
}
