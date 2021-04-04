using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTransSharp
{
    /// <summary>
    /// (Remark)<br/>
    /// <br/>
    /// This element contains remarks related to a business document.<br/>
    /// The remark is identified with the attribute "type" for use in different business documents.<br/>
    /// It is only permissible to identify remarks for use in this or the following business documents using the attribute "type".<br/>
    /// Target systems are recommended to ignore remarks about previous business documents(History).<br/>
    /// It is permissible to use the element more than once with the same "type" attribute.<br/>
    /// <br/>
    /// Format:<br/>
    /// The following HTML tags are supported: &lt;b&gt; for bold, &lt;i&gt; for italic, &lt;p&gt; for paragraphs, &lt;br&gt; for line break and&lt;ul&gt;/&lt;li&gt; for lists.<br/>
    /// In order to transfer these, the characters '&lt;‘ and '&gt;‘ must be enclosed in quotation marks, or the file will not be accepted by the XML parser(see also chapter Character encoding in XML).<br/>
    /// Example: '&lt;' = &amp;lt; or '&gt;' = &amp;gt;<br/>
    /// <br/>
    /// Caution:<br/>
    /// The target system must support the interpretation of the day in order to achieve the desired formatting.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class Remark
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Remark()
            : this(null!)
        {
        }

        public Remark(string value)
        {
            Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type">For predefined values see <see cref="RemarkTypeValues"/>. Custom values can be used.</param>
        public Remark(string value, string type)
            : this(value)
        {
            Type = type;
        }

        /// <summary>
        /// (optional) Type of remark<br/>
        /// <br/>
        /// Specifies the type of remark.<br/>
        /// The remark is identified for use in a variety of business documents.<br/>
        /// The business partner processing the document which matches the attribute evaluates the information contained, otherwise the information is passed on along the process chain.<br/>
        /// <br/>
        /// Example: type= deliverynote means that the remark entered appears on the delivery note, e.g. "Please ring at the ramp and ask for Mr Miller".<br/>
        /// <br/>
        /// For predefined values see <see cref="RemarkTypeValues"/>. Custom values can be used.
        /// </summary>
        [XmlAttribute("type")]
        public string? Type { get; set; }

        /// <summary>
        /// (required)<br/>
        /// <br/>
        /// Max length: 64000
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
