namespace OpenTransSharp;

/// <summary>
/// (Multimedia document)<br/>
/// <br/>
/// Information about a multimedia file.<br/>
/// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class OpenTransMime
{
    /// <summary>
    /// <inheritdoc cref="OpenTransMime"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenTransMime() { }

    /// <summary>
    /// <inheritdoc cref="OpenTransMime"/>
    /// </summary>
    /// <param name="source"></param>
    public OpenTransMime(IEnumerable<MultiLingualString> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        Source = source.ToList();
    }

    /// <summary>
    /// <inheritdoc cref="OpenTransMime"/>
    /// </summary>
    /// <param name="embeddeds"></param>
    public OpenTransMime(IEnumerable<MimeEmbedded> embeddeds)
    {
        if (embeddeds is null)
        {
            throw new ArgumentNullException(nameof(embeddeds));
        }

        Embeddeds = embeddeds.ToList();
    }

    /// <summary>
    /// (optional) MIME type<br/>
    /// <br/>
    /// Type of the additional document; this element is oriented towards the mime type usual in the Internet (ftp://ftp.isi.edu/in-notes/rfc1341.txt).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_TYPE")]
    public string? MimeType { get; set; }

    /// <summary>
    /// (required - choice MimeSource/MimeEmbeddeds) Source<br/>
    /// <br/>
    /// The relative path and the file name or URL address.<br/>
    /// The MIME_SOURCE string is combined with the base path (MIME_ROOT) specified in the header of the document (attached to it by means of a simple contecatenation).<br/>
    /// Sub-directories must be separated by means of slashes("/") (e.g. /public/document/demo.pdf).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_SOURCE")]
    public List<global::BMEcatSharp.MultiLingualString>? Source { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SourceSpecified => Source?.Count > 0;

    /// <summary>
    /// (optional - with MimeSource) Hash value of a file<br/>
    /// <br/>
    /// Element contains a hash value related to an external file
    /// </summary>
    [OpenTransXmlElement("FILE_HASH_VALUE")]
    public List<FileHashValue>? FileHashValues { get; set; } = new List<FileHashValue>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool FileHashValuesSpecified => FileHashValues?.Count > 0;

    /// <summary>
    /// (required - choice MimeSource/MimeEmbeddeds) Embedded document<br/>
    /// <br/>
    /// Element containing a binary-coded file and additional information.
    /// </summary>
    [OpenTransXmlElement("MIME_EMBEDDED")]
    public List<MimeEmbedded> Embeddeds { get; set; } = new List<MimeEmbedded>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool EmbeddedsSpecified => Embeddeds?.Count > 0;

    /// <summary>
    /// (optional) Designation<br/>
    /// <br/>
    /// Description of the additional file. It will be displayed in the target system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? Descriptions { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionsSpecified => Descriptions?.Count > 0;

    /// <summary>
    /// (optional) Alternative text<br/>
    /// <br/>
    /// Alternative text used if the file cannot be represented in the target system, for example.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_ALT")]
    public List<global::BMEcatSharp.MultiLingualString>? AlternativeTexts { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AlternativeTextsSpecified => AlternativeTexts?.Count > 0;

    /// <summary>
    /// (optional) Purpose<br/>
    /// <br/>
    /// Desired purpose for which the MIME document is to be used in the target system.
    /// </summary>
    [OpenTransXmlElement("MIME_PURPOSE")] // yes, not BMEcat
    public global::BMEcatSharp.MimePurpose? Purpose { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool PurposeSpecified => Purpose.HasValue;

    /// <summary>
    /// (optional) Order<br/>
    /// <br/>
    /// Order in which the additional data is to be represented in the target system.<br/>
    /// When additional documents are listed they should be represented in ascending order (the first document is the one with the lowest number).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("MIME_ORDER")]
    public int? Order { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool OrderSpecified => Order.HasValue;
}
