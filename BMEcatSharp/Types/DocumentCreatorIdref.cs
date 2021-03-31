using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Document creator)<br/>
    /// <br/>
    /// This element contains a reference to the document creator.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class DocumentCreatorIdref
    {
        public DocumentCreatorIdref()
        {

        }

        public DocumentCreatorIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined.<br/>
        /// <br/>
        /// See <see cref="PartyTypeValues"/>.</param>
        public DocumentCreatorIdref(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) ID type Coding standard<br/>
        /// <br/>
        /// This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
        /// The most common coding standards are predefined.<br/>
        /// <br/>
        /// See <see cref="PartyTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
