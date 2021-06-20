### OpenTransSharp and BMEcatSharp

#### About This Project

This project enables **reading, editing, writing and validating openTRANS® 2.1 and BMEcat® 2005 files**.
While developing, your **IntelliSense** is enriched with contents of the official specification-documents.
It also provides seamless integration into **Microsoft.Extensions.DependencyInjection** and **ASP.NET Core**.

This project is built on the **[.NET](https://dot.net)** platform and uses the **MPL 2.0 license** (see [MPL 2.0 TLDR;](#mpl-20-TLDR) for what that means for you).

#### Features

* Compatible with **.NET Standard 2.0**, **.NET Core 2.1+** or **.NET 5+**
* **Rich IntelliSense** extended with contents of the official specification-documents
  * Meaning of elements/attributes
  * Required elements
  * Choices between elements
* **Reading/editing/writing** BMEcat®- and openTRANS®-files
  * **Enums** where possible, like `LanguageCodes`, `Unit`, `PackageUnit`, `CountryCode`, `OrderType`, `MimePurpose`, `PartyRole`,... and many more
* **Validation** against official XSDs
  * Including adding **custom XSD validations** (see UDX below)
* Proper support for **User-Defined-Extension** data (UDX)
  * Enhance your documents with **custom data**
* **Microsoft.Extensions.DependencyInjection** integration
  * **Extension methods** for service registration (with optional options)
* **ASP.NET Core** integration
  * **Model-binding** support
  * **Model state** support
  * **Custom encodings and content-types** support
* **BMEcat® 2005** support
  * Module **Classification Systems, Catalog Groups Systems, and Feature Systems**
  * Module **Product Configuration**
  * Module **Price Formulas**
  * Module **Integrated Procurement Point**
  * **Multilingual Strings**
* **openTRANS® 2.1** support
  * **RFQ** (request for quotation)
  * **Quotation**
  * **Order**
  * **Order-Change**
  * **Order-Response** (confirmation of order)
  * **Dispatch-Notification**
  * **Receipt-Acknowledgement** (acknowledgement of receipt of goods)
  * **Invoice**
  * **Invoice-List** (collective invoice)
  * **Remittance-Advice** (Notification or remittance)
  * **Multilingual Strings**

### Usage

#### Reading

Here are **3 ways** of reading a openTRANS®-document in **ASP.NET Core**:

**Note**: for BMEcat®-documents, it works the same way, but using `IBMEcatXmlSerializerFactory` instead of `IOpenTransXmlSerializerFactory`.

```csharp
...
using OpenTransSharp;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
...
[ApiController]
[Route("[controller]")]
public class ValidationController : ControllerBase
{
    private readonly IOpenTransXmlSerializerFactory serializerFactory;

    public ValidationController(IOpenTransXmlSerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory ?? throw new ArgumentNullException(nameof(serializerFactory));
    }

    [HttpPost("via-model-binding")]
    public void ViaModelBinding(Order order)
    {
        // validation implicitly by model binder
    }

    [HttpPost("via-stream")]
    public void ViaStream()
    {
        var serializer = serializerFactory.Create<Order>();

        using var stream = Request.BodyReader.AsStream();
        var document = serializer.Deserialize<Order>(stream);

        document.EnsureValid(serializer);
        // or manually validate your document
        //var validationResult = document.Validate(serializer);
    }

    [HttpPost("via-file")]
    public void ViaFile(IFormFile file)
    {
        var serializer = serializerFactory.Create<Order>();

        var stream = file.OpenReadStream();
        var document = serializer.Deserialize<Order>(stream);

        document.EnsureValid(serializer);
    }
}
```

#### Editing and Writing

openTRANS®- and BMEcat®-documents can be easily **modelled like any other C# Type**.

**Rich IntelliSense** helps you building the documents in the right, valid way, be leveraging the content of the specifications.

```csharp
using OpenTransSharp;
using OpenTransSharp.Xml;
...
var serializer = serializerFactory.Create<Order>();

var document = new Order()
{
	Type = OrderType.Express    
}
document.Header = new OrderHeader
{
    ControlInformation = new ControlInformation
    {
        GenerationDate = DateTime.UtcNow,
        GeneratorInfo = "Demo"
    },
    SourcingInformation = new SourcingInformation { ... }
    ...
};
document.Items.Add(new OrderItem
{
    LineItemId = "1",
    ProductId = new ProductId 
    { 
        SupplierPid = new SupplierPid("A0123456789", SupplierPidTypeValues.Ean);    
    },
    Quantity = 2,
    OrderUnit = PackageUnit.C62, // pieces
    ...
});

var serializedString = serializer.Serialize(document);
```

#### Validation

You can **validate all root-documents** like `BMEcatDocument`, `Order`, `Invoice`,... against the **official XSDs** - without having to fiddle with them. Validation is easy with the provided `Validate` extensions method.

You can manually validate you documents like this:

```csharp
using OpenTransSharp;
using OpenTransSharp.Validation;
using OpenTransSharp.Xml;
// if you want to validate BMEcat® documents use the following namespaces:
//using BMEcatSharp;
//using BMEcatSharp.Validation;
//using BMEcatSharp.Xml;
...
var validationResult = order.Validate(serializer);

if (!validationResult.IsValid)
{
    foreach(var error in validationResult.Errors)
    {
    	foreach(var message in error.Value)
        {
            Console.WriteLine($"{error.Key}: {message}");
        }
    }
}
```

Or you can just call `EnsureValid`, which throws a `OpenTransSharp.Validation.ValidationException` if not valid:

```csharp
order.EnsureValid(serializer);
```

### Setup Your Project

BMEcatSharp and OpenTransSharp can be used in any **.NET Standard 2.0** compatible, **.NET Core 2.1+** or **.NET 5** project.

**Note**: For **complete samples** of how to use this library, please see the code samples in this repository under

* [BMEcatSharp.Samples.AspNetCore](https://github.com/warappa/OpenTransSharp/tree/main/BMEcatSharp.Samples.AspNetCore) and
* [OpenTransSharp.Samples.AspNetCore](https://github.com/warappa/OpenTransSharp/tree/main/OpenTransSharp.Samples.AspNetCore)

#### NuGet Packages

Depending on the desired integrations, you can pick **1 of 3 options**:

**A)** If you want to integrate with **ASP.NET Core**, you can use the following NuGet packages:

* [![NuGet](https://img.shields.io/nuget/v/BMEcatSharp.Microsoft.AspNetCore.svg)](https://nuget.org/packages/BMEcatSharp.Microsoft.AspNetCore) [BMEcatSharp.Microsoft.AspNetCore](https://nuget.org/packages/BMEcatSharp.Microsoft.AspNetCore)
* [![NuGet](https://img.shields.io/nuget/v/OpenTransSharp.Microsoft.AspNetCore.svg)](https://nuget.org/packages/OpenTransSharp.Microsoft.AspNetCore) [OpenTransSharp.Microsoft.AspNetCore](https://nuget.org/packages/OpenTransSharp.Microsoft.AspNetCore)

**Note**: You need *both* if you want to read/edit/write/validate BMEcat®- *and* openTRANS®-documents in your project.

**B)** Otherwise, if you only want to integrate with **Microsoft.Extensions.DependencyInjection**, you can use the following NuGet packages:

* [![NuGet](https://img.shields.io/nuget/v/BMEcatSharp.Microsoft.Extensions.DependencyInjection.svg)](https://nuget.org/packages/BMEcatSharp.Microsoft.Extensions.DependencyInjection) [BMEcatSharp.Microsoft.Extensions.DependencyInjection](https://nuget.org/packages/BMEcatSharp.Microsoft.Extensions.DependencyInjection)
* [![NuGet](https://img.shields.io/nuget/v/OpenTransSharp.Microsoft.Extensions.DependencyInjection.svg)](https://nuget.org/packages/OpenTransSharp.Microsoft.Extensions.DependencyInjection)[ OpenTransSharp.Microsoft.Extensions.DependencyInjection](https://nuget.org/packages/OpenTransSharp.Microsoft.Extensions.DependencyInjection)

**Note**: You need *both* if you want to read/edit/write/validate BMEcat®- and openTRANS®-documents in your project.

**C)** And finally, if you don't need any of the above integrations but **only core funcationality**, you can use the following NuGet packages:

* [![NuGet](https://img.shields.io/nuget/v/BMEcatSharp.svg)](https://nuget.org/packages/BMEcatSharp) [BMEcatSharp](https://nuget.org/packages/BMEcatSharp) - if you only need BMEcatSharp
* [![NuGet](https://img.shields.io/nuget/v/OpenTransSharp.svg)](https://nuget.org/packages/OpenTransSharp) [OpenTransSharp](https://nuget.org/packages/OpenTransSharp) - if you need OpenTransSharp (has a dependency on BMEcatSharp)

#### ASP.NET Core Setup

Registering the ASP.NET Core integrations as shown here.
These integrations add input formatters for **model-binding** and **model-state** handling.

##### OpenTransSharp

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddOpenTransSharp(configure =>
    {
        // optional: register your custom UDX (user defined extension) types here
        configure.Serialization.IncludeUdxTypes = new[]
        {
            typeof(CustomData),
            typeof(CustomData2)
        };

        // optional: add custom xsd for validation
        configure.Serialization.XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") };

        // optional: add xml-file encodings that must be supported
        configure.Serialization.SupportedEncodings.Add("iso-8859-1");

        // optional: add xml-file content types that must be supported
        configure.Serialization.SupportedMediaTypes.Add("text/xml");

        // optional: if you need more control here the overrides can be customized
        configure.Serialization.ConfigureXmlAttributeOverrides = overrides =>
        {
            // add overrides
        };
    });
    services.AddControllers()
        // register for proper serialization over API
        .AddOpenTransSharpXmlSerializer();
    ...
}
```

##### BMEcatSharp

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBMEcatSharp(configure =>
    {
        // optional: register your custom UDX (user defined extension) types here
        configure.Serialization.IncludeUdxTypes = new[]
        {
            typeof(CustomData),
            typeof(CustomData2)
        };

        // optional: add custom xsd for validation
        configure.Serialization.XsdUris = new[] { new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd") };

        // optional: add xml-file encodings that must be supported
        configure.Serialization.SupportedEncodings.Add("iso-8859-1");

        // optional: add xml-file content types that must be supported
        configure.Serialization.SupportedMediaTypes.Add("text/xml");

        // optional: if you need more control here the overrides can be customized
        configure.Serialization.ConfigureXmlAttributeOverrides = overrides =>
        {
            // add overrides
        };
    });
    services.AddControllers()
        // register for proper serialization over API
        .AddBMEcatSharpXmlSerializer();
    ...
}
```

#### Microsoft.Extensions.DependencyInjection Setup

If don't need ASP.NET Core but `Microsoft.Extensions.DependencyInjection` integration, the previous sample sections calling 

* `services.AddBMEcatSharp(...)` respectively 
* `services.AddOpenTransSharp(...)` 

are the actual `Microsoft.Extensions.DependencyInjection` integration.

#### Core Functionality Setup

If you don't need any integrations, you can just simply use the core functionality.

##### BMEcatSharp

```csharp
using BMEcatSharp;
...
var options = new BMEcatXmlSerializerOptions();
var serializerFactory = new BMEcatXmlSerializerFactory(options);
// from here on see previous usage examples
```

##### OpenTransSharp

```csharp
using OpenTransSharp;
...
var options = new OpenTransXmlSerializerOptions();
var serializerFactory = new OpenTransXmlSerializerFactory(options);
// from here on see previous usage examples

```

### Building this library

#### Prerequisites

* Ensure you have **.NET SDK 5.0+** installed (see https://dot.net)

* Checkout this repository to your computer

* Install [Visual Studio 2019](https://visualstudio.microsoft.com/de/downloads/) if you want to build or develop with it

  **Note**: Visual Studio 2019 *Community Edition* is free for private use or small teams

#### Building with the command line

1. Open command prompt and navigate to your checkout-directory
2. Run `dotnet build`

#### Building with Visual Studio 2019

1. Open `OpenTransSharp.sln` with Visual Studio 2019
2. In main menu click `Build` > `Build Solution` (or press <kbd>CTRL+SHIFT+B</kbd>)

### About BMEcat® and openTRANS®

In short:

* BMEcat® is about **product catalogs**
* openTRANS® is about **ordering products** (optionally from BMEcat® catalogs)

For more information about openTRANS® and BMEcat® see here:

##### Official Information

* BMEcat® information
  https://www.bme.de/initiativen/bmecat/bmecat-2005/
* BMEcat® specification + XSDs download
  https://www.bme.de/initiativen/bmecat/download/

* openTRANS® information
  https://www.opentrans.de/

  https://www.bme.de/initiativen/bmecat/e-commerce-standard-opentransr/

* openTRANS® specification + XSDs download
  https://www.digital.iao.fraunhofer.de/de/publikationen/OpenTRANS21/Download-OpenTrans_V2_1.html

##### Wikipedia

https://de.wikipedia.org/wiki/OpenTRANS

https://de.wikipedia.org/wiki/BMEcat

### Licenses

**Copyright 2021 David Rettenbacher**

The license of this project is **MPL 2.0**. If not stated otherwise in individual files, this license applies to all files of this project. 

For **MPL 2.0** see the [LICENSE.md](LICENSE.md) file or browse to http://mozilla.org/MPL/2.0/ for the full license text. Additionally you can read up on this license on [Wikipedia](https://en.wikipedia.org/wiki/Mozilla_Public_License), and some Q&A on [StackOverflow](https://opensource.stackexchange.com/questions/8831/pros-and-cons-of-using-mpl-2-0-license).

This project also uses specifications and XSDs from BMEcat®, openTRANS® and W3C®.

For **BMEcat®** see [LICENSE-BMEcat.md](LICENSE-BMEcat.md), and for **openTRANS®** see [LICENSE-openTRANS.md](LICENSE-openTRANS.md).

**W3C®** files contain a license header.

##### MPL 2.0 TLDR;

* **You can link this project statically or dynamically** with your program, regardless of your program's license
  * You can distribute this library with your software under the terms of the GPL licenses
* Contributions/modifications/forks must **stay MPL 2.0**

### Disclaimer

This project has no affiliation with the official owners of BMEcat®, openTRANS®, or W3C®.  
All trade, company and product names, trademarks or registered trademarks belong to their respective holders.