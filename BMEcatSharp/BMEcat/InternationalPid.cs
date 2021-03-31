using BMEcatSharp.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (International product number)<br/>
    /// <br/>
    /// This element contains an international product number (e.g., EAN).<br/>
    /// The underlying standard respectively organisation is given in the 'type' attribute.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class InternationalPid
    {
        public InternationalPid()
        {

        }

        public InternationalPid(string value)
        {
            Value = value;
        }

        public InternationalPid(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional)<br/>
        /// <br/>
        /// Specification of the underlying standard respectively organisation.
        /// </summary>
        [BMEXmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 100
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
