

namespace NUV.Comics.Infra.Data.Db2.Repositories
{
    public class EmbalagemRepositorio : BaseRepositoryReadOnly<Embalagem>, IEmbalagemRepositorio
    {
        public EmbalagemRepositorio(
            Db2DbContext dbContext,
            IMapper mapper)
            : base(dbContext, mapper)
        {
            ownerDB = dbContext.ownerDB;
            var cnn = dbContext.Configuration.GetSectionValue("AppConfig:OwnerDB:Cnn");
            SetDbConnection(dbContext?.Database.GetDbConnection(), dbContext.Configuration.GetConnectionString(cnn));
        }


    }
}