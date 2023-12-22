using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    [XmlInclude(typeof(EmailAddress))]
    [XmlInclude(typeof(PublicKey))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class EmailComponent
    {
    }
}
