using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using OpenTransSharp.Microsoft.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OpenTransSharpXmlSerializerExtensions
    {
        public static IMvcBuilder AddOpenTransSharpXmlSerializer(this IMvcBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ConfigureOpenTransSharpXmlSerializerMvcOptions>());

            return builder;
        }
    }
}
