using System.Xml.Serialization;

namespace OpenTransSharp
{
    public enum PartyRole
    {
        /// <summary>
        /// Buyer<br/>
        /// <br/>
        /// The business partner is a buyer.
        /// </summary>
        [XmlEnum("buyer")]
        Buyer,
        /// <summary>
        /// Centralized settlement<br/>
        /// <br/>
        /// The business party is a centralized settlement and supports the business of several partners
        /// </summary>
        [XmlEnum("central_regulator")]
        CentralRegulator,
        /// <summary>
        /// Customer<br/>
        /// <br/>
        /// The business party is the customer of the buying company.
        /// </summary>
        [XmlEnum("customer")]
        Customer,
        /// <summary>
        /// Transporation party, carrier<br/>
        /// <br/>
        /// The business party is the carrier.
        /// </summary>
        [XmlEnum("deliverer")]
        Deliverer,
        /// <summary>
        /// Location of shipment<br/>
        /// <br/>
        /// The business party is the location of the product shipment or where the service is afforded.
        /// </summary>
        [XmlEnum("delivery")]
        Delivery,
        /// <summary>
        /// Document creator<br/>
        /// <br/>
        /// The business partner is the creator of the document.
        /// </summary>
        [XmlEnum("document_creator")]
        DocumentCreator,
        /// <summary>
        /// Final shipment location<br/>
        /// <br/>
        /// Caution:<br/>
        /// Reference to address and contact of the final recipient.<br/>
        /// The federal office of export control currently only evaluates on order-header-level. Therefore orders related to exports should not use a party in this element which is different to the header-level element FINAL_DELIVERY_PARTY.
        /// </summary>
        [XmlEnum("final_delivery")]
        FinalDelivery,
        /// <summary>
        /// Intermediate<br/>
        /// <br/>
        /// The business party is an intermediate between product/service provider and benefit recipient.
        /// </summary>
        [XmlEnum("intermediary")]
        Intermediary,
        /// <summary>
        /// Invoicing party<br/>
        /// <br/>
        /// The business party is the invoicing party.
        /// </summary>
        [XmlEnum("invoice_issuer")]
        InvoiceIssuer,
        /// <summary>
        /// Invoice recipient<br/>
        /// <br/>
        /// The business party is the invoice receiving party.
        /// </summary>
        [XmlEnum("invoice_recipient")]
        InvoiceRecipient,
        /// <summary>
        /// IPP operator<br/>
        /// <br/>
        /// The business partner operatores an IPP application.
        /// </summary>
        [XmlEnum("ipp_operator")]
        IppOperator,
        /// <summary>
        /// Manufacturer<br/>
        /// <br/>
        /// The business partner is a manufacturer.
        /// </summary>
        [XmlEnum("manufacturer")]
        Manufacturer,
        /// <summary>
        /// Market place<br/>
        /// <br/>
        /// The business party runs an electronic market place supporting the processing of procurement and distribution of products and services.
        /// </summary>
        [XmlEnum("marketplace")]
        Marketplace,
        /// <summary>
        /// Payer<br/>
        /// <br/>
        /// The business party is the payer.
        /// </summary>
        [XmlEnum("payer")]
        Payer,
        /// <summary>
        /// Remittee<br/>
        /// <br/>
        /// The business party is the remittee.
        /// </summary>
        [XmlEnum("remittee")]
        Remittee,
        /// <summary>
        /// Standardization body<br/>
        /// <br/>
        /// The business partner is a standardization body.
        /// </summary>
        [XmlEnum("standardization_body")]
        StandardizationBody,
        /// <summary>
        /// Supplier<br/>
        /// <br/>
        /// The business partner is a supplier.
        /// </summary>
        [XmlEnum("supplier")]
        Supplier,
        /// <summary>
        /// Trusted Third Party<br/>
        /// <br/>
        /// A trusted instance that e.g. signed and verified the attached digital signature.
        /// </summary>
        [XmlEnum("trustedthirdparty")]
        Trustedthirdparty,
        /// <summary>
        /// Other<br/>
        /// <br/>
        /// If no other role matches this value can be used.
        /// </summary>
        [XmlEnum("other")]
        Other
    }
}
