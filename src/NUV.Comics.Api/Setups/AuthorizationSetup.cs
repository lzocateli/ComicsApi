using Nuuvify.CommonPack.Security.JwtOpenId;

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
            public const string GroupUsers = "Comics-Users";
        }

        public static void AddNuvAuthorizationSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCblSecuritySetup(configuration);
            //https://credential.zocate.li/auth/realms/my-realm/.well-known/openid-configuration
            string KeycloakServerRealm = "https://credential.zocate.li/auth/realms/my-realm";
            string KeycloakClientId = "xxxxxxxxxxxxxxxxx";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = KeycloakServerRealm;
                o.Audience = KeycloakClientId;
                o.MetadataAddress = $"{KeycloakServerRealm}/.well-known/openid-configuration";
            });


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