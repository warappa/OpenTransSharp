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
        public void OrderChangeViaModelBinding(OrderChange orderChange)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void OrderChangeViaStream()
        {
            var serializer = serializerFactory.Create<OrderChange>();

            using var stream = Request.BodyReader.AsStream();
            var orderChange = serializer.Deserialize<OrderChange>(stream);

            orderChange.EnsureValid(serializer);
        }

        [HttpPost("via-file")]
        public void OrderChangeViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<OrderChange>();

            using var stream = file.OpenReadStream();
            var orderChange = serializer.Deserialize<OrderChange>(stream);

            orderChange.EnsureValid(serializer);
        }

        [HttpPost("via-text")]
        public void OrderChangeViaText([FromForm(Name = "content")] string content)
        {
            var serializer = serializerFactory.Create<OrderChange>();

            content.EnsureValidOpenTransDocument(serializer);
        }
    }
}
