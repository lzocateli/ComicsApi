using NUV.Cep.Infra.IoC;
using NUV.Cep.Infra.IoC.Configurations;
using CBL.Startup.Custom.Setups;

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

            var testVault = Configuration.GetSection("ApplicationInsights:ConnectionString")?.Value;
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