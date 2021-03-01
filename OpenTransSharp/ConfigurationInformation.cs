using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Configuration information)<br/>
    /// <br/>
    /// This element contains information on creating order numbers and prices if the enumerative value is subject of product configuration.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ConfigurationInformation
    {
        /// <summary>
        /// (required) order number extension<br/>
        /// <br/>
        /// In order to generate the order number of configurated products, this element can be used for coding the result of each configuration step; the unique code is added to the base order number.By adding these codes for each configuration step a unique order number is created.<br/>
        /// <br/>
        /// If the configuration requires more than one configuration step, it should be guaranted that the extensions can be separated. A solution is to standardize the length of each added code; for instance, adding 3 characters, e.g., "003"="black". Another solution is to separate the codes by a hyphen(e.g., "-red").<br/>
        /// <br/>
        /// Max length: 50<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("CONFIG_CODE")]
        public string ConfigurationCode { get; set; }

        /// <summary>
        /// (optional) Price details<br/>
        /// <br/>
        /// Price information for the product.<br/>
        /// A detailed description of the element is contained in a separate document which can be downloaded from the BMEcat website www.bmecat.org.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
        public ProductPriceDetails? ProductPriceDetails { get; set; }
    }
}
