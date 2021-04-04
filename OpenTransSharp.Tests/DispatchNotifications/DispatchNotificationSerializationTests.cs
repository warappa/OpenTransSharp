using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.DispatchNotifications
{
    public class DispatchNotificationSerializationTests
    {
        private readonly TestConfig testConfig;

        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public DispatchNotificationSerializationTests()
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

            target = serializerFactory.Create<DispatchNotification>();
        }

        [Test]
        public void Can_serialize_DispatchNotification()
        {
            var order = testConfig.DispatchNotifications.GetDispatchNotification();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_DispatchNotification()
        {
            var order = testConfig.DispatchNotifications.GetDispatchNotification();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_DispatchNotification_with_UDX()
        {
            var order = testConfig.DispatchNotifications.GetDispatchNotificationWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_deserialize_sample_DispatchNotification()
        {
            var stream = File.Open(@"DispatchNotifications\sample_dispatchnotification_opentrans_2_1.xml", FileMode.Open);

            var dispatchNotification = target.Deserialize<DispatchNotification>(stream);

            dispatchNotification.IsValid(target).Should().Be(true);
        }
    }
}