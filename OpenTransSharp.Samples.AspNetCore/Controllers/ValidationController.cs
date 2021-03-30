using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using System;
using System.Threading.Tasks;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public ValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("order-via-model-binding")]
        [Consumes("application/xml")]
        public bool OrderViaModelBinding(Order order)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("order-via-stream")]
        [RawTextRequest]
        public async Task<ValidationResult> OrderViaStream()
        {
            var serializer = serializerFactory.Create<Order>();
            
            using var stream = Request.BodyReader.AsStream();
            var order = serializer.Deserialize<Order>(stream);

            return order.Validate(serializer);
        }
        
        [HttpPost("order-via-file")]
        public async Task<ValidationResult> OrderViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<Order>();
            
            var stream = file.OpenReadStream();
            var order = serializer.Deserialize<Order>(stream);

            return order.Validate(serializer);
        }
    }
}
