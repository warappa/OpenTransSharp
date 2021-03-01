using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (IPP languages)<br/>
    /// <br/>
    /// This element contains a list of languages that are supported by the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppLanguages : IppParamsBase
    {
        /// <summary>
        /// (required) Languages<br/>
        /// <br/>
        /// Specification of used languages, especially the default language of all language-dependent information.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("LANGUAGE")]
        public List<Language> Languages { get; set; } = new List<Language>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LanguagesSpecified => Languages?.Count > 0;
    }
}
