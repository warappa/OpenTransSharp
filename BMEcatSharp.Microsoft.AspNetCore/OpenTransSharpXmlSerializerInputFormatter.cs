using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using BMEcatSharp.Xml;
using System;
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
                return base.CanReadType(type);
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
    }
}
