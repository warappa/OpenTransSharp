using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BMEcatSharp
{
    /// <summary>
    /// (Product contacts)<br/>
    /// <br/>
    /// This element contains a list of contact person for the product.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ProductContacts
    {
        /// <summary>
        /// <inheritdoc cref="ProductContacts"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProductContacts()
        {
            PartyIdRef = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ProductContacts"/>
        /// </summary>
        /// <param name="partyIdRef"></param>
        public ProductContacts(PartyIdRef partyIdRef)
        {
            PartyIdRef = partyIdRef ?? throw new ArgumentNullException(nameof(partyIdRef));
        }

        /// <summary>
        /// (required) Reference to a business partner<br/>
        /// <br/>
        /// Reference to a business partner.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
        /// <br/>
        /// In this context the element is used to reference the organisation which is responsible for the specification of the element.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PARTY_IDREF")]
        public PartyIdRef PartyIdRef { get; set; }

        /// <summary>
        /// (optional) Reference to a business partner<br/>
        /// <br/>
        /// Reference to a business partner.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
        /// <br/>
        /// In this context the element is used to reference the organisation which is responsible for the specification of the element.
        /// </summary>
        [BMEXmlElement("CONTACT_IDREF")]
        public List<string> ContactIdRefs { get; set; } = new List<string>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ContactIdRefsSpecified => ContactIdRefs?.Count > 0;
    }
}
