using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BMEcatSharp.Samples.AspNetCore
{
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
                configure.Serialization.IncludeUdxTypes = new[]
                {
                    typeof(CustomData),
                    typeof(CustomData2)
                };

                // if you need more control here the overrides can be customized
                configure.Serialization.ConfigureXmlAttributeOverrides = overrides =>
                {
                    // add overrides
                };
            });
            services.AddControllers()
                // register for proper serialization over API
                .AddBMEcatSharpXmlSerializer();

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
}
