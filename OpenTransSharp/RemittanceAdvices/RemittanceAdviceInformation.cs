﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Information related to the remittance advice)<br/>
    /// <br/>
    /// The element REMITTANCEADVICE_INFO specifies the scope of the remittance advice.<br/>
    /// If this element is used at least one of the following elements must be used.
    /// </summary>
    public class RemittanceAdviceInformation
    {
        /// <summary>
        /// (required) Number of the remittance advice<br/>
        /// <br/>
        /// Unique identifier of the remittance advice.
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        [XmlElement("REMITTANCEADVICE_ID")]
        public string RemittanceAdviceId { get; set; }

        /// <summary>
        /// (required) Remittance/Payment advice date<br/>
        /// <br/>
        /// Date of the payment advice.
        /// </summary>
        [Required]
        [XmlElement("REMITTANCEADVICE_DATE")]
        public DateTime RemittanceAdviceDate { get; set; }

        /// <summary>
        /// (optional) Intended purpose<br/>
        /// <br/>
        /// Intended purpose especially regarding financial transactions and particularly bank transfers.
        /// </summary>
        [XmlElement("REASON_FOR_TRANSFER")]
        public string? ReasonForTransfer { get; set; }

        /// <summary>
        /// (optional) Remittance/Payment advice type<br/>
        /// <br/>
        /// Describes the roles of the sender and recipient of the payment advice, i.e. specifies if the remittee triggers the direct debit and uses the payment advice as additional information for the payer or if the payer uses the advice of payment to document the payment.
        /// </summary>
        [XmlElement("REMITTANCEADVICE_TYPE")]
        public RemittanceAdviceType? RemittanceAdviceType { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemittanceAdviceTypeSpecified => RemittanceAdviceType.HasValue;

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
        /// (required) Reference to the payer<br/>
        /// <br/>
        /// Reference to a unique identifier of the payer.<br/>
        /// The element refers to a PARTY_ID in the same document.
        /// </summary>
        [Required]
        [XmlElement("PAYER_IDREF")]
        public PayerIdref? PayerIdref { get; set; }

        /// <summary>
        /// (required) Reference to a remittee<br/>
        /// <br/>
        /// Refers to a unique identifier of the remittee.<br/>
        /// The elemente refers to the PARTY_ID of the remittee in the same document.
        /// </summary>
        [Required]
        [XmlElement("REMITTEE_IDREF")]
        public RemitteeIdref? RemitteeIdref { get; set; }

        /// <summary>
        /// (optional) Reference to invoicing party<br/>
        /// <br/>
        /// Reference to an unique identifier of the invoicing party. The element refers to a PARTY_ID in the same document.<br/>
        /// </summary>
        [XmlElement("INVOICE_ISSUER_IDREF")]
        public InvoiceIssuerIdref? InvoiceIssuerIdref { get; set; }

        /// <summary>
        /// (optional) Reference to the recipient of the invoice<br/>
        /// <br/>
        /// Reference to an unique identifier to the recipient of the invoice.<br/>
        /// The element refers to a PARTY_ID of an invoice recipient in the same document.
        /// </summary>
        [XmlElement("INVOICE_RECIPIENT_IDREF")]
        public InvoiceRecipientIdref InvoiceRecipientIdref { get; set; }

        /// <summary>
        /// (optional) Document exchange parties<br/>
        /// <br/>
        /// Reference to the business partners who take part in the document exchange.
        /// </summary>
        [XmlElement("DOCEXCHANGE_PARTIES_REFERENCE")]
        public DocexchangePartiesReference? DocexchangePartiesReference { get; set; }

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
        /// (required) Time for payment<br/>
        /// <br/>
        /// Time where the payment is supposed to be done.
        /// </summary>
        [Required]
        [XmlElement("PAYMENT_DATE")]
        public DateTime? PaymentDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PaymentDateSpecified => PaymentDate.HasValue;

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