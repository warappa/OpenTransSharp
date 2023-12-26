namespace BMEcatSharp.Microsoft.AspNetCore;

public class ConfigureBMEcatSharpXmlSerializerMvcOptions : IConfigureOptions<MvcOptions>
{
    private readonly IBMEcatXmlSerializerFactory openTransXmlSerializerFactory;
    private readonly BMEcatXmlSerializerOptions serializerOptions;

    public ConfigureBMEcatSharpXmlSerializerMvcOptions(IBMEcatXmlSerializerFactory openTransXmlSerializerFactory,
        BMEcatXmlSerializerOptions serializerOptions)
    {
        this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new System.ArgumentNullException(nameof(openTransXmlSerializerFactory));
        this.serializerOptions = serializerOptions ?? throw new System.ArgumentNullException(nameof(serializerOptions));
    }

    public void Configure(MvcOptions options)
    {
        var inputFormatter = new BMEcatSharpXmlSerializerInputFormatter(options, serializerOptions, openTransXmlSerializerFactory);

        options.InputFormatters.Add(inputFormatter);
    }
}
