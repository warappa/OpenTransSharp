using BMEcatSharp.Xml;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
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
        [BMEXmlElement("DATE")]
        public DateTime Date { get; set; }

        /// <summary>
        /// (required - choice Date/Time/Timezone - deprecated) Time<br/>
        /// <br/>
        /// Element for time.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TIME")]
        public DateTime? Time { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TimeSpecified => Time.HasValue;

        /// <summary>
        /// (required - choice Date/Time/Timezone - deprecated) Time zone<br/>
        /// <br/>
        /// Element for timezone.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TIMEZONE")]
        public string? Timezone { get; set; }
    }
}
