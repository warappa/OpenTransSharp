using BMEcatSharp.Xml;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Function of the formula)<br/>
    /// <br/>
    /// This element describes the formula in a technical way.<br/>
    /// Therefore the formula expression can be mathematically evaluated.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FormulaFunction
    {
        /// <summary>
        /// (required) Term<br/>
        /// <br/>
        /// Term for calculating values or for restricting configurations<br/>
        /// Terms are used in the context of formulas only to calculate values (TERM --&gt; type = function).<br/>
        /// Terms for the restriction of configurations (TERM --&gt; type = constraint) are not allowed here.<br/>
        /// <br/>
        /// The operands used in the term conditions (TERM_CONDITION) and term expressions (TERM_EXPRESSION), have to be parameters symbols (PARAMETER_SYMBOL) defined using parameters (PARAMETER_DEFINITION).<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("FORMULA_FUNCTION")]
        public List<Term> Terms { get; set; } = new List<Term>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TermsSpecified => Terms?.Count > 0;
    }
}
