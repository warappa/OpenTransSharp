using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    public class ConfigInfo
    {
        /// <summary>
        /// Max length: 50
        /// </summary>
        [Required]
        [BMEXmlElement("CONFIG_CODE")]
        public string ConfigCode { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
        public ProductPriceDetails? ProductPriceDetails { get; set; }
    }
}
