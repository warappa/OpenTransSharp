using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// Permitted values vor <see cref="Mime.Purpose"/>.
    /// </summary>
    public enum MimePurpose
    {
        /// <summary>
        /// Declaration of conformity<br/>
        /// <br/>
        /// Declaration of conformity to confirm the conform usage of norms and standards.
        /// </summary>
        [XmlEnum("conformity")]
        Conformity,
        /// <summary>
        /// Product data sheet<br/>
        /// <br/>
        /// Product data sheet (e.g. a technical drawing)
        /// </summary>
        [XmlEnum("data_sheet")]
        DataSheet,
        /// <summary>
        /// Detail view<br/>
        /// <br/>
        /// Enlarged image.
        /// </summary>
        [XmlEnum("detail")]
        Detail,
        /// <summary>
        /// Anfahrtskizze, Gebäudeplan oder Stadtplan
        /// </summary>
        [XmlEnum("directions")]
        Directions,
        /// <summary>
        /// Copy of a fax<br/>
        /// <br/>
        /// Electronic copy of the original.
        /// </summary>
        [XmlEnum("fax_image")]
        FaxImage,
        /// <summary>
        /// Freehand sketch<br/>
        /// <br/>
        /// Freehand sketch of something (product etc.).
        /// </summary>
        [XmlEnum("freehand_sketch")]
        FreehandSketch,
        /// <summary>
        /// Icon<br/>
        /// <br/>
        /// Small icon, e.g to indicate the fullfilment of a standard.
        /// </summary>
        [XmlEnum("icon")]
        Icon,
        /// <summary>
        /// Logo<br/>
        /// <br/>
        /// Product or partner logo.
        /// </summary>
        [XmlEnum("logo")]
        Logo,
        /// <summary>
        /// Manual<br/>
        /// <br/>
        /// Manual of the product.
        /// </summary>
        [XmlEnum("manual")]
        Manual,
        /// <summary>
        /// Mounting guide<br/>
        /// <br/>
        /// Mounting, assembly or installation guide.
        /// </summary>
        [XmlEnum("mounting_guidelines")]
        MountingGuidelines,
        /// <summary>
        /// Normal view<br/>
        /// <br/>
        /// Normal view (normal size).
        /// </summary>
        [XmlEnum("normal")]
        Normal,
        /// <summary>
        /// Original document<br/>
        /// <br/>
        /// Representation of the document in human readable form (e.g. as PDF-file or graphic).
        /// </summary>
        [XmlEnum("original_document")]
        OriginalDocument,
        /// <summary>
        /// Repair instructions<br/>
        /// <br/>
        /// Repair instructions for a product.
        /// </summary>
        [XmlEnum("repair_manual")]
        RepairManual,
        /// <summary>
        /// Safety data sheet<br/>
        /// <br/>
        /// Safety data sheet (for dangerous materials, for example).
        /// </summary>
        [XmlEnum("safety_data_sheet")]
        SafetyDataSheet,
        /// <summary>
        /// Signatur file<br/>
        /// <br/>
        /// File containing an external signatur.
        /// </summary>
        [XmlEnum("signatur_file")]
        SignaturFile,
        /// <summary>
        /// Service description<br/>
        /// <br/>
        /// Description of the offered service or produkt.
        /// </summary>
        [XmlEnum("service_descr")]
        ServiceDescription,
        /// <summary>
        /// Service record<br/>
        /// <br/>
        /// Record of the activity, performance, achievment or a copy of the original.
        /// </summary>
        [XmlEnum("service_record")]
        ServiceRecord,
        /// <summary>
        /// Thumbnail view<br/>
        /// <br/>
        /// Preview (small).
        /// </summary>
        [XmlEnum("thumbnail")]
        Thumbnail,
        /// <summary>
        /// Report of verification<br/>
        /// <br/>
        /// Report of verification or test-processes.
        /// </summary>
        [XmlEnum("verification_report")]
        VerificationReport,
        /// <summary>
        /// Warranty<br/>
        /// <br/>
        /// Warranty certificate.
        /// </summary>
        [XmlEnum("warranty")]
        Warranty,
        /// <summary>
        /// Others<br/>
        /// <br/>
        /// Should none of the other values be suitable, others can be used.
        /// </summary>
        [XmlEnum("others")]
        Others
    }
}
