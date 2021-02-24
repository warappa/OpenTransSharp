using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.OrderChanges
{
    public class OrderChangeSerializationTests
    {
        private TestConfig testConfig;

        public OrderChangeSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_OrderChange()
        {
            var order = testConfig.OrderChanges.GetOrderChange();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }
    }
}