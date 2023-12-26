namespace BMEcatSharp;

/// <summary>
/// (Legal information)<br/>
/// <br/>
/// Legal information; the content can be defined for each area or country seperately.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class LegalInfo
{
    /// <summary>
    /// <inheritdoc cref="LegalInfo"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public LegalInfo() { }

    /// <summary>
    /// <inheritdoc cref="LegalInfo"/>
    /// </summary>
    /// <param name="areaLegalInfos"></param>
    public LegalInfo(IEnumerable<AreaLegalInfo> areaLegalInfos)
    {
        if (areaLegalInfos is null)
        {
            throw new ArgumentNullException(nameof(areaLegalInfos));
        }

        AreaLegalInfos = areaLegalInfos.ToList();
    }

    /// <summary>
    /// Areas-specific legal information<br/>
    /// <br/>
    /// Legal information valid for an area or a country.<br/>
    /// Legal information may include 'General Terms of Delivery', information on the management, or the legal venue.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AREA_LEGAL_INFO")]
    public List<AreaLegalInfo> AreaLegalInfos { get; set; } = new List<AreaLegalInfo>();
}
