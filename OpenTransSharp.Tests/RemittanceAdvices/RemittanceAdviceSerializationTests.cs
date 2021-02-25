using FluentAssertions;
using NUnit.Framework;
using System;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.RemittanceAdvices
{
    public class RemittanceAdviceSerializationTests
    {
        private TestConfig testConfig;

        public RemittanceAdviceSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_serialize_RemittanceAdvice()
        {
            var order = testConfig.RemittanceAdvices.GetRemittanceAdvice();

            var serializer = new XmlSerializer(order.GetType());
            Action action = () => serializer.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_RemittanceAdvice()
        {
            var order = testConfig.RemittanceAdvices.GetRemittanceAdvice();

            var serializer = new XmlSerializer(order.GetType());
            //var serialized = serializer.Serialize(order);
            order.IsValid(serializer).Should().Be(true);
        }
    }
}