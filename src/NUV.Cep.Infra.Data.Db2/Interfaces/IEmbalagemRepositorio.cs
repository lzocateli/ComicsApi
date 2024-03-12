using NUV.Cep.Infra.Data.Db2.Commands;
using NUV.Cep.Infra.Data.Db2.DomainModel;
using Nuuvify.CommonPack.Extensions.Notificator;
using Nuuvify.CommonPack.UnitOfWork.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Db2.Interfaces
{
    public interface IEmbalagemRepositorio : IRepositoryReadOnly<Embalagem>
    {

        IList<NotificationR> ValidationResult();
    }
}