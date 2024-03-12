using NUV.Cep.Infra.Data.Commands;
using NUV.Cep.Infra.Data.DomainModel;
using Nuuvify.CommonPack.Domain.ValueObjects;
using Nuuvify.CommonPack.UnitOfWork.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalCentroDeCustoRepositorio : IRepositoryReadOnly<GlobalCentroDeCusto>
    {
        Task<IPagedList<GlobalCentroDeCustoQueryResult>> ObterTodos(GlobalCentroDeCustoPorEmpresaInputQuery parameter);

        Task<IEnumerable<GlobalCentroDeCustoQueryResult>> ObterUltimaAlteracao(string empresa, DateTime ultimaAlteracao, SkipTake skipTake);

        Task<IEnumerable<GlobalCentroDeCustoQueryResult>> ObterContaPorCodigo(string empresa, string centroCusto, DateTime vigencia);

        Task<IEnumerable<GlobalCentroDeCustoQueryResult>> ObterContaPorSecao(string empresa, string centroCusto);

        Task<IEnumerable<GlobalCentroDeCustoFacilityQueryResult>> ObterPorCodigoFacility(GlobalCentroDeCustoFacilityInputQuery parameter);
    }
}