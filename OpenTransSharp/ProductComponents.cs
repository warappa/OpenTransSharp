using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Product components)<br/>
    /// <br/>
    /// List of product componentes contained in a product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductComponents
    {
        /// <summary>
        /// (required) Product component<br/>
        /// <br/>
        /// Products which are part of other products and need to be further specified.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [XmlElement("PRODUCT_COMPONENT")]
        public List<ProductComponent> Components { get; set; } = new List<ProductComponent>();
    }
}
