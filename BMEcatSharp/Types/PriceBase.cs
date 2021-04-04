using BMEcatSharp.Xml;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Price basis)<br/>
    /// <br/>
    /// This element contains the price basis consisting of price unit and price factor, it defines the basis of a price.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class PriceBase
    {
        public PriceBase()
            : this(null!)
        {
        }

        public PriceBase(string unit)
        {
            Unit = unit;
        }

        /// <summary>
        /// (required) Price unit<br/>
        /// <br/>
        /// Unit of measurement on which the price is calculated.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_UNIT")]
        public string Unit { get; set; }

        /// <summary>
        /// (optional) Price unit factor<br/>
        /// <br/>
        /// The price factor is the conversion factor for price unit and order unit.<br/>
        /// The underlying formula is: <b>PRICE_UNIT = PRICE_UNIT_FACTOR * ORDER_UNIT</b><br/>
        /// <br/>
        /// Default value: 1<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_UNIT_FACTOR")]
        public decimal? UnitFactor { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UnitFactorSpecified => UnitFactor.HasValue;
    }
}
