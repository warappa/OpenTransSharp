﻿namespace OpenTransSharp;

/// <summary>
/// (Fixed charge or allowance)<br/>
/// <br/>
/// Description of a fixed surcharge or allowance.<br/>
/// <br/>
/// Caution:<br/>
/// Please ensure that the allowances and charges are only used at allowed document positions.<br/>
/// E.g. cash_discounts should be used only in PAYMENT_TERMS.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class AllowOrCharge
{
    /// <summary>
    /// <inheritdoc cref="AllowOrCharge"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AllowOrCharge()
    { }

    /// <summary>
    /// <inheritdoc cref="AllowOrCharge"/>
    /// </summary>
    /// <param name="type"></param>
    public AllowOrCharge(AllowOrChargeType type)
    {
        Type = type;
    }

    /// <summary>
    /// (required) Allowance or surcharge<br/>
    /// <br/>
    /// Indicates if the element is about an allowance or a surcharge.
    /// </summary>
    [XmlAttribute("type")]
    public AllowOrChargeType Type { get; set; } = AllowOrChargeType.Surcharge;

    /// <summary>
    /// (optional) Calculation sequence<br/>
    /// <br/>
    /// This element indicates the sequence for the application of the allowance or surcharge on the amount.<br/>
    /// The allowances or surcharges are applied in ascending order of the value of the element ALLOW_OR_CHARGE_SEQUENCE.<br/>
    /// That means the allowance or surcharge with the lowest value are applied first to the original amount or (if available) to the ALLOW_OR_CHARGE_BASE.<br/>
    /// Afterwards the surcharges are being added and the allowances are subtracted and the surcharges of the next higher value are determined based on the new calculated amount.
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_SEQUENCE")]
    public int? Sequence { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SequenceSpecified => Sequence.HasValue;

    /// <summary>
    /// (optional) Allowance or surcharge-name<br/>
    /// <br/>
    /// Short name for the allowance or surcharge (e.g. freight, packaging, ...).
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_NAME")]
    public List<global::BMEcatSharp.MultiLingualString>? Names { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool NamesSpecified => Names?.Count > 0;

    /// <summary>
    /// (optional) Allowance or surcharge-type<br/>
    /// <br/>
    /// Typification of the type of the allowance or surcharge (e.g. freight, postage and packing,...).<br/>
    /// See <see cref="AllowOrChargeTypeValues"/>.
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_TYPE")]
    public string? SpecificType { get; set; }

    /// <summary>
    /// (optional) Allowance or surcharge description<br/>
    /// <br/>
    /// Textual description of the allowance or surcharge.<br/>
    /// This element can be used to supply additional information about the allowance or surcharge-reason.<br/>
    /// <br/>
    /// Examples: In case of island-surcharges the name of the island can be quoted here or the contract reference in case of project reimbursements.<br/>
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_DESCR")]
    public List<global::BMEcatSharp.MultiLingualString>? Descriptions { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionsSpecified => Descriptions?.Count > 0;

    /// <summary>
    /// (optional) Allowance or surcharge value<br/>
    /// <br/>
    /// Description of the structure of the allowance or surcharge.
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_VALUE")]
    public AllowOrChargeValue? Value { get; set; }

    /// <summary>
    /// (optional) Allowance or surcharge-base<br/>
    /// <br/>
    /// If declared, this element is the calculation base for the allowance or surcharge instead of the original value or the previous allowance or surcharge-calculations.
    /// </summary>
    [XmlElement("ALLOW_OR_CHARGE_BASE")]
    public decimal? Base { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool BaseSpecified => Base.HasValue;
}
