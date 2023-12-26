using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// For <see cref="DeliveryDate.Type"/>.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public enum DeliveryDateType
{
    /// <summary>
    /// Fixed delivery date<br/>
    /// <br/>
    /// The date given is to be interpreted by the recipient as a fixed specified delivery date. 
    /// </summary>
    [XmlEnum("fixed")]
    Fixed,
    /// <summary>
    /// Required date<br/>
    /// <br/>
    /// The date given is to be interpreted by the recipient as a required delivery date.
    /// </summary>
    [XmlEnum("optional")]
    Optional
}
