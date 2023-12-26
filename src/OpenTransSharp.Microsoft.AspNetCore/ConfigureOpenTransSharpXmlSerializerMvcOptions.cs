namespace OpenTransSharp.Microsoft.AspNetCore;

public class ConfigureOpenTransSharpXmlSerializerMvcOptions : IConfigureOptions<MvcOptions>
{
    private readonly IOpenTransXmlSerializerFactory openTransXmlSerializerFactory;
    private readonly OpenTransXmlSerializerOptions serializerOptions;

    public ConfigureOpenTransSharpXmlSerializerMvcOptions(IOpenTransXmlSerializerFactory openTransXmlSerializerFactory,
        OpenTransXmlSerializerOptions serializerOptions)
    {
        this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new System.ArgumentNullException(nameof(openTransXmlSerializerFactory));
        this.serializerOptions = serializerOptions ?? throw new System.ArgumentNullException(nameof(serializerOptions));
    }

    public void Configure(MvcOptions options)
    {
        var inputFormatter = new OpenTransSharpXmlSerializerInputFormatter(options, serializerOptions, openTransXmlSerializerFactory);

        options.InputFormatters.Add(inputFormatter);
    }
}
