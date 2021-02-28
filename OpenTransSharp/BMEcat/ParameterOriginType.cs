using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="ParameterOrigin.Type"/>.
    /// </summary>
    public enum ParameterOriginType
    {
        /// <summary>
        /// User input<br/>
        /// <br/>
        /// The value is provided by the user during the product configuration.<br/>
        /// In this case, the PARAMETER_ORIGIN element must contain the identifier of the respective configuration step (STEP_ID).
        /// </summary>
        [XmlEnum("config")]
        Config,

        /// <summary>
        /// Formula<br/>
        /// <br/>
        /// The value is the result of another formula. In this case, the PARAMETER_ORIGIN element must contain the identifier of the respective formula (FORMULA_ID).
        /// </summary>
        [XmlEnum("formula")]
        Formula,

        /// <summary>
        /// Value from Uri<br/>
        /// <br/>
        /// The value is requested online from the a URI.<br/>
        /// In this case, the PARAMETER_ORIGIN element must contain the identifier of the respective URI.<br/>
        /// <br/>
        /// Caution:<br/>
        /// If the internet connection is broken, the target system may determine the parameter value by other means, i.e. user input or local data source.
        /// </summary>
        [XmlEnum("uri")]
        Uri,

        /// <summary>
        /// XPATH<br/>
        /// <br/>
        /// The value is referenced by a XPATH expression.<br/>
        /// In this case, the PARAMETER_ORIGIN element must contain the respective XPATH expression.<br/>
        /// Elements and its values within the BMEcat catalog documents can be referenced by these expressions (see also http://www.w3.org/TR/xpath).<br/>
        /// The starting element for XPATH is the PRODUCT element of the respective product (for which the formula is used).<br/>
        /// <br/>
        /// Example 1:<br/>
        /// A XPATH expression for referencing the INTERNATIONAL_PID element looks like this: &lt;PARAMETER_ORIGIN&gt;PRODUCT_DETAILS/INTERNATIONAL_PID[@type='ean']&lt;/PARAMETER_ORIGIN&gt;.<br/>
        /// <br/>
        /// Example 2:<br/>
        /// A reference to a product feature is made by its ID (FT_IDREF) or its name (FNAME): &lt;PARAMETER_ORIGIN&gt;PRODUCT_FEATURES/FEATURE[FT_IDREF='a12120']/FVALUE&lt;/PARAMETER_ORIGIN&gt;.
        /// </summary>
        [XmlEnum("xpath")]
        XPath
    }
}
