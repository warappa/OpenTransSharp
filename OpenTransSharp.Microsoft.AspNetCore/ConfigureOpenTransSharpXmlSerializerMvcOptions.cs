using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OpenTransSharp.Microsoft.AspNetCore
{
    public class ConfigureOpenTransSharpXmlSerializerMvcOptions : IConfigureOptions<MvcOptions>
    {
        private readonly IOpenTransXmlSerializerFactory openTransXmlSerializerFactory;

        public ConfigureOpenTransSharpXmlSerializerMvcOptions(IOpenTransXmlSerializerFactory openTransXmlSerializerFactory)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory;
        }

        public void Configure(MvcOptions options)
        {
            var inputFormatter = new OpenTransSharpXmlSerializerInputFormatter(options, openTransXmlSerializerFactory);

            options.InputFormatters.Add(inputFormatter);
        }
    }
}
