﻿namespace OpenTransSharp;

/// <summary>
/// (Additional multimedia information)<br/>
/// <br/>
/// This element can be used to specify references to additional multimedia documents belonging to a particular article.<br/>
/// This makes it possible, for example, to reference photographs or product data sheets of an article at the same time as the catalog data is exchanged.<br/>
/// <br/>
/// It is assumed that this additional data either is transferred (separately) and that it is imported relative to the directory specified in the HEADER as MIME_ROOT or the additional data is directly integrated and binary-coded in the document.<br/>
/// <br/>
/// This element can contain any number of MIME elements.<br/>
/// Each of these elements represents exactly one reference to an additional document. The definition of the MIME element is based on the MIME format (Multipurpose Internet Mail Extensions).<br/>
/// The MIME format serves to standardize data transfers over the Internet.<br/>
/// Additional examples can be found one the page describing the element MIME.
/// </summary>
public class OpenTransMimeInfo
{
    /// <summary>
    /// <inheritdoc cref="OpenTransMimeInfo"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenTransMimeInfo() { }

    /// <summary>
    /// <inheritdoc cref="OpenTransMimeInfo"/>
    /// </summary>
    /// <param name="mimes"></param>
    public OpenTransMimeInfo(IEnumerable<OpenTransMime> mimes)
    {
        if (mimes is null)
        {
            throw new ArgumentNullException(nameof(mimes));
        }

        Mimes = mimes.ToList();
    }

    /// <summary>
    /// (required) Multimedia document<br/>
    /// <br/>
    /// Information about a multimedia file.<br/>
    /// The file itself is can be referenced and transferred separately or direclty binary-coded in the document via the element MIME_EMBEDDED.
    /// </summary>
    [OpenTransXmlElement("MIME")]
    public List<OpenTransMime> Mimes { get; set; } = [];
}
