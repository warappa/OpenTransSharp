using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Rfqs
{
    public class RfqSerializationTests
    {
        private TestConfig testConfig;

        public RfqSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_Rfq()
        {
            var order = testConfig.Rfqs.GetRfq();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_Rfq()
        {
            var order = testConfig.Rfqs.GetRfq();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}