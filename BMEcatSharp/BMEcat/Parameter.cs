using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Parameter)<br/>
    /// <br/>
    /// This element is used on the product level to set the value of a parameter.<br/>
    /// If the parameter has a default value, then this value is replaced by the new one.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// (required) Reference to a parameter<br/>
        /// <br/>
        /// Reference to the unique identifier of a parameter.<br/>
        /// The reference must point to a parameter defined in the document (PARAMETER_DEFINITION element identified by PARAMETER_SYMBOL).<br/>
        /// <br/>
        /// Max length: 60
        /// </summary>
        [BMEXmlElement("PARAMETER_SYMBOLREF")]
        public string SymbolRef { get; set; }

        /// <summary>
        /// (required) Parameter value<br/>
        /// <br/>
        /// This element contains the value of the parameter.<br/>
        /// If the PARAMETER_DEFAULT_VALUE element has been used for setting a default value, this value is replaced by the new one.<br/>
        /// <br/>
        /// Max length: 250
        /// </summary>
        [BMEXmlElement("PARAMETER_VALUE")]
        public string Value { get; set; }
    }
}
