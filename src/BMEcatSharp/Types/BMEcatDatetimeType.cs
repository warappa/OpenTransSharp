using System;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    //[Obsolete("This element will not be used in the future.")]
    public enum BMEcatDatetimeType
    {
        [XmlEnum("generation_date")]
        GenerationDate,
        [XmlEnum("valid_start_date")]
        ValidStartDate,
        [XmlEnum("valid_end_date")]
        ValidEndDate,
    }
}
