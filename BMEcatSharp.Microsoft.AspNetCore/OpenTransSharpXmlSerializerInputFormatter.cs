using BMEcatSharp.Validation;
using BMEcatSharp.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BMEcatSharp.Microsoft.AspNetCore
{
    public class BMEcatSharpXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly BMEcatXmlSerializerOptions serializerOptions;
        private readonly IBMEcatXmlSerializerFactory openTransXmlSerializerFactory;

        public BMEcatSharpXmlSerializerInputFormatter(MvcOptions options, BMEcatXmlSerializerOptions serializerOptions,
            IBMEcatXmlSerializerFactory openTransXmlSerializerFactory)
            : base(options)
        {
            this.serializerOptions = serializerOptions ?? throw new ArgumentNullException(nameof(serializerOptions));
            this.openTransXmlSerializerFactory = openTransXmlSerializerFactory ?? throw new ArgumentNullException(nameof(openTransXmlSerializerFactory));

            if (serializerOptions.SupportedMediaTypes is not null)
            {
                SupportedEncodings.Clear();
                foreach (var mediaType in serializerOptions.SupportedMediaTypes)
                {
                    SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
                }
            }

            if (serializerOptions.SupportedEncodings is not null)
            {
                SupportedEncodings.Clear();
                foreach (var encoding in serializerOptions.SupportedEncodings)
                {
                    SupportedEncodings.Add(Encoding.GetEncoding(encoding));
                }
            }
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

        // workaround "only-unicode-supported" bug
        // https://forums.asp.net/t/2001154.aspx?Web+API+XmlMediaTypeFormatter+ModelBinding+fails+when+posting+XML+using+character+encoding+other+than+default
        protected override XmlReader CreateXmlReader(Stream readStream, Encoding encoding)
        {
            return XmlReader.Create(readStream);
        }
    }
}
