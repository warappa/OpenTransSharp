namespace BMEcatSharp;

/// <summary>
/// (Time span)<br/>
/// <br/>
/// This element defines a time span or time frame.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class BMETimeSpan
{
    /// <summary>
    /// <inheritdoc cref="BMETimeSpan"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BMETimeSpan() { }

    /// <summary>
    /// <inheritdoc cref="BMETimeSpan"/>
    /// </summary>
    /// <param name="timeBase"></param>
    public BMETimeSpan(BMETimeBase timeBase)
    {
        TimeBase = timeBase;
    }

    /// <summary>
    /// (required) Time base<br/>
    /// <br/>
    /// Time base for a time span or time frame, e.g, hours, weeks.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME_BASE")]
    public BMETimeBase TimeBase { get; set; }

    /// <summary>
    /// (optional) Time frame interval<br/>
    /// <br/>
    /// Sets the length of a time frame; the unit of measurement is contained in TIME_BASE (e.g., hours).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME_VALUE_DURATION")]
    public int? TimeValueDuration { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TimeValueDurationSpecified => TimeValueDuration.HasValue;

    /// <summary>
    /// (optional) Time value interval<br/>
    /// <br/>
    /// Specifies the intervals between two items of TIME_BASE, e.g., each 3 days.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME_VALUE_INTERVAL")]
    public int? TimeValueInterval { get; set; } = 1;
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TimeValueIntervalSpecified => TimeValueInterval.HasValue;

    /// <summary>
    /// (optional) Time frame start<br/>
    /// <br/>
    /// Set the start of the time frame.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME_VALUE_START")]
    public int? TimeValueStart { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TimeValueStartSpecified => TimeValueStart.HasValue;

    /// <summary>
    /// (optional) Time frame end<br/>
    /// <br/>
    /// Set the end of the time frame.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME_VALUE_END")]
    public int? TimeValueEnd { get; set; }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool TimeValueEndSpecified => TimeValueEnd.HasValue;

    /// <summary>
    /// (optional) Sub division of a time span<br/>
    /// <br/>
    /// Divides a time span into shorter items; e.g., days of a week, hours of a day.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("SUB_TIME_SPANS")]
    public List<BMETimeSpan>? SubTimeSpans { get; set; } = [];
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SubTimeSpansSpecified => SubTimeSpans?.Count > 0;
}
