using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP definition)<br/>
    /// <br/>
    /// This element defines an IPP.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppDefinition
    {
        /// <summary>
        /// <inheritdoc cref="IppDefinition"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppDefinition()
        {
            Id = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppDefinition"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public IppDefinition(string id, IppType type, IEnumerable<IppOperation> operations)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
            }

            if (operations is null)
            {
                throw new ArgumentNullException(nameof(operations));
            }

            Id = id;
            Type = type;
            Operations = operations.ToList();
        }

        /// <summary>
        /// (required) IPP application ID<br/>
        /// <br/>
        /// Unique identifier of the IPP application.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) IPP application<br/>
        /// <br/>
        /// This element determines the IPP application, e.g., external catalog, price request.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_TYPE")]
        public IppType Type { get; set; }

        /// <summary>
        /// (optional) Reference to IPP provider.<br/>
        /// <br/>
        /// Reference to the IPP provider.<br/>
        /// It contains the unique identifier (PARTY_ID) of the respective party that is defined in the document.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATOR_IDREF")]
        public IppOperatorIdRef? OperatorIdRef { get; set; }

        /// <summary>
        /// (optional) Description of the IPP application<br/>
        /// <br/>
        /// This element is used to describe the IPP application (e.g., "Configurator for Office Chairs").<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_DESCR")]
        public List<MultiLingualString>? Description { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionSpecified => Description?.Count > 0;

        /// <summary>
        /// (required) IPP operation<br/>
        /// <br/>
        /// Specification of an IPP operation supported by the respective IPP.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("IPP_OPERATION")]
        public List<IppOperation> Operations { get; set; } = new List<IppOperation>();
    }
}
