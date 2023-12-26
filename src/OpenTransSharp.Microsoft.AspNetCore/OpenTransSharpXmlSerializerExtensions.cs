namespace Microsoft.Extensions.DependencyInjection;

public static class OpenTransSharpXmlSerializerExtensions
{
    public static IMvcBuilder AddOpenTransSharpXmlSerializer(this IMvcBuilder builder)
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ConfigureOpenTransSharpXmlSerializerMvcOptions>());

        return builder;
    }
}
