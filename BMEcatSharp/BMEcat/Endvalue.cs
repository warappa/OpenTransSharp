using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (End value)<br/>
    /// <br/>
    /// This element sets the end value of the interval, thus the upper bound that is part of the interval.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Endvalue
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
        public Intervaltype IntervaltypeForSerializer { get => Intervaltype ?? OpenTransSharp.Intervaltype.Undefined; set => Intervaltype = value; }
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
