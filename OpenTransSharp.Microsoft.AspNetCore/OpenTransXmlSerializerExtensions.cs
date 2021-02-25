using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace OpenTransSharp.Microsoft.AspNetCore
{
    public static class OpenTransXmlSerializerExtensions
    {
        public static IMvcBuilder AddOpenTransXmlSerializerFormatters(this IMvcBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ConfigureOpenTransXmlSerializerMvcOptions>());

            return builder;
        }
    }
}
