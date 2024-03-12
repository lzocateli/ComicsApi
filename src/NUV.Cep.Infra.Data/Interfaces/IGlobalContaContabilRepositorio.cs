using NUV.Cep.Infra.Data.Commands;
using Nuuvify.CommonPack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalContaContabilRepositorio
    {
        Task<IEnumerable<GlobalContaContabilCommandResult>> ObterTodos(string empresa, DateTime ultimaAlteracao);

        Task<IEnumerable<GlobalContaContabilCommandResult>> ObterTodosPorObsData(string empresa, DateTime obsData, EnumSimNao recebeLancamento);

        Task<IEnumerable<GlobalContaContabilCommandResult>> ObterContaPorCodigo(string empresa, string conta, DateTime vigencia);

        Task<IEnumerable<GlobalContaDepartamentalCommandResult>> ObterContaDepartamentalPorCodigo(string empresa, string departamental, DateTime vigencia);

        Task<IEnumerable<GlobalContaDepartamentalSecaoCommandResult>> ObterContaDepartamentalSecaoPorCodigo(string empresa, string departamental, DateTime vigencia, string secao);

        Task<IEnumerable<GlobalContaDepartamentalSecaoCommandResult>> ObterTodasContaDepartamentalSecaoPara28eUN(int skip, int take);

        Task<GlobalTaxaCommandResult> ObterTaxaFechamento(string empresa, DateTime dataEff, string trnsltCd);
    }
}