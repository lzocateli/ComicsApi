using AutoMapper;
using CBL.Common.Infra.Data.Repositories;
using NUV.Cep.Infra.Data.Db2.Commands;
using NUV.Cep.Infra.Data.Db2.Context;
using NUV.Cep.Infra.Data.Db2.DomainModel;
using NUV.Cep.Infra.Data.Db2.Interfaces;
using Microsoft.EntityFrameworkCore;
using Nuuvify.CommonPack.Extensions.Notificator;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Db2.Repositories
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