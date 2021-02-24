using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Item line)<br/>
    /// <br/>
    /// An item line refers to a group of invoices in the invoice list.<br/>
    /// These invoices are grouped in the summary.<br/>
    /// There may appear several item lines but there has to be at least one item line.
    /// </summary>
    public class InvoiceListItem
    {
        /// <summary>
        /// (required) Item number<br/>
        /// <br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// </summary>
        [Required]
        [XmlElement("LINE_ITEM_ID")]
        public string LineItemId { get; set; }

        /// <summary>
        /// (optional) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [XmlElement("INVOICE_RECIPIENT_IDREF")]
        public InvoiceRecipientIdref? InvoiceRecipientIdref { get; set; }

        /// <summary>
        /// (optional) Reference to final recipient<br/>
        /// <br/>
        /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [XmlElement("DELIVERY_IDREF")]
        public DeliveryIdref? DeliveryIdref { get; set; }

        /// <summary>
        /// (optional) Reference to invoicing party<br/>
        /// <br/>
        /// Reference to an unique identifier of the invoicing party. The element refers to a PARTY_ID in the same document.<br/>
        /// </summary>
        [XmlElement("INVOICE_ISSUER_IDREF")]
        public InvoiceIssuerIdref? InvoiceIssuerIdref { get; set; }

        /// <summary>
        /// (optional) Accounting period<br/>
        /// <br/>
        /// The time period reflected by a set of invoices.
        /// </summary>
        [XmlElement("ACCOUNTING_PERIOD")]
        public AccountingPeriod? AccountingPeriod { get; set; }

        /// <summary>
        /// (optional) Credit Limit<br/>
        /// <br/>
        /// The credit limit or credit line is the maximum amount you can borrow against your credit card.
        /// </summary>
        [XmlElement("CREDIT_LIMIT")]
        public decimal? CreditLimit { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CreditLimitSpecified => CreditLimit.HasValue;

        /// <summary>
        /// (optional) Opening Balance<br/>
        /// <br/>
        /// The opening balance or old balance is equivalent to the new balance of the last credit card statement.<br/>
        /// It is used as a basis to prepare the current statement.<br/>
        /// <br/>
        /// Please note: Subject to the used statement(credit, pre-paid), this amount can be e.g. the amount owed at the time of the last statement.<br/>
        /// The usage of +/- signs has to be clarified between the parties.<br/>
        /// Please refer to CLOSING_BALANCE for an example.
        /// </summary>
        [XmlElement("OPENING_BALANCE")]
        public decimal? OpeningBalance { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OpeningBalanceSpecified => OpeningBalance.HasValue;

        /// <summary>
        /// (optional) Invoice list <br/>
        /// <br/>
        /// List of every single invoices in a group of invoices.
        /// </summary>
        [XmlElement("IL_INVOICE_LIST")]
        public ILInvoiceList ILInvoiceList { get; set; }

        /// <summary>
        /// (optional) Number of item lines<br/>
        /// <br/>
        /// Contains the total number of item lines in the business document.<br/>
        /// The information is redundant and is for the purposes of statistical evaluation (e.g. by an intermediary) if appropriate.
        /// </summary>
        [XmlElement("TOTAL_ITEM_NUM")]
        public int TotalItemCount { get; set; }

        /// <summary>
        /// (required) Net value <br/>
        /// <br/>
        /// Total amout of all items in this invoice excluding taxes.
        /// </summary>
        [Required]
        [XmlElement("NET_VALUE_GOODS")]
        public decimal NetValueGoods { get; set; }

        /// <summary>
        /// (optional) Net value <br/>
        /// <br/>
        /// Total amout of all items in this invoice excluding taxes.
        /// </summary>
        [XmlElement("NET_VALUE_EXTRA")]
        public decimal? NetValueExtra { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NetValueExtraSpecified => NetValueExtra.HasValue;

        /// <summary>
        /// (optional) Fixed allowance or surcharges<br/>
        /// <br/>
        /// A list of fixed allowances or surcharges which are to be applied on the price.
        /// </summary>
        [XmlElement("ALLOW_OR_CHARGES_FIX")]
        public AllowOrChargesFix AllowOrChargesFix { get; set; }

        /// <summary>
        /// (required) Number of item lines<br/>
        /// <br/>
        /// Total amount covering all items in this business document.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Changed definition:<br/>
        /// Gross price including surcharges, deductions and all taxes.<br/>
        /// Where no price per item can be given as the item level (e.g.bills of materials where explosion is not possible), the total price can be entered here.
        /// </summary>
        [Required]
        [XmlElement("TOTAL_AMOUNT")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// (required) Total taxes <br/>
        /// <br/>
        /// List of the tax amount.
        /// </summary>
        [Required]
        [XmlElement("TOTAL_TAX")]
        public TotalTax TotalTax { get; set; }

        /// <summary>
        /// (optional) Direct debit <br/>
        /// <br/>
        /// Amount which is debited from the account.<br/>
        /// This element appears in documents of invoicelists.<br/>
        /// Usually the direct debit results from a negative total amount on a credit card statement.<br/>
        /// This depends on credit card institute and country of the document.<br/>
        /// Please refer to CLOSING_BALANCE for further details on this issue and an example.
        /// </summary>
        [XmlElement("DIRECT_DEBIT")]
        public decimal? DirectDebit { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DirectDebitSpecified => DirectDebit.HasValue;

        /// <summary>
        /// (optional) Closing Balance <br/>
        /// <br/>
        /// The Closing balance or new balance represents the sum of the opening balance (OPENING_BALANCE), the various positions in the document including finance charges, taxes etc. (TOTAL_AMOUNT) and the direct debited amount (DIRECT_DEBIT).<br/>
        /// <br/>
        /// Please note: Subject to the used statement (credit, pre-paid) and the country of the credit-institute, this amount can be e.g. the amount owed at the time of the last statement.<br/>
        /// The usage of +/- signs has to be clarified between the parties.<br/>
        /// In some countries credit card statements present debts with positive amounts.
        /// </summary>
        [XmlElement("CLOSING_BALANCE")]
        public decimal? ClosingBlance { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClosingBlanceSpecified => ClosingBlance.HasValue;

        /// <summary>
        /// (optional) Amount over credit limit<br/>
        /// <br/>
        /// Indicates by what amount your balance exceeded your credit limit (CREDIT_LIMIT).
        /// </summary>
        [XmlElement("AMOUNT_OVER_CREDIT_LIMIT")]
        public decimal? AmountOverCreditLimit { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AmountOverCreditLimitSpecified => AmountOverCreditLimit.HasValue;

        /// <summary>
        /// (optional) Available credit <br/>
        /// <br/>
        /// It is the difference between your credit limit and total amount due. See CLOSING_BALANCE for an example.
        /// </summary>
        [XmlElement("CREDIT_AVAILABLE")]
        public decimal? CreditAvailable { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CreditAvailableSpecified => CreditAvailable.HasValue;

        /// <summary>
        /// (optional) Rewards <br/>
        /// <br/>
        /// This element provides the possibilty to publish the rewards points which appeared with transactions.<br/>
        /// The element can be used directly for transactions in IL_INVOICE_LIST_ITEM and as summary in the element INVOICELIST_ITEM.
        /// </summary>
        [XmlElement("REWARDS")]
        public List<Rewards>? Rewards { get; set; } = new List<Rewards>();

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// </summary>
        [XmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }

        /// <summary>
        /// (optional) Remark<br/>
        /// <br/>
        /// Remark related to a business document.
        /// </summary>
        [XmlElement("REMARKS")]
        public List<Remark> Remarks { get; set; } = new List<Remark>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemarksSpecified => Remarks?.Count > 0;

        /// <summary>
        /// (optional) User-defined extensions<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones.<br/>
        /// <br/>
        /// The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions.<br/>
        /// The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// Caution:<br/>
        /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.<br/>
        /// For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// <br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML.
        /// </summary>
        [XmlArray("ITEM_UDX")]
        public List<object> ItemUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ItemUdxSpecified => ItemUdx?.Count > 0;
    }
}
