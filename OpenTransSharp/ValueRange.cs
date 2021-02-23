using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Interval of values)<br/>
    /// <br/>
    /// This element defines an interval of values.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ValueRange
    {
        /// <summary>
        /// (required) Start value<br/>
        /// <br/>
        /// Start value of the interval; the value is part of the interval.
        /// </summary>
        [Required]
        [BMEXmlElement("STARTVALUE")]
        public Startvalue Startvalue { get; set; }

        /// <summary>
        /// (required) End value<br/>
        /// <br/>
        /// End value of the interval; the value is part of the interval.
        /// </summary>
        [Required]
        [BMEXmlElement("ENDVALUE")]
        public Endvalue Endvalue { get; set; }

        /// <summary>
        /// (optional) Distance of values<br/>
        /// <br/>
        /// Distance between the values in an interval of discrete values.<br/>
        /// <br/>
        /// For instance, a domain for the values 110, 120, 130,… 220 can be defined by setting the start and end values(110 and 120) and adding the distance(10).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("INTERVALVALUE")]
        public decimal? Intervalvalue { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IntervalvalueSpecified => Intervalvalue.HasValue;
    }
}
