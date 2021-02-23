using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Number of rebates in kind units)<br/>
    /// <br/>
    /// The number of rebates or charges in kind units indicates the number of units which are delivered for free.<br/>
    /// The attribute AOC_ORDER_UNITS_COUNT -->type indicates a bonus or an additional charge.
    /// </summary>
    public class AocOrderUnitsCount
    {
        public AocOrderUnitsCount()
        {

        }

        public AocOrderUnitsCount(decimal value, AocOrderUnitsCountType type)
        {
            Value = value;
            Type = type;
        }
        /// <summary>
        /// (required) Type of the rebate in kind<br/>
        /// <br/>
        /// Indicates a bonus or an additional unit.
        /// </summary>
        [Required]
        [XmlAttribute("type")]
        public AocOrderUnitsCountType Type { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        [Required]
        [XmlText]
        public decimal Value { get; set; }
    }
}
