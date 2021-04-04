using System.ComponentModel;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MeansOfTransportIdRef()
            : this(null!)
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
