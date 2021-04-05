﻿using BMEcatSharp.Validation;
using BMEcatSharp.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BMEcatSharp.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly IBMEcatXmlSerializerFactory serializerFactory;

        public ValidationController(IBMEcatXmlSerializerFactory serializerFactory)
        {
            this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
        }

        [HttpPost("via-model-binding")]
        [Consumes("application/xml")]
        public bool ViaModelBinding(BMEcatDocument document)
        {
            return true; // validation implicitly by model binder
        }

        [HttpPost("via-stream")]
        [RawTextRequest]
        public ValidationResult ViaStream()
        {
            var serializer = serializerFactory.Create<BMEcatDocument>();
            
            using var stream = Request.BodyReader.AsStream();
            var document = serializer.Deserialize<BMEcatDocument>(stream);

            return document.Validate(serializer);
        }
        
        [HttpPost("via-file")]
        public ValidationResult ViaFile(IFormFile file)
        {
            var serializer = serializerFactory.Create<BMEcatDocument>();
            
            var stream = file.OpenReadStream();
            var document = serializer.Deserialize<BMEcatDocument>(stream);

            return document.Validate(serializer);
        }
    }
}