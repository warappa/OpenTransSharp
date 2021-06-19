using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public InvoiceValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool InvoiceViaModelBinding(Invoice invoice)
        {
            return true; // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult InvoiceViaStream()
        {
            var serializer = serializerFactory.Create<Invoice>();
            
            using var stream = Request.BodyReader.AsStream();
            var invoice = serializer.Deserialize<Invoice>(stream);

            return invoice.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult InvoiceViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<Invoice>();

            using var stream = file.OpenReadStream();
            var invoice = serializer.Deserialize<Invoice>(stream);

            return invoice.Validate(serializer);
        }
    }
}
