using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestForQuotationValidationController : ControllerBase
{
    private readonly IOpenTransXmlSerializerFactory serializerFactory;

    public RequestForQuotationValidationController(IOpenTransXmlSerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    [HttpPost("via-model-binding")]
    [Consumes("application/xml")]
    public void RequestForQuotationViaModelBinding(RequestForQuotation requestForQuotation)
    {
        // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
    }

    [HttpPost("via-stream")]
    [RawTextRequest]
    public void RequestForQuotationViaStream()
    {
        var serializer = serializerFactory.Create<RequestForQuotation>();

        using var stream = Request.BodyReader.AsStream();
        var requestForQuotation = serializer.Deserialize<RequestForQuotation>(stream);

        requestForQuotation.EnsureValid(serializer);
    }

    [HttpPost("via-file")]
    public void RequestForQuotationViaFile(IFormFile file)
    {
        var serializer = serializerFactory.Create<RequestForQuotation>();

        using var stream = file.OpenReadStream();
        var requestForQuotation = serializer.Deserialize<RequestForQuotation>(stream);

        requestForQuotation.EnsureValid(serializer);
    }

    [HttpPost("via-text")]
    public void RequestForQuotationViaText([FromForm(Name = "content")] string content)
    {
        var serializer = serializerFactory.Create<RequestForQuotation>();

        content.EnsureValidOpenTransDocument(serializer);
    }
}
