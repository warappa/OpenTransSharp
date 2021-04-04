using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppSupplierPid()
            : this(null!)
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
        [XmlText]
        public string Value { get; set; }
    }
}
