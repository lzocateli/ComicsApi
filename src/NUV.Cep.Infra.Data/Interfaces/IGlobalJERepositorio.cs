using NUV.Cep.Infra.Data.Commands;
using Nuuvify.CommonPack.UnitOfWork.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalJERepositorio : IRepositoryReadOnly<object>
    {
        Task<IEnumerable<GlobalJECommandResult>> ObterLDPorCodigo(string empresa, string CodigoLD, DateTime vigencia);

        Task<IEnumerable<GlobalJEContabilizacaoCommandResult>> ObterContabilizacaoPorValor(string empresa, string LD, double valor_DEBITO, int mes, int ano);
    }
}