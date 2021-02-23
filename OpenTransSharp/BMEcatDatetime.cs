using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    [Obsolete("This element will not be used in the future.")]
    public class BMEcatDatetime
    {
        [Required]
        [XmlAttribute("type")]
        public BMEcatDatetimeType Type { get; set; }

        [Required]
        [BMEXmlElement("DATE")]
        public DateTime Date { get; set; }

        [BMEXmlElement("TIME")]
        public DateTime? Time { get; set; }
        public bool TimeSpecified => Time.HasValue;

        [BMEXmlElement("TIMEZONE")]
        public string Timezone { get; set; }
    }
}
