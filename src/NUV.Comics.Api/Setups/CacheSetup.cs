namespace CBL.Startup.Custom.Setups
{
    public static class CacheSetup
    {
        public static void AddCacheSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("DadosCachePenf");

                options.SchemaName = configuration.GetSection("AppConfig:CacheExpire:Preco:schema")?.Value;
                options.TableName = configuration.GetSection("AppConfig:CacheExpire:Preco:tableName")?.Value;
            });
        }
    }
}