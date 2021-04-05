using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
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
        public bool OrderResponseViaModelBinding(OrderResponse orderResponse)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult OrderResponseViaStream()
        {
            var serializer = serializerFactory.Create<OrderResponse>();
            
            using var stream = Request.BodyReader.AsStream();
            var orderResponse = serializer.Deserialize<OrderResponse>(stream);

            return orderResponse.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult OrderResponseViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<OrderResponse>();

            using var stream = file.OpenReadStream();
            var orderResponse = serializer.Deserialize<OrderResponse>(stream);

            return orderResponse.Validate(serializer);
        }
    }
}
