using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Nuuvify.CommonPack.Middleware.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CBL.Startup.Custom.Setups
{
    public static class MvcSetup
    {
        public static void AddMvcSetup(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.Filters.Add(new ValidateModelStateCustomAttribute());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            })
            .AddViewLocalization()
            .AddDataAnnotationsLocalization();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}