using BMEcatSharp.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Start value)<br/>
    /// <br/>
    /// This element sets the start value of the interval, thus the lower bound that is part of the interval.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Startvalue
    {
        /// <summary>
        /// (optional) Interval type<br/>
        /// <br/>
        /// This attribute indicates whether the value is part of the domain or not.
        /// </summary>
        [XmlIgnore]
        public Intervaltype? Intervaltype { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [BMEXmlAttribute("intervaltype")]
        public Intervaltype IntervaltypeForSerializer { get => Intervaltype ?? BMEcatSharp.Intervaltype.Undefined; set => Intervaltype = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IntervaltypeForSerializerSpecified => Intervaltype.HasValue;

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [XmlText]
        public decimal Value { get; set; }
    }
}
