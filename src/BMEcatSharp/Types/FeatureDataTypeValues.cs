using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="FeatureContent.DataType"/>.
/// </summary>
public enum FeatureDataTypeValues
{
    /// <summary>
    /// Alphanumeric<br/>
    /// <br/>
    /// Alphanumeric string.
    /// </summary>
    [XmlEnum("alphanumeric")]
    Alphanumeric,
    /// <summary>
    /// Boolan<br/>
    /// <br/>
    /// "true"/"false"
    /// </summary>
    [XmlEnum("boolean")]
    Boolean,
    /// <summary>
    /// Class instance type<br/>
    /// <br/>
    /// Reference to a classification group.<br/>
    /// By this type it is possible to define a feature that establishes a relationship to another product class; e.g., feature "component".<br/>
    /// <br/>
    /// This type has been adopted from the ISO 13584 standard.
    /// </summary>
    [XmlEnum("class_instance_type")]
    Class_instance_type,
    /// <summary>
    /// Positive number<br/>
    /// <br/>
    /// Positive number.
    /// </summary>
    [XmlEnum("count")]
    Count,
    /// <summary>
    /// Currency<br/>
    /// <br/>
    /// Currency code.
    /// </summary>
    [XmlEnum("currency")]
    Currency,
    /// <summary>
    /// Date<br/>
    /// <br/>
    /// Date.
    /// </summary>
    [XmlEnum("date")]
    Date,
    /// <summary>
    /// Date and time<br/>
    /// <br/>
    /// Date and time.
    /// </summary>
    [XmlEnum("date-time")]
    DateTime,
    /// <summary>
    /// Floating-point number<br/>
    /// <br/>
    /// Floating-point number.
    /// </summary>
    [XmlEnum("float")]
    Float,
    /// <summary>
    /// Integer value<br/>
    /// <br/>
    /// Integer value.
    /// </summary>
    [XmlEnum("integer")]
    Integer,
    /// <summary>
    /// Boolean Value<br/>
    /// <br/>
    /// "true" or "false".
    /// </summary>
    [XmlEnum("logic")]
    Logic,
    /// <summary>
    /// Named type<br/>
    /// <br/>
    /// Named type. This type has been adopted from the ISO 13584 standard.
    /// </summary>
    [XmlEnum("named_type")]
    Named_type,
    /// <summary>
    /// Number<br/>
    /// <br/>
    /// Number.
    /// </summary>
    [XmlEnum("number")]
    Number,
    /// <summary>
    /// Numeric<br/>
    /// <br/>
    /// Numeric.
    /// </summary>
    [XmlEnum("numeric")]
    Numeric,
    /// <summary>
    /// Integer range<br/>
    /// <br/>
    /// Range definition by two integer values.
    /// </summary>
    [XmlEnum("range-integer")]
    RangeInteger,
    /// <summary>
    /// Numeric range<br/>
    /// <br/>
    /// Range definition by two numeric values.
    /// </summary>
    [XmlEnum("range-numeric")]
    RangeNumeric,
    /// <summary>
    /// Alphanumeric set<br/>
    /// <br/>
    /// Set of alphanumeric values.
    /// </summary>
    [XmlEnum("set-alphanumeric")]
    SetAlphanumeric,
    /// <summary>
    /// Integer set<br/>
    /// <br/>
    /// Set of integer values.
    /// </summary>
    [XmlEnum("set-integer")]
    SetInteger,
    /// <summary>
    /// Numeric set<br/>
    /// <br/>
    /// Set of numeric values.
    /// </summary>
    [XmlEnum("set-numeric")]
    SetNumeric,
    /// <summary>
    /// Alphanumeric<br/>
    /// <br/>
    /// Alphanumeric string.
    /// </summary>
    [XmlEnum("string")]
    String,
    /// <summary>
    /// Time<br/>
    /// <br/>
    /// Time.
    /// </summary>
    [XmlEnum("time")]
    Time
}
