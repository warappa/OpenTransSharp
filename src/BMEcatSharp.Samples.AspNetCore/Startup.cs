using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace BMEcatSharp.Samples.AspNetCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddBMEcatSharp(configure =>
        {
            // register your custom UDX (user defined extension) types here
            configure.Serialization.IncludeUdxTypes =
            [
                typeof(CustomData),
                typeof(CustomData2)
            ];

            // if you need more control here the overrides can be customized
            configure.Serialization.ConfigureXmlAttributeOverrides = overrides =>
            {
                // add overrides
            };

            // add custom xsd for validation
            configure.Serialization.XsdUris = [new Uri($"file://{Environment.CurrentDirectory.Replace("\\", "/")}/CustomData.xsd")];

            // add xml-file encodings that must be supported
            configure.Serialization.SupportedEncodings.Add("iso-8859-1");

            // add xml-file content types that must be supported
            configure.Serialization.SupportedMediaTypes.Add("text/xml");
        });
        services.AddControllers(config =>
        {
            config.Filters.Add<ValidationExceptionFilter>();
        })
            // register for proper serialization over API
            .AddBMEcatSharpXmlSerializer();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            // optionally disable model state validation (also for BMEcat/OpenTrans models)
            //options.SuppressModelStateInvalidFilter = true;
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BMEcatSharp.Samples.AspNetCore", Version = "v1" });
            c.OperationFilter<RawTextRequestOperationFilter>();
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BMEcatSharp.Samples.AspNetCore v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
