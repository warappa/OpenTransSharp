using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (Reference to an IPP product configuration)<br/>
    /// <br/>
    /// This element determines if and how identifiers of product configurations have to be used when calling an IPP application.<br/>
    /// This element must be empty and the occurence-attribute specifies, whether providing such an identifier is optional or mandatory.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppProductconfigIdref : IppParamsBase
    {
        /// <summary>
        /// <inheritdoc cref="IppProductconfigIdref"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppProductconfigIdref()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppProductconfigIdref"/>
        /// </summary>
        /// <param name="value"></param>
        public IppProductconfigIdref(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="IppProductconfigIdref"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="occurrence"></param>
        public IppProductconfigIdref(string value, IppOccurrence occurrence)
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
