using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Value ID reference)<br/>
    /// <br/>
    /// This element references an allowed values taken from the list of all values (see ALLOWED_VALUES) of the classification system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class AllowedValueIdref
    {
        /// <summary>
        /// <inheritdoc cref="AllowedValueIdref"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AllowedValueIdref()
        {
            Value = null!;
        }

        public AllowedValueIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// (optional) Sequence of the allowed value<br/>
        /// <br/>
        /// This attribute contains the sequence, in which target system should list the allowed value within a list of values.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlAttribute("order")]
        public int Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order > 0;

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
