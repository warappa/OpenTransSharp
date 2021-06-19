using BMEcatSharp.Validation;
using BMEcatSharp.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BMEcatSharp.Microsoft.AspNetCore
{
    public class BMEcatSharpXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly IBMEcatXmlSerializerFactory openTransXmlSerializerFactory;

        public BMEcatSharpXmlSerializerInputFormatter(MvcOptions options, IBMEcatXmlSerializerFactory openTransXmlSerializerFactory)
            : base(options)
        {
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new ArgumentNullException(nameof(openTransXmlSerializerFactory));

            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
        }

        protected override bool CanReadType(Type type)
        {
            try
            {
                return typeof(BMEcatDocument) == type;
            }
            catch
            {
                return false;
            }
        }

        protected override XmlSerializer? CreateSerializer(Type type)
        {
            try
            {
                return openTransXmlSerializerFactory.Create(type);
            }
            catch
            {
                return null;
            }
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var result = await base.ReadRequestBodyAsync(context, encoding);

            if (result.Model is null)
            {
                context.ModelState.TryAddModelError("", $"'{context.ModelType.FullName}' could not be parsed");
            }
            else
            {
                var serializer = GetCachedSerializer(context.ModelType);

                var xmlValidationResult = ((BMEcatDocument)result.Model).Validate(serializer);

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
            }

            return result;
        }
    }
}
