using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderChangeValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public OrderChangeValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool OrderChangeViaModelBinding(OrderChange orderChange)
        {
            return true; // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult OrderChangeViaStream()
        {
            var serializer = serializerFactory.Create<OrderChange>();
            
            using var stream = Request.BodyReader.AsStream();
            var orderChange = serializer.Deserialize<OrderChange>(stream);

            return orderChange.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult OrderChangeViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<OrderChange>();

            using var stream = file.OpenReadStream();
            var orderChange = serializer.Deserialize<OrderChange>(stream);

            return orderChange.Validate(serializer);
        }
    }
}
