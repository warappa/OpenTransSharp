using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BMEcatSharp.Xml;

namespace BMEcatSharp.Microsoft.AspNetCore
{
    public class ConfigureBMEcatSharpXmlSerializerMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IBMEcatXmlSerializerFactory openTransXmlSerializerFactory;

        public ConfigureBMEcatSharpXmlSerializerMvcOptions(IBMEcatXmlSerializerFactory openTransXmlSerializerFactory)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory;
        }

        public void Configure(MvcOptions options)
        {
            var inputFormatter = new BMEcatSharpXmlSerializerInputFormatter(options, openTransXmlSerializerFactory);

            options.InputFormatters.Add(inputFormatter);
        }
    }
}
