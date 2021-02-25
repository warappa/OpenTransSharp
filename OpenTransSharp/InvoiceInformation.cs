using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice information)<br/>
    /// <br/>
    /// In the element, INVOICE _INFO information is summarized on the procurement activities which preceded this order.<br/>
    /// When the element INVOICE _INFO is used, at least one of the following elements must be specified.
    /// </summary>
    public class InvoiceInformation
    {
        /// <summary>
        /// (required) Invoice number<br/>
        /// <br/>
        /// Unique invoice number of the supplier.
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        [XmlElement("INVOICE_ID")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// (required) Invoice date<br/>
        /// <br/>
        /// Dates of the invoice.<br/>
        /// In case of a credit card statement, INVOICE_DATE is the charge-date (the date, when the transaction occured).
        /// </summary>
        [Required]
        [XmlElement("INVOICE_DATE")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// (optional) Intended purpose<br/>
        /// <br/>
        /// Intended purpose especially regarding financial transactions and particularly bank transfers.
        /// </summary>
        [XmlElement("REASON_FOR_TRANSFER")]
        public string? ReasonForTransfer { get; set; }

        /// <summary>
        /// (optional) Invoice type<br/>
        /// <br/>
        /// Specifies if the document is an invoice, an invoice copy, an advice of amendment or a credit memo (in the sense of german Value Added Tax Act).<br/>
        /// <br/>
        /// In the case of the credit memo the creator is the buying partner and it replaces the invoice of the supplying company.
        /// </summary>
        [XmlElement("INVOICE_TYPE")]
        public InvoiceType? InvoiceType { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InvoiceTypeSpecified => InvoiceType.HasValue;

        /// <summary>
        /// (optional) Invoice coverage<br/>
        /// <br/>
        /// The element describes the scope of the invoice, i.e. if it is about a single invoice or a collective invoice.<br/>
        /// An individual or single invoice contains only items refering to one order.<br/>
        /// A collective invoice comprises of items refering to several orders.
        /// </summary>
        [XmlElement("INVOICE_COVERAGE")]
        public InvoiceCoverage? InvoiceCoverage { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InvoiceCoverageSpecified => InvoiceCoverage.HasValue;

        /// <summary>
        /// (optional) Delivery note number<br/>
        /// <br/>
        /// Unique delivery note number.<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [XmlElement("DELIVERYNOTE_ID")]
        public string? DeliverynoteId { get; set; }

        /// <summary>
        /// (optional) Delivery date<br/>
        /// <br/>
        /// Date of shipment.<br/>
        /// <br/>
        /// The delivery date specifies the date the commissioned goods are accepted by the buyer.<br/>
        /// If the delivery date deviates from the one specified in the header, the delivery date on item level is valid.<br/>
        /// To specify exact one date for the shipment, e.g. in the RECEIPTACKNOWLEDGEMENT-document, both sub-elements the DELIVERY_DATE and the DELIVERY_END_DATE should be the equal.
        /// </summary>
        [XmlElement("DELIVERY_DATE")]
        public DeliveryDate? DeliveryDate { get; set; }

        /// <summary>
        /// (optional) Reference to final recipient<br/>
        /// <br/>
        /// Reference to the unique identifier of the final recipient (shipping address and contact).<br/>
        /// The element has to refer to a PARTY_ID in the same document.
        /// </summary>
        [XmlElement("DELIVERY_IDREF")]
        public DeliveryIdref? DeliveryIdref { get; set; }

        /// <summary>
        /// (optional) Language<br/>
        /// <br/>
        /// Specification of used languages, especially the default language of all language-dependent information<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LANGUAGE")]
        public List<Language>? Languages { get; set; } = new List<Language>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LanguagesSpecified => Languages?.Count > 0;

        /// <summary>
        /// (optional) MIME root directory<br/>
        /// <br/>
        /// A relative directory can be entered here (and/or a URI), i.e. one to which the relative paths in MIME_SOURCE refer.<br/>
        /// <br/>
        /// Max length: 250<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIME_ROOT")]
        public MultiLingualString? MimeRoot { get; set; }

        /// <summary>
        /// (required) Parties<br/>
        /// <br/>
        /// List of parties that are relevant to this business document.
        /// </summary>
        [Required]
        [XmlArray("PARTIES")]
        [XmlArrayItem("PARTY")]
        public List<Party> Parties { get; set; } = new List<Party>();

        /// <summary>
        /// (requireed) Reference to invoicing party<br/>
        /// <br/>
        /// Reference to an unique identifier of the invoicing party. The element refers to a PARTY_ID in the same document.<br/>
        /// </summary>
        [Required]
        [XmlElement("INVOICE_ISSUER_IDREF")]
        public InvoiceIssuerIdref InvoiceIssuerIdref { get; set; }

        /// <summary>
        /// (required) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [Required]
        [XmlElement("INVOICE_RECIPIENT_IDREF")]
        public InvoiceRecipientIdref InvoiceRecipientIdref { get; set; }

        /// <summary>
        /// (optional) Reference to the buyer<br/>
        /// <br/>
        /// Reference to the buyer.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (PARTY element).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("BUYER_IDREF")]
        public BuyerIdref? BuyerIdref { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref? SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Reference to the payer<br/>
        /// <br/>
        /// Reference to a unique identifier of the payer.<br/>
        /// The element refers to a PARTY_ID in the same document.
        /// </summary>
        [XmlElement("PAYER_IDREF")]
        public PayerIdref? PayerIdref { get; set; }

        /// <summary>
        /// (optional) Reference to a remittee<br/>
        /// <br/>
        /// Refers to a unique identifier of the remittee.<br/>
        /// The elemente refers to the PARTY_ID of the remittee in the same document.
        /// </summary>
        [XmlElement("REMITTEE_IDREF")]
        public RemitteeIdref? RemitteeIdref { get; set; }

        /// <summary>
        /// (optional) Document exchange parties<br/>
        /// <br/>
        /// Reference to the business partners who take part in the document exchange.
        /// </summary>
        [XmlElement("DOCEXCHANGE_PARTIES_REFERENCE")]
        public DocexchangePartiesReference? DocexchangePartiesReference { get; set; }

        /// <summary>
        /// (required) Currency<br/>
        /// <br/>
        /// Provides the currency that is default for all price information in the catalog. If the price of a product has a different currency, or this element is not used, the the currency has to be specified in the PRICE_CURRENCY element for the respective product.<br/>
        /// <br/>
        /// Caution:<br/>
        /// Therefore, the currency must be specified in the catalog header or for each product separately.It is recommended to define a default currency.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [MinLength(3)]
        [MaxLength(3)]
        [Required]
        [BMEXmlElement("CURRENCY")]
        public string Currency { get; set; }

        /// <summary>
        /// (optional) Mode of payment<br/>
        /// <br/>
        /// Payment procedure<br/>
        /// <br/>
        /// Caution:<br/>
        /// The PAYMENT element is to be interpreted by the recipient of the document as a requested mode of payment. The binding payment procedure is laid down in the order.
        /// </summary>
        [XmlElement("PAYMENT")]
        public Payment? Payment { get; set; }

        /// <summary>
        /// (optional) GTC<br/>
        /// <br/>
        /// General terms and conditions.
        /// </summary>
        [MinLength(1)]
        [MaxLength(250)]
        [XmlElement("TERMS_AND_CONDITIONS")]
        public string? TermsAndConditions { get; set; }

        /// <summary>
        /// (optional) Accounting information<br/>
        /// <br/>
        /// Information on the accounting treatment of costs incurred by the buyer as a result of the order.<br/>
        /// This information is supplied by the buyer to allow the supplier to include it in the following invoice, thereby making invoice verification by the buyer easier.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("ACCOUNTING_INFO")]
        public AccountingInformation? AccountingInformation { get; set; }

        /// <summary>
        /// (optional) E-Billing informations<br/>
        /// <br/>
        /// Informations according E-Billing.
        /// </summary>
        [BMEXmlElement("E_BILLING")]
        public EBilling? EBilling { get; set; }

        /// <summary>
        /// (optional) Logistics information<br/>
        /// <br/>
        /// The element contains logistical details in document level (HEADER).
        /// </summary>
        [BMEXmlElement("LOGISTIC_DETAILS_INFO")]
        public LogisticDetailsInformation? LogisticDetailsInformation { get; set; }

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
        /// (optional) User-defined extension<br/>
        /// <br/>
        /// This element can be used for transferring information in user-defined non-openTRANS-elements; hence it is possible to extend the pre-defined set of openTRANS-elements by user-defined ones. The usage of those elements results in openTRANS business documents, which can only be exchanged between the companies that have agreed on these extensions. The structure of these elements can be very complex, though it must be valid XML.<br/>
        /// <br/>
        /// &lt;User Defined Extensions&gt; are defined exclusively as optional fields. Therefore, it is expressly pointed out that if user-defined extensions are used they must be compatible with the target systems and should be clarified on a case-to-case basis.<br/>
        /// <br/>
        /// The names of the elements must be clearly distinguishable from the names of other elements contained in the openTRANS standard.For this reason, all element must start with the string "UDX" (Example: &lt;UDX.supplier.elementname&gt;).<br/>
        /// <br/>
        /// The definition of user-defined extensions takes place by additional XML DTD or XML-Schema files.
        /// </summary>
        [XmlArray("HEADER_UDX")]
        public List<object>? HeaderUdx { get; set; } = new List<object>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HeaderUdxSpecified => HeaderUdx?.Count > 0;
    }
}
