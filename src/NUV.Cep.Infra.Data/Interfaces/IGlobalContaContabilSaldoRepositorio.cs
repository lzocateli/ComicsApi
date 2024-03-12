using NUV.Cep.Infra.Data.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUV.Cep.Infra.Data.Interfaces
{
    public interface IGlobalContaContabilSaldoRepositorio
    {
        Task<IEnumerable<GlsSaldoContaCommandResult>> ObterSaldoDaConta(GlsSaldoContaParametro parametro);

        Task<IEnumerable<GlsSaldoContaCommandResult>> ObterSaldoDaContaProfitCenter(GlsSaldoContaProfitCenterParametro parametro);

        Task<IEnumerable<GlsSaldoContaCommandResult>> ObterSaldoDaContaProfitCenterEmHoras(GlsSaldoContaProfitCenterEmHorasParametro parametro);

        Task<IEnumerable<GlsHorasTrabalhadaCommandResult>> ObterHorasTrabalhada(GlsObterHorasTrabalhadaParametro parametro);

        Task<IEnumerable<GlsHorasCongeladasCommandResult>> ObterHorasCongeladas(GlsObterHorasCongeladasParametro parametro);
    }
}