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
        public void DispatchNotificationViaModelBinding(DispatchNotification dispatchNotification)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void DispatchNotificationViaStream()
        {
            var serializer = serializerFactory.Create<DispatchNotification>();

            using var stream = Request.BodyReader.AsStream();
            var dispatchNotification = serializer.Deserialize<DispatchNotification>(stream);

            dispatchNotification.EnsureValid(serializer);
        }

        [HttpPost("via-file")]
        public void DispatchNotificationViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<DispatchNotification>();

            using var stream = file.OpenReadStream();
            var dispatchNotification = serializer.Deserialize<DispatchNotification>(stream);

            dispatchNotification.EnsureValid(serializer);
        }

        [HttpPost("via-text")]
        public void OrderViaFile([FromForm(Name = "content")] string content)
        {
            var serializer = serializerFactory.Create<DispatchNotification>();

            content.EnsureValidOpenTransDocument(serializer);
        }
    }
}
