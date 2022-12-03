using BMEcatSharp.Samples.AspNetCore;
using BMEcatSharp.Validation;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BMEcatSharp.Microsoft.AspNetCore.Tests
{
    public class IntegrationTests
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [Test]
        public async Task Can_parse_valid_BMEcatDocument_via_stream()
        {
            using var stream = File.OpenRead("bmecat-sample.xml");

            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            var result = await client.PostAsync("validation/via-stream", content);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task Cannot_parse_invalid_BMEcatDocument_via_stream()
        {
            using var stream = File.OpenRead("bmecat-sample-invalid.xml");

            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            var result = await client.PostAsync("validation/via-stream", content);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var error = await GetValidationResult(result);
            error.Errors.First().Value[0].Should().Contain("MaxLength");
        }

        [Test]
        public async Task Can_parse_valid_BMEcatDocument_via_model_binding()
        {
            using var stream = File.OpenRead("bmecat-sample.xml");

            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            var result = await client.PostAsync("validation/via-model-binding", content);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task Cannot_parse_invalid_BMEcatDocument_via_model_binding()
        {
            using var stream = File.OpenRead("bmecat-sample-invalid.xml");

            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");

            var result = await client.PostAsync("validation/via-model-binding", content);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var error = await GetValidationResult(result);
            error.Errors.ElementAt(1).Value[0].Should().Contain("MaxLength");
        }

        [Test]
        public async Task Can_parse_valid_BMEcatDocument_via_file()
        {
            using var stream = File.OpenRead("bmecat-sample.xml");

            var content = new MultipartFormDataContent
            {
                {new StreamContent(stream), "file", "bmecat-sample.xml"}
            };

            var result = await client.PostAsync("validation/via-file", content);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task Cannot_parse_invalid_BMEcatDocument_via_file()
        {
            using var stream = File.OpenRead("bmecat-sample-invalid.xml");

            var content = new MultipartFormDataContent
            {
                {new StreamContent(stream), "file", "bmecat-sample-invalid.xml"}
            };

            var result = await client.PostAsync("validation/via-file", content);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var error = await GetValidationResult(result);
            error.Errors.First().Value[0].Should().Contain("MaxLength");
        }

        private static async Task<ValidationResult> GetValidationResult(HttpResponseMessage result)
        {
            var errorJson = await result.Content.ReadAsStringAsync();
            var error = JsonSerializer.Deserialize<ValidationResult>(errorJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return error;
        }
    }
}
