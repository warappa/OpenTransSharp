using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.RemittanceAdvices
{
    public class RemittanceAdviceSerializationTests
    {
        private readonly TestConfig testConfig;
        private OpenTransXmlSerializerFactory serializerFactory;
        private XmlSerializer target;

        public RemittanceAdviceSerializationTests()
        {
            testConfig = new TestConfig();
        }

        [SetUp]
        public void Setup()
        {
            var options = new OpenTransXmlSerializerOptions
            {
                IncludeUdxTypes = new[]
                {
                    typeof(CustomData),
                    typeof(CustomData2)
                },
                XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") }
            };

            serializerFactory = new OpenTransXmlSerializerFactory(options);

            target = serializerFactory.Create<RemittanceAdvice>();
        }

        [Test]
        public void Can_serialize_RemittanceAdvice()
        {
            var order = testConfig.RemittanceAdvices.GetRemittanceAdvice();

            Action action = () => target.Serialize(order);
            action.Should().NotThrow();
        }

        [Test]
        public void Can_validate_RemittanceAdvice()
        {
            var order = testConfig.RemittanceAdvices.GetRemittanceAdvice();

            //var serialized = target.Serialize(order);
            order.IsValid(target).Should().Be(true);
        }

        [Test]
        public void Can_validate_RemittanceAdvice_with_UDX()
        {
            var order = testConfig.RemittanceAdvices.GetRemittanceAdviceWithUdx();

            var serialized = target.Serialize(order);
            Debug.WriteLine(serialized);
            order.IsValid(target).Should().Be(true);
        }
    }
}
