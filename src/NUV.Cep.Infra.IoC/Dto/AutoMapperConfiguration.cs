
namespace NUV.Cep.Infra.IoC.Dto
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(ps =>
                {
                    ps.AddProfile(new CentroDeCustoProfile());
                });

            return config;
        }
    }
}