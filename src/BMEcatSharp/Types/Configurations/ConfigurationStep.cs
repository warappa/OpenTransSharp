using BMEcatSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BMEcatSharp
{
    /// <summary>
    /// (Configuration step)<br/>
    /// <br/>
    /// This element contains information on a configuration step.<br/>
    /// <br/>
    /// XML-namespace: BMECAT
    /// </summary>
    public class ConfigurationStep
    {
        /// <summary>
        /// <inheritdoc cref="ConfigurationStep"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConfigurationStep()
        {
            Id = null!;
        }

        /// <summary>
        /// <inheritdoc cref="ConfigurationStep"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="header"></param>
        /// <param name="minimumOccurance"></param>
        /// <param name="maximumOccurance"></param>
        /// <param name="configurationFeature"></param>
        public ConfigurationStep(string id, IEnumerable<MultiLingualString> header, int minimumOccurance, int maximumOccurance, ConfigurationFeature configurationFeature)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
            }

            if (header is null)
            {
                throw new ArgumentNullException(nameof(header));
            }

            Id = id;
            Header = header?.ToList() ?? new List<MultiLingualString>();
            MinimumOccurance = minimumOccurance;
            MaximumOccurance = maximumOccurance;
            ConfigurationFeature = configurationFeature ?? throw new ArgumentNullException(nameof(configurationFeature));
        }

        /// <summary>
        /// <inheritdoc cref="ConfigurationStep"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="header"></param>
        /// <param name="minimumOccurance"></param>
        /// <param name="maximumOccurance"></param>
        /// <param name="configurationParts"></param>
        public ConfigurationStep(string id, IEnumerable<MultiLingualString> header, int minimumOccurance, int maximumOccurance, ConfigurationParts configurationParts)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
            }

            if (header is null)
            {
                throw new ArgumentNullException(nameof(header));
            }

            Id = id;
            Header = header.ToList();
            MinimumOccurance = minimumOccurance;
            MaximumOccurance = maximumOccurance;
            ConfigurationParts = configurationParts ?? throw new ArgumentNullException(nameof(configurationParts));
        }

        /// <summary>
        /// (required) Identification of the configuration step<br/>
        /// <br/>
        /// This element provides the unique identifier of the configuration step.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_ID")]
        public string Id { get; set; }

        /// <summary>
        /// (required) Header of the configuration step<br/>
        /// <br/>
        /// This element defines a visible header, thus title of the configuration step.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_HEADER")]
        public List<MultiLingualString> Header { get; set; } = new List<MultiLingualString>();

        /// <summary>
        /// (optional) Configuration step short description<br/>
        /// <br/>
        /// This element is used to describe the configuration step.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_DESCR_SHORT")]
        public List<MultiLingualString>? DescriptionShort { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionShortSpecified => DescriptionShort?.Count > 0;

        /// <summary>
        /// (optional) Configuration step long description<br/>
        /// <br/>
        /// This element can be used to describe the configuration step in more detail.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_DESCR_LONG")]
        public List<MultiLingualString>? DescriptionLong { get; set; } = new List<MultiLingualString>();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DescriptionLongSpecified => DescriptionLong?.Count > 0;

        /// <summary>
        /// (optional) Order of configuration step<br/>
        /// <br/>
        /// Order in which the configuration step have be taken in the target system.<br/>
        /// A configuration process starts with the step which has the lowest order number.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_ORDER")]
        public int? Order { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool OrderSpecified => Order.HasValue;

        /// <summary>
        /// (optional) Configuration type<br/>
        /// <br/>
        /// Specifies wether a configuration step has to be run through or the default values can be inserted.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("STEP_INTERACTION_TYPE")]
        public StepInteractionType? InteractionType { get; set; } = BMEcatSharp.StepInteractionType.ForceUserinput;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool InteractionTypeSpecified => InteractionType != BMEcatSharp.StepInteractionType.ForceUserinput;

        /// <summary>
        /// (optional) Order number extension<br/>
        /// <br/>
        /// In order to generate the order number of configurated products, this element can be used for coding the result of each configuration step; the unique code is added to the base order number.By adding these codes for each configuration step a unique order number is created.<br/>
        /// <br/>
        /// If the configuration requires more than one configuration step, it should be guaranted that the extensions can be separated. A solution is to standardize the length of each added code; for instance, adding 3 characters, e.g., "003"="black".<br/>
        /// <br/>
        /// Another solution is to separate the codes by a hyphen (e.g., "-red").<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONFIG_CODE")]
        public string? ConfigurationCode { get; set; }

        /// <summary>
        /// (optional) Price details<br/>
        /// <br/>
        /// Price information for the product.<br/>
        /// A detailed description of the element is contained in a separate document which can be downloaded from the BMEcat website www.bmecat.org.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("PRODUCT_PRICE_DETAILS")]
        public ProductPriceDetails? ProductPriceDetails { get; set; }

        /// <summary>
        /// (required - choice ConfigurationFeature/ConfigurationParts) Configuration feature<br/>
        /// <br/>
        /// Defines a feature to which product configuration assignes a value, i.e. by selection from a list of allowed value, or user input.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONFIG_FEATURE")]
        public ConfigurationFeature? ConfigurationFeature { get; set; }

        /// <summary>
        /// (required - choice ConfigurationFeature/ConfigurationParts) Configuration component<br/>
        /// <br/>
        /// Defines a component, which can or must be selected in an actual product configuration.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("CONFIG_PARTS")]
        public ConfigurationParts? ConfigurationParts { get; set; }

        /// <summary>
        /// (required) Minimum occurence step<br/>
        /// <br/>
        /// This element contains the minimum number of components respectively feature values which can be selected.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MIN_OCCURANCE")]
        public int MinimumOccurance { get; set; }

        /// <summary>
        /// (required) Maximum occurence step<br/>
        /// <br/>
        /// This element contains the maximum number of components respectively feature values which can be selected.<br/>
        /// <br/>
        /// XML-namespace: BMECAT
        /// </summary>
        [BMEXmlElement("MAX_OCCURANCE")]
        public int MaximumOccurance { get; set; }
    }
}
