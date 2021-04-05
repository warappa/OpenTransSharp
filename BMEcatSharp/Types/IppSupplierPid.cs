using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP product ID)<br/>
    /// <br/>
    /// This element contains the identifier ID which is input for the IPP application.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppSupplierPid : IppParamsBase
    {
        /// <summary>
        /// <inheritdoc cref="IppSupplierPid"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppSupplierPid()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppSupplierPid"/>
        /// </summary>
        /// <param name="value"></param>
        public IppSupplierPid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="IppSupplierPid"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="occurrence"></param>
        public IppSupplierPid(string value, IppOccurrence occurrence)
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
