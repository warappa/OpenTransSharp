using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.RequestForQuotations;

public class RequestForQuotationSerializationTests
{
    private readonly TestConfig testConfig;
    private OpenTransXmlSerializerFactory serializerFactory;
    private XmlSerializer target;

    public RequestForQuotationSerializationTests()
    {
        testConfig = new TestConfig();
    }

    [SetUp]
    public void Setup()
    {
        var options = new OpenTransXmlSerializerOptions
        {
            IncludeUdxTypes =
            [
                typeof(CustomData),
                typeof(CustomData2)
            ],
            XsdUris = [new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd")]
        };

        serializerFactory = new OpenTransXmlSerializerFactory(options);

        target = serializerFactory.Create<RequestForQuotation>();
    }

    [Test]
    public void Can_serialize_RequestForQuotation()
    {
        var order = testConfig.RequestForQuotations.GetRequestForQuotation();

        Action action = () => target.Serialize(order);
        action.Should().NotThrow();
    }

    [Test]
    public void Can_validate_RequestForQuotation()
    {
        var order = testConfig.RequestForQuotations.GetRequestForQuotation();

        //var serialized = target.Serialize(order);
        order.IsValid(target).Should().Be(true);
    }

    [Test]
    public void Can_validate_RequestForQuotation_with_UDX()
    {
        var order = testConfig.RequestForQuotations.GetRequestForQuotationWithUdx();

        var serialized = target.Serialize(order);
        Debug.WriteLine(serialized);
        order.IsValid(target).Should().Be(true);
    }
}
