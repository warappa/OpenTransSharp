using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Name of the hierarchy level)<br/>
    /// <br/>
    /// This element contains the name of the hierarchy level of a classification system.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ClassificationSystemLevelName
    {
        public ClassificationSystemLevelName()
        {
        }

        public ClassificationSystemLevelName(int level, string value)
        {
            Level = level;
            Value = value;
        }

        /// <summary>
        /// (required) Number of the hierarchy level<br/>
        /// <br/>
        /// The hierarchy levels are sorted according to their order by this attribute.<br/>
        /// The highest level starts with level number 1.
        /// </summary>
        [Required]
        [XmlAttribute("level")]
        public int Level { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 80
        /// </summary>
        [Required]
        [XmlText]
        public string Value { get; set; }
    }
}
