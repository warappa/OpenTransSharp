using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp;

/// <summary>
/// (Classification group contacts)<br/>
/// <br/>
/// This element contains contact information for the respective group.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class ClassificationGroupContacts
{
    /// <summary>
    /// <inheritdoc cref="ClassificationGroupContacts"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ClassificationGroupContacts()
    {
        PartyIdRef = null!;
    }

    /// <summary>
    /// <inheritdoc cref="ClassificationGroupContacts"/>
    /// </summary>
    /// <param name="partyIdRef"></param>
    /// <param name="contactIdRefs"></param>
    public ClassificationGroupContacts(PartyIdRef partyIdRef, IEnumerable<string> contactIdRefs)
    {
        if (contactIdRefs is null)
        {
            throw new ArgumentNullException(nameof(contactIdRefs));
        }

        PartyIdRef = partyIdRef ?? throw new ArgumentNullException(nameof(partyIdRef));
        ContactIdRefs = contactIdRefs.ToList();
    }

    /// <summary>
    /// (required) Reference to a business partner<br/>
    /// <br/>
    /// Reference to a business partner. It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("PARTY_IDREF")]
    public PartyIdRef PartyIdRef { get; set; }

    /// <summary>
    /// (required) Reference to a business partner<br/>
    /// <br/>
    /// Reference to a business partner. It contains the unique identifier (PARTY_ID) of the respective party (element PARTY).<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    [BMEXmlElement("CONTACT_IDREF")]
    public List<string> ContactIdRefs { get; set; } = new List<string>();
}
