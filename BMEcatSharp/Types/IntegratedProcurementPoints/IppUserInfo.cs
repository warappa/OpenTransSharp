using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// (IPP user information)<br/>
    /// <br/>
    /// This element specifies if and how user information are used with an IPP application call.<br/>
    /// Two cases have to be distinguished: If there are user information included in this element these user information have to be transfered during the IPP application call.<br/>
    /// If the element is empty the attribute "occurance" states wether the user information is mandatory or optional in the IPP call but not which are the user information.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class IppUserInfo : IppParamsBase
    {
        /// <summary>
        /// <inheritdoc cref="IppUserInfo"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IppUserInfo()
        {
            Value = null!;
        }

        /// <summary>
        /// <inheritdoc cref="IppUserInfo"/>
        /// </summary>
        /// <param name="value"></param>
        public IppUserInfo(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// <inheritdoc cref="IppUserInfo"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="occurrence"></param>
        public IppUserInfo(string value, IppOccurrence occurrence)
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
