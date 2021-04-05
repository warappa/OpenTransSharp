using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP currencies)<br/>
    /// <br/>
    /// This element contains a list of currencies that are supported by the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppPriceCurrencies : IppParamsBase
    {
        /// <summary>
        /// <inheritdoc cref="IppPriceCurrencies"/>
        /// </summary>
        public IppPriceCurrencies() { }

        /// <summary>
        /// (optional) Price currency<br/>
        /// <br/>
        /// Currency of the price.<br/>
        /// If nothing is specified in this field, the currency defined in the document header (HEADER) in the element CURRENCY is used for all prices.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRICE_CURRENCY")]
        public List<string>? PriceCurrencies { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PriceCurrenciesSpecified => PriceCurrencies?.Count > 0;
    }
}
