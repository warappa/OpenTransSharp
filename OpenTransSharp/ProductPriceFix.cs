using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Determined product price)<br/>
    /// <br/>
    /// The element specifies a fixed price related to a product.<br/>
    /// In contrast to the element PRICE_LINE_AMOUNT the fixed product price does not contain any dynamic / variable descision opportunities(like graduated prices in relation to the ordered quantity).Therefore the element specifies a value not a price policy.<br/>
    /// The element should only be used in documents where usually price - information is contained (e.g.invoice).
    /// </summary>
    public class ProductPriceFix
    {
        /// <summary>
        /// (required) Price amount<br/>
        /// <br/>
        /// Amount of the price.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_AMOUNT")]
        public decimal Amount { get; set; }

        /// <summary>
        /// (optional) Fixed allowance or surcharges<br/>
        /// <br/>
        /// A list of fixed allowances or surcharges which are to be applied on the price.
        /// </summary>
        [XmlElement("ALLOW_OR_CHARGES_FIX")]
        public AllowOrChargesFix? AllowOrChargesFix { get; set; }

        /// <summary>
        /// (optional) Price flag<br/>
        /// <br/>
        /// Base of a price (e.g. with/without freight).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_FLAG")]
        public List<PriceFlag> PriceFlags { get; set; } = new List<PriceFlag>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PriceFlagsSpecified => PriceFlags?.Count > 0;

        /// <summary>
        /// (optional) Tax details<br/>
        /// <br/>
        /// Information to an applied tax.
        /// </summary>
        [XmlElement("TAX_DETAILS_FIX")]
        public List<TaxDetailsFix> TaxDetailsFixes { get; set; } = new List<TaxDetailsFix>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TaxDetailsFixesSpecified => TaxDetailsFixes?.Count > 0;

        /// <summary>
        /// (optional) Price quantity<br/>
        /// <br/>
        /// If nothing is specified in this field the default value 1 is assumed, in other words the price refers to exactly one order unit.<br/>
        /// <br/>
        /// If specified, a multiple or a fraction of the order unit (element ORDER_UNIT) which indicates the quantity to which all the specified prices refer.<br/>
        /// <br/>
        /// Example: 10 (i.e. the specified price refers to 10 crates)<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_QUANTITY")]
        public decimal? Quantity { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool QuantitySpecified => Quantity.HasValue;

        /// <summary>
        /// (optional) Fixed price base<br/>
        /// <br/>
        /// Specifies the calculation of a price.
        /// </summary>
        [XmlElement("PRICE_BASE_FIX")]
        public PriceBaseFix? BaseFix { get; set; }
    }
}
