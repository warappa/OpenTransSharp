using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace OpenTransSharp.XmlSchemaAnalyzer
{
    [TestFixture]
    public class RootTypeResolverTests
    {
        private RootTypeResolver target;

        [SetUp]
        public void Initialize()
        {
            target = new RootTypeResolver();
        }

        [Test]
        public void Can_read_root_types()
        {
            var xDocBmeCat = XDocument.Load("bmecat_2005.xsd");

            var types = target.GetRootTypes(xDocBmeCat)
                .ToList();

            types.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Can_get_redefined_types()
        {
            var xDocBmeCat = XDocument.Load("bmecat_2005.xsd");
            var xDocOpenTrans = XDocument.Load("opentrans_2_1.xsd");

            var bmeTypes = target.GetRootTypes(xDocBmeCat)
                .ToList();
            var opentransTypes = target.GetRootTypes(xDocOpenTrans);

            var redefined = bmeTypes
                .Join(opentransTypes, x => x, x => x, (a, b) => b)
                .ToList();

            redefined.Count.Should().BeGreaterThan(0);

            Debug.WriteLine(redefined.Count);
            Debug.WriteLine(string.Join("\n", redefined));
        }
    }
}
