using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Parameter origin)<br/>
    /// <br/>
    /// This element determines the origin of the parameter.<br/>
    /// If the parameter value is given in a PARAMETER_DEFAULT_VALUE or PARAMETER_VALUE element, this element is not permitted.<br/>
    /// The content of this element depends on the content of the attribute 'type'.<br/>
    /// <br/>
    /// Caution:<br/>
    /// The element is language-dependent in order to enable language-specific URISs, if the attribute has the value "uri".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ParameterOrigin
    {
        public ParameterOrigin()
        {
        }

        public ParameterOrigin(string value, ParameterOriginType type)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// (required) Über das Attribut wird spezifiziert, woher der Wert für den Parameter stammt.<br/>
        /// <br/>
        /// Siehe auch: Zulässige Werte für das Attribut "type" bzw. <see cref="ParameterOriginType"/>.
        /// </summary>
        [XmlAttribute("type")]
        public ParameterOriginType Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// regex: .{1.6000}
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
