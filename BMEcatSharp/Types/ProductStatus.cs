using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Special product status)<br/>
    /// <br/>
    /// Theis element classifies a product in terms of its special characteristics.<br/>
    /// The status type is specified by the 'type' attribute.<br/>
    /// The value of the element reflects the text description of the special characteristics.<br/>
    /// If a product cannot be mapped to any of the predefined status types, "others" must be used.<br/>
    /// User-defined status types are not permitted.<br/>
    /// <br/>
    /// It is therefore possible, for example, to identify a product as a special offer or a new product and to comment on it.<br/>
    /// It is intended that the target system should highlight products identified in this way (e.g., graphic identification, including in a special catalog rubric or by search-and-find process which support this attribute).<br/>
    /// <br/>
    /// For each product multiple special status can be defined.<br/>
    /// The individual types may not appear more than once, however.The order in which the elements appear is not relevant
    /// </summary>
    public class ProductStatus
    {
        public ProductStatus()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">Type of special status of the product.<br/>
        /// <br/>
        /// See <see cref="ProductStatusType"/>.</param>
        public ProductStatus(string value, ProductStatusType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// (required) Type of status<br/>
        /// <br/>
        /// Type of special status of the product.<br/>
        /// <br/>
        /// See <see cref="ProductStatusType"/>.
        /// </summary>
        [XmlAttribute("type")]
        public ProductStatusType Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
