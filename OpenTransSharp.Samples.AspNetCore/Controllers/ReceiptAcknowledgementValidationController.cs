using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;

namespace OpenTransSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptAcknowledgementValidationController : ControllerBase
    {
        private readonly IOpenTransXmlSerializerFactory serializerFactory;

        public ReceiptAcknowledgementValidationController(IOpenTransXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public void ReceiptAcknowledgementViaModelBinding(ReceiptAcknowledgement receiptAcknowledgement)
        {
            // validation implicitly by model binder, otherwise see ApiBehaviorOptions.SuppressModelStateInvalidFilter
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public void ReceiptAcknowledgementViaStream()
        {
            var serializer = serializerFactory.Create<ReceiptAcknowledgement>();
            
            using var stream = Request.BodyReader.AsStream();
            var receiptAcknowledgement = serializer.Deserialize<ReceiptAcknowledgement>(stream);

            receiptAcknowledgement.EnsureValid(serializer);
        }
        
        [HttpPost("via-file")]
        public void ReceiptAcknowledgementViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<ReceiptAcknowledgement>();

            using var stream = file.OpenReadStream();
            var receiptAcknowledgement = serializer.Deserialize<ReceiptAcknowledgement>(stream);

            receiptAcknowledgement.EnsureValid(serializer);
        }
    }
}
