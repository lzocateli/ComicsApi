
namespace NUV.Cep.Infra.Data.Sql.Context
{
    public class SqlDbContext : DbContext
    {
        public readonly IConfigurationCustom Configuration;
        public readonly string ownerDB;

        /// <summary>
        /// Esse construtor é para ser utilizado apenas para geração de classes baseado
        /// no banco de dados, sou seja, apenas pelo "dotnet ef" ou pelas classes que
        /// criam view no banco de dados
        /// </summary>
        /// <param name="configuration"></param>
        public SqlDbContext(IConfigurationCustom configuration)
        {
            Configuration = configuration;

            ownerDB = Configuration.GetSectionValue("AppConfig:OwnerDBSql:Schema");
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options,
            IConfigurationCustom configuration)
            : base(options)
        {
            Configuration = configuration;

            ownerDB = Configuration.GetSectionValue("AppConfig:OwnerDBSql:Schema");
        }

        //public virtual DbSet<NotificationDomain> DomainNotifications { get; set; }

        /// <summary>
        /// O usuario nessa connectionString deve ser um usuario de aplicação que possua
        /// direitos de criar/alterar objetos no banco, não sendo o mesmo usuario que a
        /// aplicação usa para acessar o banco em tempo de execução.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var cnn = Configuration.GetSectionValue("AppConfig:OwnerDBSql:Cnn");

                optionsBuilder.UseSqlServer(Configuration.GetConnectionString(cnn))
                    .UseLazyLoadingProxies()
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();

                Console.WriteLine($"***** {nameof(SqlDbContext)} {ownerDB} *****");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProviderName(Database);

            modelBuilder.HasDefaultSchema(ownerDB);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly,
                predicate: n => n.Namespace.EndsWith(nameof(SqlDbContext)));

            modelBuilder.IgnoreValueObject();

            modelBuilder.MappingPropertiesForgotten();

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var registries = await SaveChangesAsync(true, cancellationToken);

                Debug.WriteLine($"SaveChanges executado com sucesso para {registries} registros, e {this.GetAggregatesChanges()} registros em entidades agregadas");

                return await Task.FromResult(registries);
            }
            catch (DbUpdateException ex)
            {
                PropertyValues proposedValues;
                PropertyValues databaseValues;
                var columnName = string.Empty;

                var baseMessage = new StringBuilder()
                    .AppendLine($"Houve um erro em SaveChanges, verifique o log de erros: {ex.Message} inner: {ex?.InnerException?.Message}");

                foreach (var entry in ex.Entries)
                {
                    proposedValues = entry.CurrentValues;
                    databaseValues = entry.GetDatabaseValues();

                    foreach (var property in proposedValues.Properties)
                    {
                        columnName = property.GetColumnName();

                        baseMessage.AppendLine($"Proposed: {columnName} = {proposedValues[property]}");
                        if (!(databaseValues?[property] is null))
                        {
                            baseMessage.AppendLine($"DataBaseValue: {columnName} = {databaseValues?[property]}");
                        }
                    }
                }

                Debug.WriteLine($"{baseMessage}");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message} inner: {ex?.InnerException?.Message}");
                throw;
            }
        }
    }
}