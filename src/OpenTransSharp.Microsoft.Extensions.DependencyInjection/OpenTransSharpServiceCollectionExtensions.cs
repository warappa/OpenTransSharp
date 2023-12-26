namespace Microsoft.Extensions.DependencyInjection;

public static class OpenTransSharpServiceCollectionExtensions
{
    public static IServiceCollection AddOpenTransSharp(this IServiceCollection services, Action<OpenTransOptions>? configureOptions = null)
    {
        services.AddSingleton<IOpenTransXmlSerializerFactory, OpenTransXmlSerializerFactory>();
        services.AddOptions<OpenTransOptions>();
        services.AddTransient(sp => sp.GetRequiredService<IOptions<OpenTransOptions>>().Value);
        services.AddTransient(sp => sp.GetRequiredService<IOptions<OpenTransOptions>>().Value.Serialization);

        if (configureOptions is object)
        {
            services.Configure(configureOptions);
        }

        return services;
    }
}
