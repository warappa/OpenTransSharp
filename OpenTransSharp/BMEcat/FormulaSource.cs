namespace OpenTransSharp
{
    /// <summary>
    /// (Formula source)<br/>
    /// <br/>
    /// This element contains a reference to a document, standard or definition describing the formula.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class FormulaSource
    {
        /// <summary>
        /// (optional) Source description<br/>
        /// <br/>
        /// Description of the source, e.g., the name of the document or standard.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SOURCE_NAME")]
        public MultiLingualString? SourceName { get; set; }

        /// <summary>
        /// (optional) URI of the source<br/>
        /// <br/>
        /// URI of the source, e.g., pointing to the document or standard.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("SOURCE_URI")]
        public string? SourceUri { get; set; }

        /// <summary>
        /// (optional) Reference to a business partner<br/>
        /// <br/>
        /// Reference to a business partner.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
        /// <br/>
        /// In this context the element is used to reference the organisation which is responsible for the specification of the element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARTY_IDREF")]
        public PartyIdref? PartyIdref { get; set; }
    }
}
