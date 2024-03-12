using System;
using NUV.Cep.Infra.IoC;
using NUV.Cep.Infra.IoC.Configurations;
using CBL.Startup.Custom.Setups;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nuuvify.CommonPack.Email;
using Nuuvify.CommonPack.Middleware;
using Nuuvify.CommonPack.Middleware.Handle;
using Nuuvify.CommonPack.OpenApi;
using Nuuvify.CommonPack.StandardHttpClient;
using Nuuvify.CommonPack.StandardHttpClient.WebServices;

namespace CBL.Startup.Custom
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>(
                (module, o) =>
                {
                    module.EnableSqlCommandTextInstrumentation = true;
                }
            );

            services.AddLocalizationSetup();
            services.AddDbContextPoolSetup(Configuration);

            services.AddCacheSetup(Configuration);
            services.AddMvcSetup();
            services.AddCorsConfigurationSetup();
            services.AddCompressionSetup();
            services.AddApiVersioningSetup();
            services.AddNuvAuthorizationSetup(Configuration);

            services.AddStandardHttpClientSetup(Configuration, false);
            services.AddStandardWebServiceSetup();
            services.AddHealthChecksSetup(Configuration);
            services.AddNuvHttpClient(Configuration);

            services.AddEmailSetup(Configuration);
            services.AddGlobalHandlerExceptionSetup();
            services.AddHandlingHeadersMiddlewareSetup();
            services.AddSwaggerSetup();

            DependencyInjectionRegister.RegisterServices(services);

            var testVault = Configuration.GetSection("ApplicationInsights:InstrumentationKey")?.Value;
            Console.WriteLine($"Get vault access is: {!string.IsNullOrWhiteSpace(testVault)}");

        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseCors("Development");
                }
                else
                {
                    app.UseCors("Production");
                    if (DebugMode.IsDebug)
                    {
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseGlobalExceptionHandlerMiddleware();
                    }
                    app.UseHsts();
                }

                app.UseRequestLocalization();
                app.UseHttpsRedirection();
                app.UseHandlingHeadersMiddleware();
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseConfigurationHealthChecks();

                app.UseStaticFiles();


                app.UseEndpoints(config =>
                {
                    config.MapDefaultControllerRoute();
                });

                app.UseSwaggerConfiguration(Configuration, provider);
            }
        }
    }
}