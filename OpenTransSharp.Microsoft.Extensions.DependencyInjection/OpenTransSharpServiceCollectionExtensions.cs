using Microsoft.Extensions.Options;
using OpenTransSharp;
using OpenTransSharp.Xml;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OpenTransSharpServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenTransSharp(this IServiceCollection services, Action<OpenTransOptions> configureOptions = null)
        {
            services.AddSingleton<IOpenTransXmlSerializerFactory, OpenTransXmlSerializerFactory>();
            services.AddOptions<OpenTransOptions>();
            services.AddTransient(sp => sp.GetRequiredService<IOptions<OpenTransOptions>>().Value);

            if (configureOptions is object)
            {
                services.Configure(configureOptions);
            }

            return services;
        }
    }
}
