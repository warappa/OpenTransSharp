namespace BMEcatSharp;

/// <summary>
/// (Date)<br/>
/// (deprecated)<br/>
/// <br/>
/// The element is used to precisely define a time.<br/>
/// It is made up of the three elements date, time and time zone.<br/>
/// DATETIME is used at various places within the BMEcat formats.<br/>
/// The description of the time involved is carried out through the attribute 'type' which can accept various pre-defined values.<br/>
/// <br/>
/// This element will not be used in the future.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
//[Obsolete("This element will not be used in the future.")]
public class BMEcatDatetime
{
    /// <summary>
    /// <inheritdoc cref="BMEcatDatetime"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BMEcatDatetime()
    {
    }

    /// <summary>
    /// <inheritdoc cref="BMEcatDatetime"/>
    /// </summary>
    /// <param name="type"></param>
    public BMEcatDatetime(BMEcatDatetimeType type)
    {
        Type = type;
    }

    /// <summary>
    /// (required - deprecated) Date type<br/>
    /// <br/>
    /// Specifies the date type in more detail.; Value range: depending on context.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlAttribute("type")]
    public BMEcatDatetimeType Type { get; set; }

    /// <summary>
    /// (required - choice Date/Time/Timezone - deprecated) Date<br/>
    /// <br/>
    /// Date.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [XmlIgnore]
    public DateTimeOffset Value { get; set; }

    [BMEXmlElement("DATE")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Date
    {
        get => Value.ToString("yyyy-MM-dd");
        set
        {
            var strs = value.Split(['-'], StringSplitOptions.RemoveEmptyEntries);
            if (strs.Length == 3)
            {
                Value = new DateTimeOffset(
                    int.Parse(strs[0]),
                    int.Parse(strs[1]),
                    int.Parse(strs[2]),
                    Value.Hour,
                    Value.Minute,
                    Value.Second,
                    Value.Offset);
            }
            else
            {
                throw new InvalidOperationException("Wrong format for DATE");
            }
        }
    }

    /// <summary>
    /// (optional - choice Date/Time/Timezone - deprecated) Time<br/>
    /// <br/>
    /// Element for time.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIME")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string? Time
    {
        get => Value.ToString("HH:mm:ss");
        set
        {
            var strs = value?.Split([':'], StringSplitOptions.RemoveEmptyEntries);
            var hour = 0;
            var minute = 0;
            var second = 0;
            if (strs?.Length == 3)
            {
                hour = int.Parse(strs[0]);
                minute = int.Parse(strs[1]);
                second = int.Parse(strs[2]);
            }
            else if (strs is not null)
            {
                throw new InvalidOperationException("Wrong format for TIME");
            }

            Value = new DateTimeOffset(
                Value.Year,
                Value.Month,
                Value.Day,
                hour,
                minute,
                second,
                Value.Offset);
        }
    }

    /// <summary>
    /// (optional - choice Date/Time/Timezone - deprecated) Time zone<br/>
    /// <br/>
    /// Element for timezone.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("TIMEZONE")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string? Timezone
    {
        get => $"{(Value.Offset.Hours < 0 ? "-" : "+")}{Value.Offset:hh\\:mm}";
        set
        {
            var strs = value?.Split([':'], StringSplitOptions.RemoveEmptyEntries);
            var offset = TimeSpan.Zero;
            if (strs?.Length == 2)
            {
                offset = new TimeSpan(int.Parse(strs[0]), int.Parse(strs[1]), 0);
            }
            else if (strs?.Length == 1 &&
                value == "Z")
            {
                offset = TimeSpan.Zero;
            }
            else if (strs is not null)
            {
                throw new InvalidOperationException("Wrong format for TIMEZONE");
            }

            Value = new DateTimeOffset(
                Value.Year,
                Value.Month,
                Value.Day,
                Value.Hour,
                Value.Minute,
                Value.Second,
                offset);
        }
    }
}
