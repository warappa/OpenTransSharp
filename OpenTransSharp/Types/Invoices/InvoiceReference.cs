using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Invoice reference)<br/>
    /// <br/>
    /// The element contains a reference to an invoice of invoice line item.<br/>
    /// If a (complete) invoice is referenced the sub-element LINE_ITEM_ID should not be specified.
    /// </summary>
    public class InvoiceReference
    {
        /// <summary>
        /// <inheritdoc cref="InvoiceReference"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InvoiceReference()
        {
            Id = null!;
        }

        /// <summary>
        /// <inheritdoc cref="InvoiceReference"/>
        /// </summary>
        /// <param name="id"></param>
        public InvoiceReference(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// (optional) Invoice type<br/>
        /// <br/>
        /// Specifies the type of the referenced business document (invoice or invoice list).
        /// </summary>
        [XmlIgnore]
        public InvoiceType? Type { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("type")]
        public InvoiceType TypeForSerializer { get => Type ?? InvoiceType.Undefined; set => Type = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TypeForSerializerSpecified => Type.HasValue;

        /// <summary>
        /// (required) Invoice number<br/>
        /// <br/>
        /// Unique invoice number of the supplier.
        /// </summary>
        [XmlElement("INVOICE_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (Optional) Item number<br/>
        /// <br/>
        /// The item ID number is used to uniquely identify the item line of an order within that order.<br/>
        /// In combination with the order number and the buyer the item number represents a unique ID number outside the business process concerned.<br/>
        /// <br/>
        /// Example.: P100012
        /// </summary>
        [XmlElement("LINE_ITEM_ID")]
        public string? LineItemId { get; set; }

        /// <summary>
        /// (optional) Invoice date<br/>
        /// <br/>
        /// Dates of the invoice.<br/>
        /// In case of a credit card statement, INVOICE_DATE is the charge-date (the date, when the transaction occured).
        /// </summary>
        [XmlElement("INVOICE_DATE")]
        public DateTime? Date { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DateSpecified => Date.HasValue;

        /// <summary>
        /// (optional) Post date<br/>
        /// <br/>
        /// The post date specifies the date, that the transaction was debited or credited to your account.
        /// </summary>
        [XmlElement("POST_DATE")]
        public DateTime? PostDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PostDateSpecified => PostDate.HasValue;

        /// <summary>
        /// (optional) Intended purpose <br/>
        /// <br/>
        /// Intended purpose especially regarding financial transactions and particularly bank transfers.
        /// </summary>
        [XmlElement("REASON_FOR_TRANSFER")]
        public string? ReasonForTransfer { get; set; }

        /// <summary>
        /// (optional) Description of the invoice<br/>
        /// <br/>
        /// Textual description of the invoice.
        /// </summary>
        [XmlElement("INVOICE_DESCR")]
        public List<global::BMEcatSharp.MultiLingualString> Descriptions { get; set; } = new List<global::BMEcatSharp.MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionsSpecified => Descriptions?.Count > 0;
    }
}
