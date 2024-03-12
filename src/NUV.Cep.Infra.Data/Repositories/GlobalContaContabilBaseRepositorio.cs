using AutoMapper;
using CBL.Common.Infra.Data.Repositories;
using NUV.Cep.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace NUV.Cep.Infra.Data.Repositories
{
    public abstract class GlobalContaContabilBaseRepositorio : BaseRepositoryReadOnly<object>
    {
        protected GlobalContaContabilBaseRepositorio(AppDbContext dbContext,
            IMapper mapper)
            : base(dbContext, mapper)
        {
            ownerDB = dbContext.ownerDB;
            var cnn = dbContext.Configuration.GetSectionValue("AppConfig:OwnerDB:Cnn");
            SetDbConnection(dbContext?.Database.GetDbConnection(), dbContext.Configuration.GetConnectionString(cnn));
        }
    }
}