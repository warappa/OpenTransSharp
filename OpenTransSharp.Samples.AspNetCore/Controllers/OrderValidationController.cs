using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public OrderValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool OrderViaModelBinding(Order order)
        {
            return true; // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult OrderViaStream()
        {
            var serializer = serializerFactory.Create<Order>();
            
            using var stream = Request.BodyReader.AsStream();
            var order = serializer.Deserialize<Order>(stream);

            return order.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult OrderViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<Order>();

            using var stream = file.OpenReadStream();
            var order = serializer.Deserialize<Order>(stream);

            return order.Validate(serializer);
        }
    }
}
