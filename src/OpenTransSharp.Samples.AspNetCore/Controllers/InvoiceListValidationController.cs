using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceListValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public InvoiceListValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public void InvoiceListViaModelBinding(InvoiceList invoiceList)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void InvoiceListViaStream()
        {
            var serializer = serializerFactory.Create<InvoiceList>();

            using var stream = Request.BodyReader.AsStream();
            var invoiceList = serializer.Deserialize<InvoiceList>(stream);

            invoiceList.EnsureValid(serializer);
        }

        [HttpPost("via-file")]
        public void InvoiceListViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<InvoiceList>();

            using var stream = file.OpenReadStream();
            var invoiceList = serializer.Deserialize<InvoiceList>(stream);

            invoiceList.EnsureValid(serializer);
        }

        [HttpPost("via-text")]
        public void InvoiceListViaText([FromForm(Name = "content")] string content)
        {
            var serializer = serializerFactory.Create<InvoiceList>();

            content.EnsureValidOpenTransDocument(serializer);
        }
    }
}
