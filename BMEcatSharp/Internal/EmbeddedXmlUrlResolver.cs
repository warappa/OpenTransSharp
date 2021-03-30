using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace BMEcatSharp.Internal
{
    internal class EmbeddedXmlUrlResolver : XmlUrlResolver
    {
        private Assembly assembly;

        public EmbeddedXmlUrlResolver()
        {
            assembly = typeof(EmbeddedXmlUrlResolver).Assembly;
        }

        public Stream GetStream(string resourceName)
        {
            var embeddedName = FindEmbeddedName(new Uri(resourceName));

            return assembly.GetManifestResourceStream(embeddedName);
        }

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            object stream = GetStream(absoluteUri.AbsoluteUri);

            if (stream is null)
            {
                stream = base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }

            return stream;
        }

        public override async Task<object> GetEntityAsync(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            object stream = GetStream(absoluteUri.AbsoluteUri);

            if (stream is null)
            {
                stream = await base.GetEntityAsync(absoluteUri, role, ofObjectToReturn);
            }

            return stream;
        }

        private string FindEmbeddedName(Uri absoluteUri)
        {
            var name = absoluteUri.Segments[absoluteUri.Segments.Length - 1];
            var embeddedName = assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.EndsWith($".{name}"));
            return embeddedName;
        }
    }
}
