using BMEcatSharp.Xml;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Cost category)<br/>
    /// <br/>
    /// Number of the cost center to be charged or the project or work order to which the charge must be made.<br/>
    /// The type of cost category is fixed by the attribute "type".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class CostCategoryId
    {
        public CostCategoryId()
        {

        }

        public CostCategoryId(string value, CostCategoryIdType type)
        {
            Value = value;
            Type = type;
        }

        /// <summary>
        /// (optional) Type of cost category <br/>
        /// <br/>
        /// It is specified here whether the costs are to be charged to a cost center, project or work order.<br/>
        /// If the attribute is not used no exact specification is made.
        /// </summary>
        [BMEXmlAttribute("type")]
        public CostCategoryIdType Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 64
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
