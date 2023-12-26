namespace BMEcatSharp;

/// <summary>
/// (Reference to a skeleton agreement)<br/>
/// <br/>
/// This element serves for referring to a skeleton agreement, which is relevant for the business document.<br/>
/// Agreements which cannot be transported in the business document itself are regulated in this skeleton agreement.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class Agreement
{
    /// <summary>
    /// <inheritdoc cref="Agreement"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Agreement()
    {
        Id = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Agreement"/>
    /// </summary>
    /// <param name="id"></param>
    public Agreement(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
        }

        Id = id;
    }

    /// <summary>
    /// (optional) Agreement type<br/>
    /// <br/>
    /// Owner of the skeleton agreement.<br/>
    /// If reference is made to skeleton agreements of an intermediary, the element value should point to the intermediary.<br/>
    /// Some target systems are not in a position to interpret other values than the pre-defined ones.<br/>
    /// <br/>
    /// See <see cref="AgreementTypeValues"/>.
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (optional) Default flag<br/>
    /// <br/>
    /// This attribute marks a standard agreement.
    /// </summary>
    [XmlIgnore]
    public bool? Default { get; set; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [XmlAttribute("default")]
    public string? DefaultForSerializer { get => Default is null ? null : Default == true ? "true" : "false"; set => Default = value?.ToLowerInvariant() == "true" ? true : false; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DefaultForSerializerSpecified => Default == true;

    /// <summary>
    /// (required) Skeleton agreement ID<br/>
    /// <br/>
    /// Unique identifier of the skeleton agreement.<br/>
    /// The element can also be used for special agreement information, e.g. special project-related agreements.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_ID")]
    public string Id { get; set; }

    /// <summary>
    /// (optional) Line number within the skeleton agreement<br/>
    /// <br/>
    /// Unique line number within a skeleton agreement.<br/>
    /// This element allows a unique reference to a line of a skeleton agreement.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_LINE_ID")]
    public string? LineId { get; set; }

    /// <summary>
    /// (optional - choice EndDate with StartDate/(deprecated)Datetimes) Start date of the skeleton agreement<br/>
    /// <br/>
    /// Unique time stamp of the time, when the skeleton agreement begins.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_START_DATE")]
    public DateTime? StartDate { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool StartDateSpecified => StartDate.HasValue;

    /// <summary>
    /// (required - choice EndDate with StartDate/(deprecated)Datetimes) End date of the skeleton agreement<br/>
    /// <br/>
    /// Unique time stamp for the time when the skeleton agreement ends.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("AGREEMENT_END_DATE")]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// (required - deprecated - choice AgreementEndDate/(deprecated)Datetime) End date of the skeleton agreement<br/>
    /// <br/>
    /// Unique time stamp for the time when the skeleton agreement ends.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    //[Obsolete("The element DATETIME in the context of AGREEMENT with the attributes 'agreement_start_date' and 'agreement_end_date' will be replaced by the elements AGREEMENT_START_DATE and AGREEMENT_END_DATE in future versions and will be omitted then.")]
    [BMEXmlElement("DATETIME")]
    public List<BMEcatDatetime>? Datetimes { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
    public bool DatetimesSpecified => Datetimes?.Count > 0;
#pragma warning restore CS0618 // Type or member is obsolete

    /// <summary>
    /// (optional) Reference to supplier<br/>
    /// <br/>
    /// Reference to the supplier.<br/>
    /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUPPLIER_IDREF")]
    public SupplierIdRef? SupplierIdRef { get; set; }

    /// <summary>
    /// (optional) Description of the skeleton agreement<br/>
    /// <br/>
    /// This element is used to describe the skeleton agreement.
    /// </summary>
    [BMEXmlElement("AGREEMENT_DESCR")]
    public List<MultiLingualString>? Descriptions { get; set; } = new List<MultiLingualString>();
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool DescriptionsSpecified => Descriptions?.Count > 0;

    /// <summary>
    /// (optional) Additional multimedia information<br/>
    /// <br/>
    /// Information about multimedia files.<br/>
    /// For instance the sceleton agreement of the document could be added.
    /// </summary>
    [BMEXmlElement("MIME_INFO")]
    public BMEcatMimeInfo? MimeInfo { get; set; }
}
