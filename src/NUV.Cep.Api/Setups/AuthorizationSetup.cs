using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuuvify.CommonPack.Security.Jwt;
using Nuuvify.CommonPack.Security.JwtOpenId;
using System.Collections.Generic;

namespace CBL.Startup.Custom.Setups
{
    public static class AuthorizationSetup
    {
        /// <summary>
        /// Crie quantas constantes precisar, pode usar qualquer nome/valor, use essas constantes
        /// no Authorize das suas controllers
        /// </summary>
        public static class PolicyGroupConstants
        {
            public const string GroupUsers = "Cep-Users";
        }

        public static void AddNuvAuthorizationSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCblSecuritySetup(configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());

                dynamic policyGroups = new PolicyGroupsApplication(configuration);
                foreach (KeyValuePair<string, string> item in policyGroups.PolicyGroups)
                {
                    options.AddPolicy(item.Value,
                        policy => policy.Requirements.Add(new ControllerOpenIdAuthorizationRequirement(item.Value)));
                }
            });
        }
    }
}