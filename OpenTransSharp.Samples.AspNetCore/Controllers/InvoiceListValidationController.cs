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
        public bool InvoiceListViaModelBinding(InvoiceList invoiceList)
        {
            return true; // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult InvoiceListViaStream()
        {
            var serializer = serializerFactory.Create<InvoiceList>();
            
            using var stream = Request.BodyReader.AsStream();
            var invoiceList = serializer.Deserialize<InvoiceList>(stream);

            return invoiceList.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult InvoiceListViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<InvoiceList>();

            using var stream = file.OpenReadStream();
            var invoiceList = serializer.Deserialize<InvoiceList>(stream);

            return invoiceList.Validate(serializer);
        }
    }
}
