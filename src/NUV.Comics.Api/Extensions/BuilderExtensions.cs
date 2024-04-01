using NUV.Comics.Infra.IoC;

namespace Startup.Custom;


public static class BuilderExtensions
{

    public static void AddArchitectures(this WebApplicationBuilder builder)
    {

        builder.Services.AddApplicationInsightsTelemetry();
        builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>(
            (module, o) =>
            {
                module.EnableSqlCommandTextInstrumentation = true;
            }
        );

        builder.Services.AddLocalizationSetup();
        builder.Services.AddDbContextPoolSetup(builder.Configuration);

        builder.Services.AddCacheSetup(builder.Configuration);
        builder.Services.AddMvcSetup();
        builder.Services.AddCorsConfigurationSetup();
        builder.Services.AddCompressionSetup();
        builder.Services.AddApiVersioningSetup();
        builder.Services.AddNuvAuthorizationSetup(builder.Configuration);

        builder.Services.AddStandardHttpClientSetup(builder.Configuration, false);
        builder.Services.AddStandardWebServiceSetup();
        builder.Services.AddHealthChecksSetup(builder.Configuration);
        builder.Services.AddNuvHttpClient(builder.Configuration);

        builder.Services.AddEmailSetup(builder.Configuration);
        builder.Services.AddGlobalHandlerExceptionSetup();
        builder.Services.AddHandlingHeadersMiddlewareSetup();
        builder.Services.AddSwaggerSetup();

        DependencyInjectionRegister.RegisterServices(builder.Services);



    }


}
