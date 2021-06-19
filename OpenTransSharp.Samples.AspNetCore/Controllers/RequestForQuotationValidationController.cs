using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestForQuotationValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public RequestForQuotationValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool RequestForQuotationViaModelBinding(RequestForQuotation requestForQuotation)
        {
            return true; // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult RequestForQuotationViaStream()
        {
            var serializer = serializerFactory.Create<RequestForQuotation>();
            
            using var stream = Request.BodyReader.AsStream();
            var requestForQuotation = serializer.Deserialize<RequestForQuotation>(stream);

            return requestForQuotation.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult RequestForQuotationViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<RequestForQuotation>();

            using var stream = file.OpenReadStream();
            var requestForQuotation = serializer.Deserialize<RequestForQuotation>(stream);

            return requestForQuotation.Validate(serializer);
        }
    }
}
