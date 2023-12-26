using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp;

/// <summary>
/// (Invoice list)<br/>
/// <br/>
/// The business document INVOICELIST is used to represent several documents which are comparable in structure.<br/>
/// The element INVOICELIST_TYPE indicates which particular document is used.The three document types are:<br/>
/// <list type="bullet">
/// <item>
/// Collective Invoice:<br/>
/// The collective invoice is a collection of several invoices in a way conform to the german Value Added Tax Act.<br/>
/// If the single invoices are not compliant to the VAT Act one can catch up this via one VAT compliant collective invoice.<br/>
/// <br/>
/// A collective invoice is always transmitted from an invoicing party (INVOICE_ISSUER_IDREF) to an invoice receipting party (INVOICE_RECIPIENT_IDREF).<br/>
/// This is specified in the element INVOICELIST_INFO.<br/>
/// The sub-elements INVOICE_ISSUER_IDREF and INVOICE_RECIPIENT_IDREF of INVOICELIST_ITEM are not used in this case.<br/>
/// The invoicing party is the supplier and the buyer receipts the invoice.<br/>
/// The concept of a collective invoice should not be confused with the colloquial used term of a collective invoice as an invoice comprising of several delivery notes or orders.<br/>
/// This 'traditional' collective invoice is represented via the INVOICE business document.
/// </item>
/// <item>Collective credit note:<br/>
/// <br/>
/// The collective credit note is a collection of several credit memos in a way conform to the german Value Added Tax Act.<br/>
/// If the single credit memos are not compliant to the VAT Act one can catch up this via one VAT compliant collective credit memo.<br/>
/// A collective credit note is always transmitted from an invoicing party (INVOICE_ISSUER_IDREF) to an invoice receipting party (INVOICE_RECIPIENT_IDREF).<br/>
/// This is specified in the element INVOICELIST_INFO.<br/>
/// The sub-elements INVOICE_ISSUER_IDREF and INVOICE_RECIPIENT_IDREF of INVOICELIST_ITEM are not used in this case.<br/>
/// The invoicing party is the buyer and the supplier receipts the invoice.<br/>
/// The roles are interchanged in comparison to the collective invoice.
/// </item>
/// <item>
/// Invoice list:<br/>
/// An invoice list is usually used when invoices of several invoicing parties (INVOICE_ISSUER_IDREF) are sent to one invoice recipient (INVOICE_RECIPIENT_IDREF) or invoices of one invoicing party are sent to several invoice recipients.<br/>
/// Particularly in scenarios with intermediates (e.g.via centralised settlement).<br/>
/// This document type allows specifying several invoicing parties (INVOICE_ISSUER_IDREF) and invoice recipients (INVOICE_RECIPIENT_IDREF) in the element INVOICELIST_ITEM on invoice line item level.<br/>
/// To explicitly define the direction of the document flow the element DOCEXCHANGE_PARTIES_REFERENCE should be used.<br/>
/// </item>
/// </list>
/// Every valid business document INVOICELIST is introduced via the root element INVOICELIST in openTRANS® and contains a header (INVOICELIST_HEADER), an item level (INVOICELIST_ITEM_LIST) and a summary (INVOICELIST_SUMMARY).<br/>
/// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on the used currency.<br/>
/// The header also lays down default settings for the following item level.<br/>
/// The item level contains the individual positions in the invoice list.<br/>
/// Here the information is transferred from the header on the item level provided the item level has not been overwritten.<br/>
/// This principle is valid for all elements.<br/>
/// The summary contains a summary of the informations of the invoice list.<br/>
/// The information in this element is redundant and can be used for control and statistical evaluation.
/// </summary>
[XmlRoot(Namespace = "http://www.opentrans.org/XMLSchema/2.1", ElementName = "INVOICELIST")]
[Serializable]
public class InvoiceList : IOpenTransRoot
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = global::BMEcatSharp.Internal.SharedXmlNamespaces.Xmlns;

    /// <summary>
    /// <inheritdoc cref="InvoiceList"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public InvoiceList() { }

    /// <summary>
    /// <inheritdoc cref="InvoiceList"/>
    /// </summary>
    /// <param name="version"></param>
    /// <param name="header"></param>
    /// <param name="items"></param>
    /// <param name="summary"></param>
    public InvoiceList(OpenTransVersion version, InvoiceListHeader header, IEnumerable<InvoiceListItem> items, InvoiceListSummary summary)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        Version = version;
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Items = items.ToList();
        Summary = summary ?? throw new ArgumentNullException(nameof(summary));
    }


    /// <summary>
    /// (required) Indicates the version of the openTRANS® Standard to which the business document corresponds.<br/>
    /// <br/>
    /// Value range: "Major Version"."Minor Version" (Example: "1.0")
    /// </summary>
    [XmlAttribute("version")]
    public OpenTransVersion Version { get; set; } = OpenTransVersion.v2_1;

    /// <summary>
    /// (required) Header level<br/>
    /// <br/>
    /// The header level is used to transfer information about business partners and the business document and enter default settings which can be overwritten on item level.
    /// </summary>
    [XmlElement("INVOICELIST_HEADER")]
    public InvoiceListHeader Header { get; set; } = new InvoiceListHeader();

    /// <summary>
    /// (required) Item level<br/>
    /// <br/>
    /// The item level lists the individual positions of the order.
    /// </summary>
    [XmlArray("INVOICELIST_ITEM_LIST")]
    [XmlArrayItem("INVOICELIST_ITEM")]
    public List<InvoiceListItem> Items { get; set; } = new List<InvoiceListItem>();

    /// <summary>
    /// (required) Summary<br/>
    /// <br/>
    /// Summary of the request for order information. The information in this element is redundant.
    /// </summary>
    [XmlElement("INVOICELIST_SUMMARY")]
    public InvoiceListSummary Summary { get; set; } = new InvoiceListSummary();
}
