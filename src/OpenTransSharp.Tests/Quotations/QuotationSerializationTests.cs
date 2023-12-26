using FluentAssertions;
using NUnit.Framework;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace OpenTransSharp.Tests.Quotations;

public class QuotationSerializationTests
{
    private readonly TestConfig testConfig;
    private OpenTransXmlSerializerFactory serializerFactory;
    private XmlSerializer target;

    public QuotationSerializationTests()
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

        target = serializerFactory.Create<Quotation>();
    }

    [Test]
    public void Can_serialize_Quotation()
    {
        var order = testConfig.Quotations.GetQuotation();

        Action action = () => target.Serialize(order);
        action.Should().NotThrow();
    }

    [Test]
    public void Can_validate_Quotation()
    {
        var order = testConfig.Quotations.GetQuotation();

        //var serialized = target.Serialize(order);
        order.IsValid(target).Should().Be(true);
    }

    [Test]
    public void Can_validate_Quotation_with_UDX()
    {
        var order = testConfig.Quotations.GetQuotationWithUdx();

        var serialized = target.Serialize(order);
        Debug.WriteLine(serialized);
        order.IsValid(target).Should().Be(true);
    }
}
