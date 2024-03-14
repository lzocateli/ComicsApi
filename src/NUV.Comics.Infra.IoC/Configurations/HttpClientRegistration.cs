
using CBL.Common.IoC;

namespace NUV.Comics.Infra.IoC.Configurations
{
    public static class HttpClientRegistration
    {
        public static void AddNuvHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceCredentialRegister(configuration)
                .ConfigurePrimaryHttpMessageHandler(() => new MyHttpClientHandler(WebRequest.DefaultWebProxy).MyClientHandler);
        }
    }
}