﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Feature synonyms)<br/>
    /// <br/>
    /// This element contains a list of synonyms for the feature name.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureSynonyms
    {
        /// <summary>
        /// (required) Synonym<br/>
        /// <br/>
        /// The synonym support name-based product search.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SYNONYM")]
        public List<MultiLingualString> Synonyms { get; set; } = new List<MultiLingualString>();
    }
}
