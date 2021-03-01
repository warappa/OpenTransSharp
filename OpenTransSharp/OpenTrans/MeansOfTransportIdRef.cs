using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Means of transport)<br/>
    /// <br/>
    /// Means of transport with which the goods to be delivered are transported.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class MeansOfTransportIdRef
    {
        public MeansOfTransportIdRef()
        {
        }

        public MeansOfTransportIdRef(string value)
        {
            Value = value;
        }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
