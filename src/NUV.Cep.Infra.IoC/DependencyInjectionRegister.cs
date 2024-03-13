using NUV.Cep.Infra.Data.Db2.Interfaces;
using NUV.Cep.Infra.Data.Db2.Repositories;

namespace NUV.Cep.Infra.IoC
{
    public static class DependencyInjectionRegister
    {
        /// <summary>
        /// Singleton: Cria uma única instância em toda a aplicação. Ele cria a instância pela primeira vez e reutiliza o mesmo objeto em todas as requests.
        /// Scoped: Cria uma instancia apenas por request.
        /// Transient: Criado uma instancia cada vez que o objeto é instanciado.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("NUV.Cep.Infra.IoC"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("NUV.Cep.Infra.IoC")));


            // services.AddScoped<IGlobalCentroDeCustoRepositorio, GlobalCentroDeCustoRepositorio>();
            services.AddScoped<IEmbalagemRepositorio, EmbalagemRepositorio>();

            services.AddScoped<IConfigurationCustom, ConfigurationCustom>();
        }
    }
}