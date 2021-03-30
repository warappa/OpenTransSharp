using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Orders
{
    public class OrderSerializationTests
    {
        private TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public OrderSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransOptions();
            options.Serialization.IncludeUdxTypes = new[]
            {
                typeof(CustomData),
                typeof(CustomData2) 
            };

            serializerFactory = new OpenTransXmlSerializerFactory(options);

            target = serializerFactory.Create<Order>();
        }

        [Test]
        public void Can_serialize_Order()
        {
            var order = testConfig.Orders.GetOrder();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_Order()
        {
            var order = testConfig.Orders.GetOrder();

            //var serialized = serializer.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_Order_with_UDX()
        {
            var order = testConfig.Orders.GetOrderWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }
    }
}