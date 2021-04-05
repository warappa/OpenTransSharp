using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemittanceAdviceValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public RemittanceAdviceValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool RemittanceAdviceViaModelBinding(RemittanceAdvice remittanceAdvice)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult RemittanceAdviceViaStream()
        {
            var serializer = serializerFactory.Create<RemittanceAdvice>();
            
            using var stream = Request.BodyReader.AsStream();
            var remittanceAdvice = serializer.Deserialize<RemittanceAdvice>(stream);

            return remittanceAdvice.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult RemittanceAdviceViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<RemittanceAdvice>();

            using var stream = file.OpenReadStream();
            var remittanceAdvice = serializer.Deserialize<RemittanceAdvice>(stream);

            return remittanceAdvice.Validate(serializer);
        }
    }
}
