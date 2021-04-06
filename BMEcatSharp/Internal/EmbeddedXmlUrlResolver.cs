using System;
using System.Diagnostics;
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

        public const string BaseUri = "embedded://";

        public EmbeddedXmlUrlResolver()
        {
            assembly = typeof(EmbeddedXmlUrlResolver).Assembly;
        }

        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            var uri = new Uri(BaseUri + "/" + relativeUri);
            return uri;
            //return base.ResolveUri(baseUri, relativeUri);
        }

        public Stream GetStream(string resourceName)
        {
            Debug.WriteLine("Get schema: " + resourceName);

            var searchName = FindEmbeddedName(resourceName);

            var stream = assembly.GetManifestResourceStream(searchName);

            if (stream is null)
            {
                throw new NullReferenceException($"Could not resolve '{resourceName}'");
            }

            return stream;
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

            return FindEmbeddedName(name);
        }

        private string FindEmbeddedName(string filenameOrResourceName)
        {

            var embeddedName = assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x == filenameOrResourceName);

            if (embeddedName is null)
            {
                filenameOrResourceName = Path.GetFileName(filenameOrResourceName);

                embeddedName = assembly.GetManifestResourceNames()
                    .FirstOrDefault(x => x.EndsWith($".{filenameOrResourceName}"));
            }

            return embeddedName;
        }
    }
}
