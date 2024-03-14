
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
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
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