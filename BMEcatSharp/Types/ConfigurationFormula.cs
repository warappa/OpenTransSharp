using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Configuration formula)<br/>
    /// <br/>
    /// This element defines a formular for calculating configuration-dependent values on the basis of parameters.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ConfigurationFormula
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationFormula()
            : this(null!)
        { }

        public ConfigurationFormula(string idref)
        {
            Idref = idref;
        }

        /// <summary>
        /// (required) Reference to a formula<br/>
        /// <br/>
        /// Reference to the unique identifier of a formula.<br/>
        /// The reference must point to a formula defined in the document (FORMULA element identified by FORMULA_ID).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FORMULA_IDREF")]
        public string Idref { get; set; }

        /// <summary>
        /// (optional) Paramters<br/>
        /// <br/>
        /// List of paramters which are used in a price formula.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlArray("PARAMETERS")]
        [BMEXmlArrayItem("PARAMETER")]
        public List<Parameter>? Parameters { get; set; } = new List<Parameter>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ParametersSpecified => Parameters?.Count > 0;
    }
}
