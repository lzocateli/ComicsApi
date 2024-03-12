using NUV.Cep.Infra.Data.Commands;
using Nuuvify.CommonPack.UnitOfWork.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalAtivosRepositorio : IRepositoryReadOnly<object>
    {
        Task<IEnumerable<GlobalAtivosCWOCommandResult>> ObterTodos();
    }
}