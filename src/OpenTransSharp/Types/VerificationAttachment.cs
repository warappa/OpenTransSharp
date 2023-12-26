namespace OpenTransSharp;

/// <summary>
/// (Verification report as (integrated) file)<br/>
/// <br/>
/// Reference to a verification report as a file or binary-coded and integrated in the document.<br/>
/// The element utilizes the MIME element to refer to a file or deliver an integrated structure.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class VerificationAttachment
{
    /// <summary>
    /// <inheritdoc cref="VerificationAttachment"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerificationAttachment() { }

    /// <summary>
    /// <inheritdoc cref="VerificationAttachment"/>
    /// </summary>
    /// <param name="mime"></param>
    public VerificationAttachment(OpenTransMime mime)
    {
        Mime = mime ?? throw new ArgumentNullException(nameof(mime));
    }

    /// <summary>
    /// (required) Multimedia document<br/>
    /// <br/>
    /// Information about a multimedia file.<br/>
    /// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.<br/>
    /// For example logos, company profiles or other business partner related documents could be added here.
    /// </summary>
    [OpenTransXmlElement("MIME")]
    public OpenTransMime Mime { get; set; } = new OpenTransMime();
}
