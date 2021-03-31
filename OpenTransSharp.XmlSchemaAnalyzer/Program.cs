using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenTransSharp.XmlSchemaAnalyzer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var xDocBmeCat = XDocument.Load("bmecat_2005.1.xsd");
            var xDocOpenTrans = XDocument.Load("opentrans_2_1.xsd");

            var resolver = new RootTypeResolver();

            var bmeTypes = xDocBmeCat.XPathSelectElements("xDocBmeCat");
        }
    }
}
