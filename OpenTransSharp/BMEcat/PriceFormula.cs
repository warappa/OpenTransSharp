﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenTransSharp
{
    /// <summary>
    /// (Price formula)<br/>
    /// <br/>
    /// This element defines a formula for price calculation based on parameters.
    /// </summary>
    public class PriceFormula
    {
        /// <summary>
        /// (required) Reference to a formula<br/>
        /// <br/>
        /// Reference to the unique identifier of a formula. The reference must point to a formula defined in the document (FORMULA element identified by FORMULA_ID).
        /// </summary>
        [BMEXmlElement("FORMULA_IDREF")]
        public string Idref { get; set; }

        /// <summary>
        /// (optional) Parameters<br/>
        /// <br/>
        /// List of paramters which are used in a price formula.
        /// </summary>
        [BMEXmlArray("PARAMETERS")]
        [BMEXmlArrayItem("PARAMETER")]
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ParametersSpecified => Parameters?.Count > 0;
    }
}