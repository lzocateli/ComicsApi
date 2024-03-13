using NUV.Cep.Infra.Data.Db2.Context;
using NUV.Cep.Infra.Data.Sql.Context;

namespace CBL.Startup.Custom.Setups
{
    public static class HealthChecksSetup
    {
        public static void AddHealthChecksSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecksCommonSetup(configuration);

            var hcConfiguration = configuration.GetSection(nameof(HealthCheckCustomConfiguration))
                                               .Get<HealthCheckCustomConfiguration>();
            if (hcConfiguration.IsValid())
            {
                services.AddHealthChecks()
                    .AddProcessAllocatedMemoryHealthCheck(
                        name: "memory-process",
                        maximumMegabytesAllocated: 500,
                        failureStatus: HealthStatus.Degraded,
                        tags: new[] { "memory" })
                    .AddPrivateMemoryHealthCheck(
                        name: "memory-private",
                        maximumMemoryBytes: 1073741824L,
                        failureStatus: HealthStatus.Degraded,
                        tags: new[] { "memory" })
                    .AddDbContextCheck<Db2DbContext>(
                        name: $"ef-{nameof(Db2DbContext)}",
                        customTestQuery: (context, CancellationToken) =>
                        {
                            var regs = context.Embalagens.AsNoTracking().Count();
                            return Task.FromResult(regs > 0);
                        },
                        failureStatus: HealthStatus.Degraded,
                        tags: new[] { "data", "db2" })
                    .AddDbContextCheck<SqlDbContext>(
                        name: $"ef-{nameof(SqlDbContext)}",
                        customTestQuery: (context, CancellationToken) =>
                        {
                            var vigenciaInicial = DateTime.Today;
                            var empresa = "28";
                            var vigenciaFinal = new DateTime(9999, 12, 31);

                            var regs = 1;
                            // var regs = context.ContasContabeis.AsNoTracking()
                            //     .Count(x => x.FAC_CD == empresa &&
                            //     (x.EFF_DT <= vigenciaInicial &&
                            //      x.OBS_DT >= vigenciaInicial ||
                            //      x.OBS_DT == vigenciaFinal));

                            return Task.FromResult(regs > 0);
                        },
                        failureStatus: HealthStatus.Degraded,
                        tags: new[] { "data", "db2" })
                    .AddSqlServer(
                        name: "sql-DadosCacheFw",
                        connectionString: configuration.GetConnectionString("DadosCacheFw"),
                        healthQuery: "SELECT 1;",
                        failureStatus: HealthStatus.Degraded,
                        tags: new[] { "data", "sqlserver" })
                    .AddApplicationInsightsPublisher(
                        connectionString: configuration.GetSection("ApplicationInsights:ConnectionString").Value,
                        saveDetailedReport: true);
            }
        }

        public static void UseConfigurationHealthChecks(this IApplicationBuilder app)
        {
            var hcOptions = app.ApplicationServices.GetService<IOptions<HealthCheckCustomConfiguration>>();

            if (hcOptions.Value.IsValid())
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHealthChecks("hc", new HealthCheckOptions()
                    {
                        Predicate = p => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });

                    endpoints.MapHealthChecksUI(options =>
                    {
                        options.UIPath = "/hc-ui";
                        options.ApiPath = "/hc-ui-api";
                        options.ResourcesPath = "/resources";
                        options.WebhookPath = "/webhooks";

                        options.UseRelativeApiPath = true;
                        options.UseRelativeResourcesPath = true;
                        options.UseRelativeWebhookPath = true;

                        options.AddCustomStylesheet("dotnet.css");
                    });
                });
            }
        }
    }
}