

namespace NUV.Comics.Infra.Data.Db2.Context
{
    public class Db2DbContext : DbContext
    {
        public readonly IConfigurationCustom Configuration;
        public readonly string ownerDB;

        /// <summary>
        /// Esse construtor é para ser utilizado apenas para geração de classes baseado
        /// no banco de dados, sou seja, apenas pelo "dotnet ef" ou pelas classes que
        /// criam view no banco de dados
        /// </summary>
        /// <param name="configuration"></param>
        public Db2DbContext(IConfigurationCustom configuration)
        {
            Configuration = configuration;

            ownerDB = Configuration.GetSectionValue("AppConfig:OwnerDB:Schema");
        }

        public Db2DbContext(DbContextOptions<Db2DbContext> options,
            IConfigurationCustom configuration)
            : base(options)
        {
            Configuration = configuration;

            ownerDB = Configuration.GetSectionValue("AppConfig:OwnerDB:Schema");
        }

        public virtual DbSet<Embalagem> Embalagens { get; set; }

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
                var schema = Configuration.GetSectionValue("AppConfig:OwnerDB:Schema");
                var cnn = Configuration.GetSectionValue("AppConfig:OwnerDB:Cnn");

                optionsBuilder.UseDb2(Configuration.GetConnectionString(cnn), p =>
                {
                    p.SetServerInfo(IBMDBServerType.OS390, IBMDBServerVersion.None);
                    p.UseRowNumberForPaging();
                })
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

                Console.WriteLine($"***** {nameof(Db2DbContext)} {schema} *****");
            }

            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProviderName(Database);

            modelBuilder.HasDefaultSchema(ownerDB);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Db2DbContext).Assembly,
                predicate: n => n.Namespace.EndsWith(nameof(Db2DbContext)));

            modelBuilder.IgnoreValueObject();

            modelBuilder.MappingPropertiesForgotten();

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var registries = SaveChanges(true);

                Debug.WriteLine($"SaveChanges executado com sucesso para {registries} registros, e {this.GetAggregatesChanges()} registros em entidades agregadas");

                return await Task.FromResult(registries);
            }
            catch (CustomException ex)
            {
                Debug.WriteLine($"O conteudo da Exception deve ser consultada no log da aplicação: {ex.Message} Inner: {ex?.InnerException?.Message}");
                throw;
            }
            catch (CustomDbUpdateException ex)
            {
                Debug.WriteLine($"{ex.Message}");

                foreach (var message in ex.CustomMessage())
                {
                    Debug.WriteLine($"{message.Key} {message.Value}");
                }
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"O conteudo da Exception deve ser consultada no log da aplicação: {ex.Message} Inner: {ex?.InnerException?.Message}");
                throw;
            }
        }
    }
}