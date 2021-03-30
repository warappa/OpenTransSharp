using BMEcatSharp.Xml;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Product ID of the buying company)<br/>
    /// <br/>
    /// This element contains the product number used by the buying company.<br/>
    /// The "type" attribute specifies the type of ID.<br/>
    /// If the element is used multiple, the values of the attribute "type" must differ.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class BuyerPid
    {
        public BuyerPid()
        {
        }

        public BuyerPid(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="BuyerPidTypeValues"/>. Custom values can be used.</param>
        public BuyerPid(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional)<br/>
        /// <br/>
        /// This attribute specifies the type of ID, i.e. indicates the organization that has issued the ID.<br/>
        /// <br/>
        /// For predefined values see <see cref="BuyerPidTypeValues"/>. Custom values can be used.<br/>
        /// </summary>
        [BMEXmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 50
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
