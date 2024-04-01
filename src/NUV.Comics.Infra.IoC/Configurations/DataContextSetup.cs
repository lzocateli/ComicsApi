

namespace Startup.Custom
{
    public static class DataContextSetup
    {
        public static void AddDbContextPoolSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<Db2DbContext>(options =>
            {
                var schema = configuration.GetSection("AppConfig:OwnerDB:Schema")?.Value;
                var cnn = configuration.GetSection("AppConfig:OwnerDB:Cnn")?.Value;

                Console.WriteLine($"***** Configuring {nameof(Db2DbContext)} {schema} *****");

                options.UseDb2(configuration.GetConnectionString(cnn), p =>
                    {
                        p.SetServerInfo(IBMDBServerType.OS390, IBMDBServerVersion.None);
                        p.UseRowNumberForPaging();
                    })
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                Console.WriteLine($"***** Configured {nameof(Db2DbContext)} {schema} *****");
            });

            services.AddScoped<Db2DbContext>();
            services.AddUnitOfWork<Db2DbContext>();


            services.AddDbContextPool<SqlDbContext>(options =>
            {
                var schema = configuration.GetSection("AppConfig:OwnerDB:Schema")?.Value;
                var cnn = configuration.GetSection("AppConfig:OwnerDB:Cnn")?.Value;

                options.UseSqlServer(configuration.GetConnectionString(cnn))
                       .UseLazyLoadingProxies()
                       .EnableDetailedErrors()
                       .EnableSensitiveDataLogging();

                Console.WriteLine($"***** {nameof(SqlDbContext)} {schema} *****");
            });

            services.AddScoped<SqlDbContext>();
            services.AddUnitOfWork<SqlDbContext>();

        }
    }
}