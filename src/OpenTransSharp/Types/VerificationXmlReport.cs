namespace OpenTransSharp;

/// <summary>
/// (Verification report in XML)<br/>
/// <br/>
/// Verification report in XML-structure.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class VerificationXmlReport
{
    /// <summary>
    /// <inheritdoc cref="VerificationXmlReport"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerificationXmlReport()
    {
        XmlFormat = null!;
    }

    /// <summary>
    /// <inheritdoc cref="VerificationXmlReport"/>
    /// </summary>
    /// <param name="xmlFormat"></param>
    public VerificationXmlReport(string xmlFormat)
    {
        if (string.IsNullOrWhiteSpace(xmlFormat))
        {
            throw new ArgumentException($"'{nameof(xmlFormat)}' cannot be null or whitespace.", nameof(xmlFormat));
        }

        XmlFormat = xmlFormat;
    }

    /// <summary>
    /// (required) Multimedia document<br/>
    /// <br/>
    /// The element describes the XML-structure in REPORT_UDX.<br/>
    /// Notice: the standard-format for the name should follow "&lt;Name&gt;-&lt;Major Version&gt;.&lt;Minor Version&gt;".<br/>
    /// <br/>
    /// Example: SigRepo-7.14.
    /// </summary>
    [OpenTransXmlElement("XML_FORMAT")]
    public string XmlFormat { get; set; }

    /// <summary>
    /// (optional) User-defined extensions<br/>
    /// <br/>
    /// With the help of this element signature verification reports can be represented in XMLstructures not specified in openTRANS.<br/>
    /// The element can be used like the ITEM_UDX element.
    /// </summary>
    [OpenTransXmlArray("REPORT_UDX")]
    public List<object>? ReportUdx { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ReportUdxSpecified => ReportUdx?.Count > 0;
}
