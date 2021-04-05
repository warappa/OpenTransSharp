using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Price formula)<br/>
    /// <br/>
    /// This element defines a formula for price calculation based on parameters.
    /// </summary>
    public class PriceFormula
    {
        /// <summary>
        /// <inheritdoc cref="PriceFormula"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PriceFormula()
        {
            IdRef = null!;
        }

        /// <summary>
        /// <inheritdoc cref="PriceFormula"/>
        /// </summary>
        /// <param name="idRef"></param>
        public PriceFormula(string idRef)
        {
            if (string.IsNullOrWhiteSpace(idRef))
            {
                throw new ArgumentException($"'{nameof(idRef)}' cannot be null or whitespace.", nameof(idRef));
            }

            IdRef = idRef;
        }

        /// <summary>
        /// (required) Reference to a formula<br/>
        /// <br/>
        /// Reference to the unique identifier of a formula. The reference must point to a formula defined in the document (FORMULA element identified by FORMULA_ID).
        /// </summary>
        [BMEXmlElement("FORMULA_IDREF")]
        public string IdRef { get; set; }

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
