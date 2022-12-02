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
        public void RemittanceAdviceViaModelBinding(RemittanceAdvice remittanceAdvice)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void RemittanceAdviceViaStream()
        {
            var serializer = serializerFactory.Create<RemittanceAdvice>();

            using var stream = Request.BodyReader.AsStream();
            var remittanceAdvice = serializer.Deserialize<RemittanceAdvice>(stream);

            remittanceAdvice.EnsureValid(serializer);
        }

        [HttpPost("via-file")]
        public void RemittanceAdviceViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<RemittanceAdvice>();

            using var stream = file.OpenReadStream();
            var remittanceAdvice = serializer.Deserialize<RemittanceAdvice>(stream);

            remittanceAdvice.EnsureValid(serializer);
        }
    }
}
