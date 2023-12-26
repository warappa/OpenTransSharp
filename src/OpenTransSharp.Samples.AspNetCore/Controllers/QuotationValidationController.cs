using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotationValidationController : ControllerBase
{
    private readonly IOpenTransXmlSerializerFactory serializerFactory;

    public QuotationValidationController(IOpenTransXmlSerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    [HttpPost("via-model-binding")]
    [Consumes("application/xml")]
    public void QuotationViaModelBinding(Quotation quotation)
    {
        // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
    }

    [HttpPost("via-stream")]
    [RawTextRequest]
    public void QuotationViaStream()
    {
        var serializer = serializerFactory.Create<Quotation>();

        using var stream = Request.BodyReader.AsStream();
        var quotation = serializer.Deserialize<Quotation>(stream);

        quotation.EnsureValid(serializer);
    }

    [HttpPost("via-file")]
    public void QuotationViaFile(IFormFile file)
    {
        var serializer = serializerFactory.Create<Quotation>();

        using var stream = file.OpenReadStream();
        var quotation = serializer.Deserialize<Quotation>(stream);

        quotation.EnsureValid(serializer);
    }

    [HttpPost("via-text")]
    public void QuotationViaText([FromForm(Name = "content")] string content)
    {
        var serializer = serializerFactory.Create<Quotation>();

        content.EnsureValidOpenTransDocument(serializer);
    }
}
