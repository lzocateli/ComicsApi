using Microsoft.Extensions.DependencyInjection;

namespace CBL.Startup.Custom.Setups
{
    public static class ApiVersioningSetup
    {
        public static void AddApiVersioningSetup(this IServiceCollection services)
        {
            // services.AddVersionedApiExplorer(options =>
            // {
            //     options.GroupNameFormat = "'v'VVV";
            //     options.SubstituteApiVersionInUrl = true;
            // });
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });
        }
    }
}