using BMEcatSharp;
using BMEcatSharp.Xml;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class BMEcatSharpServiceCollectionExtensions
{
    public static IServiceCollection AddBMEcatSharp(this IServiceCollection services, Action<BMEcatOptions>? configureOptions = null)
    {
        services.AddSingleton<IBMEcatXmlSerializerFactory, BMEcatXmlSerializerFactory>();
        services.AddOptions<BMEcatOptions>();
        services.AddTransient(sp => sp.GetRequiredService<IOptions<BMEcatOptions>>().Value);
        services.AddTransient(sp => sp.GetRequiredService<IOptions<BMEcatOptions>>().Value.Serialization);

        if (configureOptions is object)
        {
            services.Configure(configureOptions);
        }

        return services;
    }
}
