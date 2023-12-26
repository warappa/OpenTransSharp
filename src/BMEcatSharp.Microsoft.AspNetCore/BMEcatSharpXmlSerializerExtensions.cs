namespace Microsoft.Extensions.DependencyInjection;

public static class BMEcatSharpXmlSerializerExtensions
{
    public static IMvcBuilder AddBMEcatSharpXmlSerializer(this IMvcBuilder builder)
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ConfigureBMEcatSharpXmlSerializerMvcOptions>());

        return builder;
    }
}
