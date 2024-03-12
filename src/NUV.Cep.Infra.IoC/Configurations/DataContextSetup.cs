using NUV.Cep.Infra.Data.Context;
using NUV.Cep.Infra.Data.Db2.Context;
using IBM.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuuvify.CommonPack.UnitOfWork;
using System;

namespace CBL.Startup.Custom.Setups
{
    public static class DataContextSetup
    {
        public static void AddDbContextPoolSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                var schema = configuration.GetSection("AppConfig:OwnerDB:Schema")?.Value;
                var cnn = configuration.GetSection("AppConfig:OwnerDB:Cnn")?.Value;

                options.UseDb2(configuration.GetConnectionString(cnn), p =>
                    {
                        p.SetServerInfo(IBMDBServerType.OS390, IBMDBServerVersion.None);
                        p.UseRowNumberForPaging();
                    })
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                Console.WriteLine($"***** {nameof(AppDbContext)} {schema} *****");
            });

            services.AddScoped<AppDbContext>();
            services.AddUnitOfWork<AppDbContext>();

            services.AddDbContextPool<AppDbContextZ1P2>(options =>
            {
                var schema = configuration.GetSection("AppConfig:OwnerDB-FW:Schema")?.Value;
                var cnn = configuration.GetSection("AppConfig:OwnerDB-FW:Cnn")?.Value;

                options.UseDb2(configuration.GetConnectionString(cnn), p =>
                    {
                        p.SetServerInfo(IBMDBServerType.OS390, IBMDBServerVersion.None);
                        p.UseRowNumberForPaging();
                    })
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                Console.WriteLine($"***** {nameof(AppDbContextZ1P2)} {schema} *****");
            });

            services.AddScoped<AppDbContextZ1P2>();
            services.AddUnitOfWork<AppDbContextZ1P2>();
        }
    }
}