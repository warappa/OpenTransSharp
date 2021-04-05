using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public QuotationValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool QuotationViaModelBinding(Quotation quotation)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult QuotationViaStream()
        {
            var serializer = serializerFactory.Create<Quotation>();
            
            using var stream = Request.BodyReader.AsStream();
            var quotation = serializer.Deserialize<Quotation>(stream);

            return quotation.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult QuotationViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<Quotation>();

            using var stream = file.OpenReadStream();
            var quotation = serializer.Deserialize<Quotation>(stream);

            return quotation.Validate(serializer);
        }
    }
}
