using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispatchNotificationValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public DispatchNotificationValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool DispatchNotificationViaModelBinding(DispatchNotification dispatchNotification)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult DispatchNotificationViaStream()
        {
            var serializer = serializerFactory.Create<DispatchNotification>();
            
            using var stream = Request.BodyReader.AsStream();
            var dispatchNotification = serializer.Deserialize<DispatchNotification>(stream);

            return dispatchNotification.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult DispatchNotificationViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<DispatchNotification>();
            
            using var stream = file.OpenReadStream();
            var dispatchNotification = serializer.Deserialize<DispatchNotification>(stream);

            return dispatchNotification.Validate(serializer);
        }
    }
}
