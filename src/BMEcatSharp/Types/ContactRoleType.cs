using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// Predefined values for <see cref="ContactRole"/>.
/// </summary>
public enum ContactRoleType
{
    /// <summary>
    /// Administrative<br/>
    /// <br/>
    /// Contact concerning administrative questions.
    /// </summary>
    [XmlEnum("administrativ")]
    Administrative,
    /// <summary>
    /// Commercial<br/>
    /// <br/>
    /// Contact concerning commercial questions.
    /// </summary>
    [XmlEnum("commercial")]
    Commercial,
    /// <summary>
    /// (only OpenTrans) Document trigger<br/>
    /// <br/>
    /// The one who triggered the document, e.g. the one who placed an order.
    /// </summary>
    [XmlEnum("document_issuer")]
    DocumentIssuer,
    /// <summary>
    /// Special treatment <br/>
    /// <br/>
    /// Contact concerning the handling of special products.
    /// </summary>
    [XmlEnum("special_treatment")]
    SpecialTreatment,
    /// <summary>
    /// Technical <br/>
    /// <br/>
    /// Contact concerning technical questions.
    /// </summary>
    [XmlEnum("technical")]
    Technical,
    /// <summary>
    /// Other <br/>
    /// <br/>
    /// Contact concerning general questions.
    /// </summary>
    [XmlEnum("others")]
    Other,
    [EditorBrowsable(EditorBrowsableState.Never)]
    Undefined
}
