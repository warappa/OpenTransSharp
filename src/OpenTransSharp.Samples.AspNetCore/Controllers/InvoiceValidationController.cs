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
        public void InvoiceViaModelBinding(Invoice invoice)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void InvoiceViaStream()
        {
            var serializer = serializerFactory.Create<Invoice>();

            using var stream = Request.BodyReader.AsStream();
            var invoice = serializer.Deserialize<Invoice>(stream);

            invoice.EnsureValid(serializer);
        }

        [HttpPost("via-file")]
        public void InvoiceViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<Invoice>();

            using var stream = file.OpenReadStream();
            var invoice = serializer.Deserialize<Invoice>(stream);

            invoice.EnsureValid(serializer);
        }

        [HttpPost("via-text")]
        public void InvoiceViaText([FromForm(Name = "content")] string content)
        {
            var serializer = serializerFactory.Create<Invoice>();

            content.EnsureValidOpenTransDocument(serializer);
        }
    }
}
