using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Orders
{
    public class OrderSerializationTests
    {
        private TestConfig testConfig;

        public OrderSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_Order()
        {
            var order = testConfig.Orders.GetOrder();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }
    }
}