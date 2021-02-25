using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.DispatchNotifications
{
    public class DispatchNotificationSerializationTests
    {
        private TestConfig testConfig;

        public DispatchNotificationSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_DispatchNotification()
        {
            var order = testConfig.DispatchNotifications.GetDispatchNotification();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_DispatchNotification()
        {
            var order = testConfig.DispatchNotifications.GetDispatchNotification();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}