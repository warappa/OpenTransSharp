using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Mode of payment)<br/>
/// <br/>
/// The PAYMENT element summarizes information about the terms of payment.<br/>
/// Exactly one term of payment must be used.<br/>
/// If no information about payment is transferred (e.g. because this has been defined in a skeleton contract) the element is not used.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class Payment
{
    /// <summary>
    /// <inheritdoc cref="Payment"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Payment() { }

    /// <summary>
    /// <inheritdoc cref="Payment"/>
    /// </summary>
    /// <param name="card"></param>
    public Payment(Card card)
    {
        Card = card ?? throw new ArgumentNullException(nameof(card));
    }

    /// <summary>
    /// <inheritdoc cref="Payment"/>
    /// </summary>
    /// <param name="accounts"></param>
    public Payment(IEnumerable<Account> accounts)
    {
        if (accounts is null)
        {
            throw new ArgumentNullException(nameof(accounts));
        }

        Accounts = accounts.ToList();
    }

    /// <summary>
    /// <inheritdoc cref="Payment"/>
    /// </summary>
    /// <param name="debit"></param>
    /// <param name="cash"></param>
    /// <param name="check"></param>
    public Payment(bool debit, bool cash, bool check)
    {
        Debit = debit;
        Cash = cash;
        Check = check;
    }

    /// <summary>
    /// (required - choice Card/Account/Debit/Check/Cash) Card payment<br/>
    /// <br/>
    /// Use of credit cards, purchase cards etc.
    /// </summary>
    [OpenTransXmlElement("CARD")]
    public Card? Card { get; set; }

    /// <summary>
    /// (required - choice Card/Account/Debit/Check/Cash) Bank account<br/>
    /// <br/>
    /// Bank account details.
    /// </summary>
    [OpenTransXmlElement("ACCOUNT")]
    public List<Account>? Accounts { get; set; } = new List<Account>();

    /// <summary>
    /// (required - choice Card/Account/Debit/Check/Cash) Debit notification<br/>
    /// <br/>
    /// The element DEBIT specifies the credit note procedure as payment system.
    /// </summary>
    [XmlIgnore]
    public bool? Debit { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [OpenTransXmlElement("DEBIT")]
    public string? DebitForSerializer { get => Debit is null ? null : Debit == true ? "true" : "false"; set => Debit = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DebitForSerializerSpecified => Debit == true;

    /// <summary>
    /// (required - choice Card/Account/Debit/Check/Cash) Check payment<br/>
    /// <br/>
    /// The element CHECK specifies paying by check as payment system.
    /// </summary>
    [XmlIgnore]
    public bool? Check { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [OpenTransXmlElement("CHECK")]
    public string? CheckForSerializer { get => Check is null ? null : Check == true ? "true" : "false"; set => Check = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CheckForSerializerSpecified => Check == true;

    /// <summary>
    /// (required - choice Card/Account/Debit/Check/Cash) Cash payment<br/>
    /// <br/>
    /// The element CASH specifies cash payment as payment system.
    /// </summary>
    [XmlIgnore]
    public bool? Cash { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [OpenTransXmlElement("CASH")]
    public string? CashForSerializer { get => Cash is null ? null : Cash == true ? "true" : "false"; set => Cash = value is null ? null : value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CashForSerializerSpecified => Cash == true;

    /// <summary>
    /// (optional) Centralized settlement<br/>
    /// <br/>
    /// Indicates if the payment process is transacted via a centralized settlement.
    /// </summary>
    [XmlIgnore]
    public bool CentralRegulation { get; set; } = false;

    [EditorBrowsable(EditorBrowsableState.Never)]
    [OpenTransXmlElement("CENTRAL_REGULATION")]
    public string CentralRegulationForSerializer { get => CentralRegulation == true ? "true" : "false"; set => CentralRegulation = value.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool CentralRegulationForSerializerSpecified => CentralRegulation == true;

    /// <summary>
    /// (optional) Term of payment<br/>
    /// <br/>
    /// Information to payment terms.
    /// </summary>
    [OpenTransXmlElement("PAYMENT_TERMS")]
    public PaymentTerms? PaymentTerms { get; set; }
}
