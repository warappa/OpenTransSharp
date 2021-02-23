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
        [XmlAttribute("intervaltype")]
        public Intervaltype? Intervaltype { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IntervaltypeSpecified => Intervaltype.HasValue;

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [Required]
        [XmlText]
        public decimal Value { get; set; }
    }
}
