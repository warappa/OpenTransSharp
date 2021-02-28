using System.Xml;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Term)<br/>
    /// <br/>
    /// This element specifies a term for calculating values or for restricting configurations.<br/>
    /// Which of this two function the term serves depends on the content of the attribute "type".<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Term
    {
        /// <summary>
        /// (required) Term type<br/>
        /// <br/>
        /// This attribute specifies the purpose of the term.
        /// </summary>
        [XmlAttribute("type")]
        public TermType Type { get; set; } = TermType.Function;

        /// <summary>
        /// (required) Identification of the term<br/>
        /// <br/>
        /// Unique identifier of the term.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TERM_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (optional) Condition<br/>
        /// <br/>
        /// This element contains the condition of the term (e.g. "M1='red' and not(M2&gt;5)").<br/>
        /// The meaning of the element depends on the type of the term (TERM --&gt; type).<br/>
        /// <br/>
        /// In calculation terms(TERM --&gt; type = function) the element TERM_CONDITION is used to indicate if the expression of the term (TERM_EXPRESSION) should be calculated.<br/>
        /// Normally in these cases there are different terms (TERM) with diverse condition (TERM_CONDITION) and diverse expressions (TERM_EXPRESSION) (see also Example for price formulas and Examples for configuration rules).<br/>
        /// <br/>
        /// If the term is used to express a constraint to specify valid configurations a term is valid if the result of the evaluation of the TERM_CONDITION equals the evaluation of TERM_EXPRESSION.<br/>
        /// If all configuartion terms are valid the whole configuration is valid (see also Examples for configuration rules. This means that in case of configurations the meaning of the content of the TERM_CONDITION depends on the value of the TERM_EXPRESSION.<br/>
        /// Is the valuer "true" the TERM_CONDITION specifies the conditions for a valid product.Is the value "false" the element TERM_CONDITION specifies situation which are not allowed for valid products.<br/>
        /// <br/>
        /// The language to define the conditions is defined close to terms from the language javascript (see also http://web.archive.org/web/20040211195031/http://devedge.netscape.com/library/manuals/2000/javascript/1.5/guide/).<br/>
        /// The content of the condition has to be evaluated to a logical value ("true" oder "false").<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TERM_CONDITION")]
        public string? Condition { get; set; }

        /// <summary>
        /// (required) Expression<br/>
        /// <br/>
        /// This element is used to specify an expression.<br/>
        /// This expression consists of parameter symbols, mathematical functions, operands and numbers.<br/>
        /// Conditionals, loops or funftion definitions are not allowed.<br/>
        /// <br/>
        /// In the context of a calculation term (TERM --&gt; type = function) the expression has to be calculated either if the content of the element TERM_CONDITION evaluates to a true result or if the element TERM_CONDITION is absent.<br/>
        /// In this case the element TERM_EXPRESSION contains a funktion like P = A * B (see also Examples to price formulas and Examples to configuration rules).<br/>
        /// <br/>
        /// If the term is used to constrict valid configurations (TERM --&gt; type = constraint) within configuration rules the element TERM_EXPRESSION contains always either "true" or "false" (see also CONFIG_RULES).<br/>
        /// <br/>
        /// The language to define the expressions is defined close to terms from the language javascript (see also http://web.archive.org/web/20040211195031/http://devedge.netscape.com/library/manuals/2000/javascript/1.5/guide/). <br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("TERM_EXPRESSION")]
        public string Expression { get; set; }
    }
}
