using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Allowance or surcharge value)<br/>
    /// <br/>
    /// A description of the structure of the allowance or surcharge.<br/>
    /// The type is defined in the related sub-element.<br/>
    /// Both allowances and surcharges are positiv values.<br/>
    /// The attribute ALLOW_OR_CHARGE --> type indicates an allowance or surcharge and thus indicates an increase or decrease of the original amount.
    /// </summary>
    public class AllowOrChargeValue
    {
        /// <summary>
        /// (required) Prozentual value<br/>
        /// <br/>
        /// The share of the product-value (factor) to determine the allowance or charge.<br/>
        /// <br/>The allowance or charge is calculated by multiply the AOC_PERCENTAGE_FACTOR by the (interim-)product-value which was calculated at this stage of the document.<br/>
        /// The currency is not different to the currency of the product-price.
        /// </summary>
        [Required]
        [XmlElement("AOC_PERCENTAGE_FACTOR")]
        public decimal AocPercentageFactor { get; set; }

        /// <summary>
        /// (required) Monetary amount<br/>
        /// <br/>
        /// The allowance or charge is defined via an absolut value.<br/>
        /// The currency is identical with the product price currency.
        /// </summary>
        [Required]
        [XmlElement("AOC_MONETARY_AMOUNT")]
        public decimal AocMonetaryAmount { get; set; }

        /// <summary>
        /// (required) Number of rebates in kind units<br/>
        /// <br/>
        /// Number of rebates or charge in kind units.
        /// </summary>
        [Required]
        [XmlElement("AOC_ORDER_UNITS_COUNT")]
        public AocOrderUnitsCount AocOrderUnitsCount { get; set; }

        /// <summary>
        /// (required) Additional Items<br/>
        /// <br/>
        /// Declaration if additional items are dilivered.<br/>
        /// <br/>
        /// This field can is only permitted in case of be intended for other items than the items of the parent-product and -order-unit(ORDER_UNIT).<br/>
        /// In case of the same product the field AOC_ORDER_UNITS_COUNT has to be used.
        /// </summary>
        [Required]
        [XmlElement("AOC_ADDITIONAL_ITEMS")]
        public decimal AocAdditionalItems { get; set; }
    }
}
