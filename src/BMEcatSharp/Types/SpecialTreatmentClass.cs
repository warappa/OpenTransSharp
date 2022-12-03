using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
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
        /// <summary>
        /// <inheritdoc cref="SpecialTreatmentClass"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpecialTreatmentClass()
        {
            Value = null!;
            Type = null!;
        }

        /// <summary>
        /// <inheritdoc cref="SpecialTreatmentClass"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">Name of the special treatment rule<br/>
        /// <br/>
        /// Short term for the special treatment regulation, e.g., GGVS (Hazardous Goods Order for Road Traffic)
        /// </param>
        public SpecialTreatmentClass(string value, string type)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
            }

            Value = value;
            Type = type;
        }

        /// <summary>
        /// (required) Name of the special treatment rule<br/>
        /// <br/>
        /// Short term for the special treatment regulation, e.g., GGVS (Hazardous Goods Order for Road Traffic).
        /// </summary>
        [XmlAttribute("type")]
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
