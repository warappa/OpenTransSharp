using System.Xml.Serialization;

namespace OpenTransSharp
{
    public enum FeatureFacetType
    {
        /// <summary>
        /// Minimum length<br/>
        /// <br/>
        /// Defines the minimum length of all string data types, i.e. 'alphanumeric', 'set-alphanumeric' or 'string'.
        /// </summary>
        [XmlEnum("minLength")]
        MinLength,
        /// <summary>
        /// Maximum length<br/>
        /// <br/>
        /// Defines the maximum length of string data types, i.e. 'alphanumeric', 'set-alphanumeric' or 'string'.
        /// </summary>
        [XmlEnum("maxLength")]
        MaxLength,
        /// <summary>
        /// Included lower bound<br/>
        /// <br/>
        /// Defines the included lower bound of numeric data types, i.e. 'count', 'float', 'integer', 'number', 'numeric', 'range-inter', 'range-numeric', 'set-integer' or 'setnumeric'.
        /// </summary>
        [XmlEnum("minInclusive")]
        MinInclusive,
        /// <summary>
        /// Included upper bound<br/>
        /// <br/>
        /// Defines the included upper bound of numeric data types, i.e. 'count', 'float', 'integer', 'number', 'numeric', 'range-inter', 'range-numeric', 'set-integer' or 'setnumeric'.
        /// </summary>
        [XmlEnum("maxInclusive")]
        MaxInclusive,
        /// <summary>
        /// Excluded lower bound<br/>
        /// <br/>
        /// Defines the excluded lower bound of numeric data types, i.e. 'count', 'float', 'integer', 'number', 'numeric', 'range-inter', 'range-numeric', 'set-integer' or 'setnumeric'.
        /// </summary>
        [XmlEnum("minExclusive")]
        MinExclusive,
        /// <summary>
        /// Excluded upper bound<br/>
        /// <br/>
        /// Defines the excluded upper bound of numeric data types, i.e. 'count', 'float', 'integer', 'number', 'numeric', 'range-inter', 'range-numeric', 'set-integer' or 'setnumeric'.
        /// </summary>
        [XmlEnum("maxExclusive")]
        MaxExclusive,
        /// <summary>
        /// Digits<br/>
        /// <br/>
        /// Defines the maximum number of digits of numeric data types, i.e. 'count', 'float', 'integer', 'number', 'numeric', 'range-integer', 'range-numeric', 'set-integer' oder 'set-numeric'.
        /// </summary>
        [XmlEnum("totalDigits")]
        TotalDigits,
        /// <summary>
        /// Decimal places<br/>
        /// <br/>
        /// Defines the maximum number of decimal places.
        /// </summary>
        [XmlEnum("fractionDigits")]
        FractionDigits
    }
}
