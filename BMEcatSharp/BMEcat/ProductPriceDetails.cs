using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Price details)<br/>
    /// <br/>
    /// This element transfers price information for a product.<br/>
    /// It is possible to specify more than one price for each product.<br/>
    /// Doing so, the validity of the price has to be specified (e.g., time-based, geographic, technical).<br/>
    /// Moreover, graduated prices, discounts and dynamic prices can be defined.
    /// </summary>
    public class ProductPriceDetails
    {
        /// <summary>
        /// (optional) Valid start date<br/>
        /// <br/>
        /// Date for the beginning of the period of validity.
        /// </summary>
        [BMEXmlElement("VALID_START_DATE")]
        public DateTime? ValidStartDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValidStartDateSpecified => ValidStartDate.HasValue;

        /// <summary>
        /// (optional) Valid end date<br/>
        /// <br/>
        /// Date for the end of the period of validity
        /// </summary>
        [BMEXmlElement("VALID_END_DATE")]
        public DateTime? ValidEndDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ValidEndDateSpecified => ValidEndDate.HasValue;

        [Obsolete("The element is used to precisely define a time. It is made up of the three elements date, time and time zone. The element DATETIME in the context of PRODUCT_PRICE_DETAILS with the attributes 'valid_start_date' und 'valid_end_date' will be replaced by the elements VALID_START_DATE and VALID_END_DATE in future versions and will be omitted then.")]
        [BMEXmlElement("DATETIME")]
        public List<BMEcatDatetime>? DateTimes { get; set; } = new List<BMEcatDatetime>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DateTimesSpecified => DateTimes?.Count > 0;

        /// <summary>
        /// (optional) Daily price<br/>
        /// <br/>
        /// If the value of this field is “true”, the product prices may be subject to considerable daily fluctuations(e.g., additional charges for metals) and must therefore be seen as recommended prices only.<br/>
        /// The exact prices must then be calculated either using an external system or manually (e.g., by contacting the supplier).<br/>
        /// If nothing is specified in this field or if "false" is specified, the prices are assumed to be fixed
        /// </summary>
        [BMEXmlElement("DAILY_PRICE")]
        public bool? DailyPrice { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DailyPriceSpecified => DailyPrice.HasValue;

        /// <summary>
        /// (required) Product price<br/>
        /// <br/>
        /// Definition of a price for the product.
        /// </summary>
        [BMEXmlElement("PRODUCT_PRICE")]
        public List<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
    }
}
