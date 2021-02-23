using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Reference to a skeleton agreement)<br/>
    /// <br/>
    /// This element serves for referring to a skeleton agreement, which is relevant for the business document.<br/>
    /// Agreements which cannot be transported in the business document itself are regulated in this skeleton agreement.
    /// </summary>
    public class Agreement
    {
        /// <summary>
        /// (optional) Agreement type<br/>
        /// <br/>
        /// Owner of the skeleton agreement.<br/>
        /// If reference is made to skeleton agreements of an intermediary, the element value should point to the intermediary.<br/>
        /// Some target systems are not in a position to interpret other values than the pre-defined ones.
        /// See <see cref="AgreementTypeValues"/>.
        /// </summary>
        [XmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (optional) Default flag<br/>
        /// <br/>
        /// This attribute marks a standard agreement.
        /// </summary>
        [XmlAttribute("default")]
        public bool Default { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DefaultSpecified => Default;

        /// <summary>
        /// (required) Skeleton agreement ID<br/>
        /// <br/>
        /// Unique identifier of the skeleton agreement.<br/>
        /// The element can also be used for special agreement information, e.g. special project-related agreements.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("AGREEMENT_ID")]
        public string AgreementId { get; set; }

        /// <summary>
        /// (optional) Line number within the skeleton agreement<br/>
        /// <br/>
        /// Unique line number within a skeleton agreement.<br/>
        /// This element allows a unique reference to a line of a skeleton agreement.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AGREEMENT_LINE_ID")]
        public string AgreementLineId { get; set; }

        /// <summary>
        /// (optional) Start date of the skeleton agreement<br/>
        /// <br/>
        /// Unique time stamp of the time, when the skeleton agreement begins.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("AGREEMENT_START_DATE")]
        public DateTime? AgreementStartDate { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementStartDateSpecified => AgreementStartDate.HasValue;

        /// <summary>
        /// (required) End date of the skeleton agreement<br/>
        /// <br/>
        /// Unique time stamp for the time when the skeleton agreement ends.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [Required]
        [BMEXmlElement("AGREEMENT_END_DATE")]
        public DateTime AgreementEndDate { get; set; }

        /// <summary>
        /// (optional) Reference to supplier<br/>
        /// <br/>
        /// Reference to the supplier.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SUPPLIER_IDREF")]
        public SupplierIdref SupplierIdref { get; set; }

        /// <summary>
        /// (optional) Description of the skeleton agreement<br/>
        /// <br/>
        /// This element is used to describe the skeleton agreement.
        /// </summary>
        [XmlElement("AGREEMENT_DESCR")]
        public List<MultiLingualString> AgreementDescriptions { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AgreementDescriptionsSpecified => AgreementDescriptions?.Count > 0;

        /// <summary>
        /// (optional) Additional multimedia information<br/>
        /// <br/>
        /// Information about multimedia files.<br/>
        /// For instance the sceleton agreement of the document could be added.
        /// </summary>
        [XmlElement("MIME_INFO")]
        public MimeInfo? MimeInfo { get; set; }
    }
}
