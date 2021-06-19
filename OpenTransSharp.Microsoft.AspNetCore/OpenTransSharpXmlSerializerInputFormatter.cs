using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenTransSharp.Microsoft.AspNetCore
{
    public class OpenTransSharpXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly IOpenTransXmlSerializerFactory openTransXmlSerializerFactory;

        public OpenTransSharpXmlSerializerInputFormatter(MvcOptions options, IOpenTransXmlSerializerFactory openTransXmlSerializerFactory)
            : base(options)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new ArgumentNullException(nameof(openTransXmlSerializerFactory));

            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
        }

        protected override bool CanReadType(Type type)
        {
            try
            {
                return typeof(IOpenTransRoot).IsAssignableFrom(type);
            }
            catch
            {
                return false;
            }
        }

        protected override XmlSerializer CreateSerializer(Type type)
        {
            return openTransXmlSerializerFactory.Create(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var result = await base.ReadRequestBodyAsync(context, encoding);

            var serializer = GetCachedSerializer(context.ModelType);

            var xmlValidationResult = (result.Model as IOpenTransRoot).Validate(serializer);

            if (!xmlValidationResult.IsValid)
            {
                foreach (var error in xmlValidationResult.Errors)
                {
                    foreach (var message in error.Value)
                    {
                        context.ModelState.TryAddModelError(error.Key, message);
                    }
                }

                return InputFormatterResult.Failure();
            }

            return result;
        }
    }
}
