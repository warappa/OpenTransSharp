using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OpenTransSharp.Microsoft.AspNetCore
{
    public class ConfigureOpenTransXmlSerializerMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IOpenTransXmlSerializerFactory openTransXmlSerializerFactory;

        public ConfigureOpenTransXmlSerializerMvcOptions(IOpenTransXmlSerializerFactory openTransXmlSerializerFactory)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory;
        }

        public void Configure(MvcOptions options)
        {
            var inputFormatter = new OpenTransXmlSerializerInputFormatter(options, openTransXmlSerializerFactory);

            options.InputFormatters.Add(inputFormatter);
        }
    }
}
