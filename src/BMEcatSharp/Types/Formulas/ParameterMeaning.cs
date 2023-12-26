using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// See <see cref="ParameterDefinition.Meaning"/>.
/// </summary>
public enum ParameterMeaning
{
    /// <summary>
    /// Allowance or charge<br/>
    /// <br/>
    /// The parameter contains an allowance or charge.
    /// </summary>
    [XmlEnum("allow_or_charge")]
    AllowOrCharge,

    /// <summary>
    /// Tax rate<br/>
    /// <br/>
    /// The parameter contains a tax rate.
    /// </summary>
    [XmlEnum("tax")]
    TaxRate
}
