
namespace NUV.Comics.Infra.Data.Repositories
{
    public abstract class GlobalContaContabilBaseRepositorio : BaseRepositoryReadOnly<object>
    {
        protected GlobalContaContabilBaseRepositorio(Db2DbContext dbContext,
            IMapper mapper)
            : base(dbContext, mapper)
        {
            ownerDB = dbContext.ownerDB;
            var cnn = dbContext.Configuration.GetSectionValue("AppConfig:OwnerDB:Cnn");
            SetDbConnection(dbContext?.Database.GetDbConnection(), dbContext.Configuration.GetConnectionString(cnn));
        }
    }
}