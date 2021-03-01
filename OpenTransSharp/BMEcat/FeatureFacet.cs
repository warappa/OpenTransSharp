﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Data type restriction)<br/>
    /// <br/>
    /// This element defines a restriction on a data type, e.g., maximum length of a character string.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FeatureFacet
    {
        public FeatureFacet()
        {

        }

        public FeatureFacet(string value, FeatureFacetType type)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// (required) Restriction type<br/>
        /// <br/>
        /// This attribute contains the type of the restriction.
        /// </summary>
        [XmlAttribute("type")]
        public FeatureFacetType Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 20
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}