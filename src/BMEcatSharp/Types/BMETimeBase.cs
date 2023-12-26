using System.Xml.Serialization;

namespace BMEcatSharp;

/// <summary>
/// For <see cref="BMETimeSpan"/>.
/// </summary>
public enum BMETimeBase
{
    /// <summary>
    /// Date<br/>
    /// <br/>
    /// Defines a date; in this case, the TIME_VALUE_... elements have to be filled with values corresponding to the dtDATETIME data type.
    /// </summary>
    [XmlEnum("date")]
    Date,
    /// <summary>
    /// Date and time<br/>
    /// <br/>
    /// Defines a date and a time; in this case, the TIME_VALUE_... elements have to be filled with values corresponding to the dtDATETIME data type.
    /// </summary>
    [XmlEnum("datetime")]
    DateTime,
    /// <summary>
    /// Day of month<br/>
    /// <br/>
    /// Defines a day of month; in this case, the TIME_VALUE_... elements have to be filled with, for instance, 1 for the first day of the month, 2 for the second day of the month, and so on.
    /// </summary>
    [XmlEnum("dayofmonth")]
    DayOfMonth,
    /// <summary>
    /// Day of week<br/>
    /// <br/>
    /// Defines a day of week; in this case, the TIME_VALUE_... elements have to be filled with, for instance, 1 = monday, 2 = tuesday, ..., 7 = sunday.
    /// </summary>
    [XmlEnum("dayofweek")]
    DayOfWeek,
    /// <summary>
    /// Half day<br/>
    /// <br/>
    /// Defines a half day; in this case, the TIME_VALUE_... elements have to be filled with 1 = morning or 2 = afternoon. A more precise time can not be defined.
    /// </summary>
    [XmlEnum("halfday")]
    Halfday,
    /// <summary>
    /// Half of year<br/>
    /// <br/>
    /// Defines a half year; in this case, the TIME_VALUE_... elements have to be filled with 1 = first half or 2 = second half.
    /// </summary>
    [XmlEnum("halfofyear")]
    HalfOfYear,
    /// <summary>
    /// Hour<br/>
    /// <br/>
    /// Defines an hour; in this case, the TIME_VALUE_... elements have to be filled with values ranging from 1 to 23.
    /// </summary>
    [XmlEnum("hour")]
    Hour,
    /// <summary>
    /// Month<br/>
    /// <br/>
    /// Defines a month; in this case, the TIME_VALUE_... elements have to be filled with values ranging from 1 to 12.
    /// </summary>
    [XmlEnum("month")]
    Month,
    /// <summary>
    /// Quarter<br/>
    /// <br/>
    /// Defines a quarter (of the year); in this case, the TIME_VALUE_... elements have to be filled with values ranging from 1 to 4.
    /// </summary>
    [XmlEnum("quarterofyear")]
    QuarterOfYear,
    /// <summary>
    /// Time<br/>
    /// <br/>
    /// Defines a time; in this case, the TIME_VALUE_... elements have to be filled with values corresponding to the dtDATETIME data type.
    /// </summary>
    [XmlEnum("time")]
    Time,
    /// <summary>
    /// Week<br/>
    /// <br/>
    /// Defines a week; in this case, the TIME_VALUE_... elements have to be filled with values ranging from 1 to 53.dtDATETIME data type.
    /// </summary>
    [XmlEnum("week")]
    Week,
    /// <summary>
    /// Year<br/>
    /// <br/>
    /// Defines a year; in this case, the TIME_VALUE_... elements have to be filled with values corresponding to the dtDATETIME data type.
    /// </summary>
    [XmlEnum("year")]
    Year
}
