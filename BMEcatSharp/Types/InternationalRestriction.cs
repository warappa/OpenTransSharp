using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (International delivery restrictions)<br/>
    /// <br/>
    /// This element contains details of international restrictions, e.g.compulsory import / export authorization.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class InternationalRestriction
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternationalRestriction()
            : this(null!, null!)
        {
        }

        public InternationalRestriction(string value, string type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// (required) Type of restriction<br/>
        /// <br/>
        /// Specifies the type of international delivery restriction.
        /// See <see cref="InternationalRestrictionTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
