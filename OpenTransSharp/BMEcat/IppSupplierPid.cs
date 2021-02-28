using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP product ID)<br/>
    /// <br/>
    /// This element contains the identifier ID which is input for the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppSupplierPid : IppParamsBase
    {
        public IppSupplierPid()
        {
        }

        public IppSupplierPid(string value)
        {
            Value = value;
        }
        
        public IppSupplierPid(string value, IppOccurrence occurrence)
            : this(value)
        {
            Occurrence = occurrence;
        }

        /// <summary>
        /// (required)
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }
    }
}
