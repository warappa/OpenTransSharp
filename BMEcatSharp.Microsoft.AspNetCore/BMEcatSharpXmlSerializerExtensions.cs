using BMEcatSharp.Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BMEcatSharpXmlSerializerExtensions
    {
        public static IMvcBuilder AddBMEcatSharpXmlSerializer(this IMvcBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ConfigureBMEcatSharpXmlSerializerMvcOptions>());

            return builder;
        }
    }
}
