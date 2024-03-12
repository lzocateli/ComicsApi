﻿using CBL.Common.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuuvify.CommonPack.StandardHttpClient;
using System.Net;

namespace NUV.Cep.Infra.IoC.Configurations
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