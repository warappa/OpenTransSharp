using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderResponseValidationController : ControllerBase
{
    private readonly IOpenTransXmlSerializerFactory serializerFactory;

    public OrderResponseValidationController(IOpenTransXmlSerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    [HttpPost("via-model-binding")]
    [Consumes("application/xml")]
    public void OrderResponseViaModelBinding(OrderResponse orderResponse)
    {
        // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
    }

    [HttpPost("via-stream")]
    [RawTextRequest]
    public void OrderResponseViaStream()
    {
        var serializer = serializerFactory.Create<OrderResponse>();

        using var stream = Request.BodyReader.AsStream();
        var orderResponse = serializer.Deserialize<OrderResponse>(stream);

        orderResponse.EnsureValid(serializer);
    }

    [HttpPost("via-file")]
    public void OrderResponseViaFile(IFormFile file)
    {
        var serializer = serializerFactory.Create<OrderResponse>();

        using var stream = file.OpenReadStream();
        var orderResponse = serializer.Deserialize<OrderResponse>(stream);

        orderResponse.EnsureValid(serializer);
    }

    [HttpPost("via-text")]
    public void OrderResponseViaText([FromForm(Name = "content")] string content)
    {
        var serializer = serializerFactory.Create<OrderResponse>();

        content.EnsureValidOpenTransDocument(serializer);
    }
}
