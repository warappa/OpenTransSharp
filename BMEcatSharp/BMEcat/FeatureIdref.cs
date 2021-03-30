﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// Feature reference<br/>
    /// <br/>
    /// Reference to the unique ID of a feature (seeCLASSIFICATION_SYSTEM_FEATURE_TEMPLATE).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureIdref
    {
        public FeatureIdref()
        {
        }

        public FeatureIdref(string value)
        {
            Value = value;
        }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 60
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
