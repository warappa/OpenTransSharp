using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to an IPP shopping cart)<br/>
    /// <br/>
    /// This element specifies if and how identifiers of product lists are used with an IPP application call.<br/>
    /// <br/>
    /// The element has to be empty and the the attribute "occurance" states wether the transfer of this identifier is mandatory or optional.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppProductlistIdref : IppParamsBase
    {
        /// <summary>
        /// <inheritdoc cref="IppProductlistIdref"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppProductlistIdref()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppProductlistIdref"/>
        /// </summary>
        /// <param name="value"></param>
        public IppProductlistIdref(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="IppProductlistIdref"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="occurrence"></param>
        public IppProductlistIdref(string value, IppOccurrence occurrence)
            : this(value)
        {
            Occurrence = occurrence;
        }

        /// <summary>
        /// (required)
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
