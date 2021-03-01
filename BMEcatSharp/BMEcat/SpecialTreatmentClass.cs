using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Special treatment class)<br/>
    /// <br/>
    /// This elements contains an additional product classification used for hazardous goods or substances, primary pharmaceutical products, radioactive measuring equipment, etc.<br/>
    /// The "type" attribute specifies the dangerous goods classification scheme.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class SpecialTreatmentClass
    {
        public SpecialTreatmentClass()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">Name of the special treatment rule<br/>
        /// <br/>
        /// Short term for the special treatment regulation, e.g., GGVS (Hazardous Goods Order for Road Traffic)
        /// </param>
        public SpecialTreatmentClass(string value, string type)
        {
            Value = value;
            Type = type;
        }
        /// <summary>
        /// Name of the special treatment rule<br/>
        /// <br/>
        /// Short term for the special treatment regulation, e.g., GGVS (Hazardous Goods Order for Road Traffic).
        /// </summary>
        [BMEXmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
