using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
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
