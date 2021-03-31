using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to an IPP shopping cart)<br/>
    /// <br/>
    /// This element specifies if and how identifiers of product lists are used with an IPP application call.<br/>
    /// <br/>
    /// The element has to be empty and the the attribute "occurance" states wether the transfer of this identifier is mandatory or optional.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppProductlistIdref : IppParamsBase
    {
        public IppProductlistIdref()
        {
        }

        public IppProductlistIdref(string value)
        {
            Value = value;
        }

        public IppProductlistIdref(string value, IppOccurrence occurrence)
            : this(value)
        {
            Occurrence = occurrence;
        }

        /// <summary>
        /// (required)
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
