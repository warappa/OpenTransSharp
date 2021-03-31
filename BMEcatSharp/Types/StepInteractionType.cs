using System.Xml.Serialization;

namespace BMEcatSharp
{
    /// <summary>
    /// For <see cref="ConfigurationStep.InteractionType"/>.
    /// </summary>
    public enum StepInteractionType
    {
        /// <summary>
        /// User input<br/>
        /// <br/>
        /// This value indicates that the user has to run through the configuration step.<br/>
        /// See also PRODUCT_TYPE =must_be_configured.
        /// </summary>
        [XmlEnum("force_userinput")]
        ForceUserinput,
        /// <summary>
        /// Default values<br/>
        /// <br/>
        /// This value indicates that a configuration step could be skipped and that then the default values are used.<br/>
        /// See also PRODUCT_TYPE =configurable.
        /// </summary>
        [XmlEnum("take_default")]
        TakeDefault
    }
}
