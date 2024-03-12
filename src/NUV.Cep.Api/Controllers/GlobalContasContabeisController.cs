using NUV.Cep.Infra.Data.Commands;
using NUV.Cep.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nuuvify.CommonPack.Domain;
using Nuuvify.CommonPack.Domain.ValueObjects;
using Nuuvify.CommonPack.Extensions.Notificator;
using Nuuvify.CommonPack.Middleware.Abstraction.Results;
using Nuuvify.CommonPack.Middleware.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CBL.Startup.Custom.Setups.AuthorizationSetup;

namespace NUV.Cep.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class GlobalContasContabeisController : BaseController
    {
        private readonly IGlobalContaContabilRepositorio _globalContaContabilRepositorio;
        private readonly IGlobalContaContabilSaldoRepositorio _globalContaContabilSaldoRepositorio;

        public GlobalContasContabeisController(IGlobalContaContabilRepositorio globalContaContabilRepositorio,
                                               IGlobalContaContabilSaldoRepositorio globalContaContabilSaldoRepositorio,
            ILogger<GlobalContasContabeisController> logger)
            : base(logger)
        {
            _globalContaContabilRepositorio = globalContaContabilRepositorio;
            _globalContaContabilSaldoRepositorio = globalContaContabilSaldoRepositorio;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="ultimaAlteracao"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaContabilCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("ultimaAlteracao/{empresa}/{ultimaAlteracao}")]
        public async Task<IActionResult> ObterUltimaAlteracaoAsync([FromRoute] string empresa, DateTime ultimaAlteracao)
        {
            var resultado = await _globalContaContabilRepositorio.ObterTodos(empresa, ultimaAlteracao);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Obtem a lista de contas validas a partir da data informada (Obsolete Date)
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="obsData"></param>
        /// <param name="recebeLancamento"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaContabilCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("obsdata/{empresa}/{obsData}/{recebeLancamento}")]
        public async Task<IActionResult> ObterTodosPorObsDataAsync([FromRoute] string empresa, DateTime obsData, EnumSimNao recebeLancamento)
        {
            var resultado = await _globalContaContabilRepositorio.ObterTodosPorObsData(empresa, obsData, recebeLancamento);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="conta"></param>
        /// <param name="vigencia"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaContabilCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("conta/{empresa}/{conta}/{vigencia}")]
        public async Task<IActionResult> ObterContaAsync([FromRoute] string empresa, string conta, DateTime vigencia)
        {
            var resultado = await _globalContaContabilRepositorio.ObterContaPorCodigo(empresa, conta, vigencia);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="departamental"></param>
        /// <param name="vigencia"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaDepartamentalCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("departamental/{empresa}/{departamental}/{vigencia}")]
        public async Task<IActionResult> ObterContaDepartamentalAsync([FromRoute] string empresa, string departamental, DateTime vigencia)
        {
            var resultado = await _globalContaContabilRepositorio.ObterContaDepartamentalPorCodigo(empresa, departamental, vigencia);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="departamental"></param>
        /// <param name="secao"></param>
        /// <param name="vigencia"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaDepartamentalSecaoCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("departamentalsecao/{empresa}/{departamental}/{secao}/{vigencia}")]
        public async Task<IActionResult> ObterContaDepartamentalSecaoAsync([FromRoute] string empresa, string departamental, string secao, DateTime vigencia)
        {
            var resultado = await _globalContaContabilRepositorio.ObterContaDepartamentalSecaoPorCodigo(empresa, departamental, vigencia, secao);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorna uma lista com todas as contas departamentais e secao
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaDepartamentalSecaoCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("TodasContaDepartamentalSecaoPara28eUN/{skip}/{take}")]
        public async Task<IActionResult> ObterTodasContaDepartamentalSecaoPara28eUNAsync([FromRoute] int skip, int take)
        {
            var resultado = await _globalContaContabilRepositorio.ObterTodasContaDepartamentalSecaoPara28eUN(skip, take);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorna uma lista com todas as contas departamentais e secao para 28 e UN - Para uso com PowerBI
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlobalContaDepartamentalSecaoCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [ApiKey]
        [Route("TodasDepartamental/{skip}/{take}")]
        public async Task<IActionResult> ObterTodasContaDepartamentalSecaoPara28eUNPbiAsync([FromRoute] int skip, int take)
        {
            var resultado = await _globalContaContabilRepositorio.ObterTodasContaDepartamentalSecaoPara28eUN(skip, take);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="dataEff"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<GlobalTaxaCommandResult>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("taxa/{empresa}/{dataEff}/{codigo}")]
        public async Task<IActionResult> ObterTaxaAsync([FromRoute] string empresa, DateTime dataEff, string codigo)
        {
            var resultado = await _globalContaContabilRepositorio.ObterTaxaFechamento(empresa, dataEff, codigo);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorno o saldo da conta com os parametros indicados
        /// </summary>
        /// <param name="empresa">Codigo da Empresa</param>
        /// <param name="conta">Conta contabil deve ser informada desconsiderando zeros a direita
        /// <para>Exemplo: A0002001</para>
        /// </param>
        /// <param name="ano">Ano que necessita o saldo</param>
        /// <param name="tipo">Padrão = H</param>
        /// <param name="versao">Padrão = 00</param>
        /// <param name="somaInd">Padrão = D</param>
        /// <param name="fiscalCd">Padrão = C</param>
        /// <param name="skip">Quantidade de linhas para pular</param>
        /// <param name="take">Quantidade de linhas para retornar depois do pulo</param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlsSaldoContaCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("saldo-conta")]
        public async Task<IActionResult> ObterSaldoDaContaAsync([FromQuery] string empresa, string conta,
            int ano, string tipo, string versao, string somaInd, string fiscalCd, int skip = 0, int take = 100000)
        {
            var parametro = new GlsSaldoContaParametro
            {
                Ano = ano,
                Conta = conta,
                Empresa = empresa,
                FiscalCd = fiscalCd,
                SomaInd = somaInd,
                Tipo = tipo,
                Versao = versao,
                Skip = skip,
                Take = take
            };

            new ValidationConcernR<GlsSaldoContaParametro>(parametro)
                .AssertIsBetween(x => x.Ano, 1950, 2050)
                .AssertNotIsNullOrWhiteSpace(x => x.Empresa)
                .AssertNotIsNullOrWhiteSpace(x => x.FiscalCd)
                .AssertNotIsNullOrWhiteSpace(x => x.SomaInd)
                .AssertNotIsNullOrWhiteSpace(x => x.Tipo)
                .AssertNotIsNullOrWhiteSpace(x => x.Versao);

            if (!parametro.IsValid())
            {
                return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                     new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                     null,
                     parametro.Notifications);
            }

            var resultado = await _globalContaContabilSaldoRepositorio.ObterSaldoDaConta(parametro);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorno o saldo da conta com os parametros indicados
        /// </summary>
        /// <param name="empresa">Codigo da Empresa</param>
        /// <param name="conta">Conta contabil deve ser informada como esta na tabela
        /// <para>Exemplo: 2802</para>
        /// </param>
        /// <param name="ano">Ano que necessita o saldo</param>
        /// <param name="ack_rcd_typ">Padrão = H</param>
        /// <param name="ack_vers">Padrão = 00</param>
        /// <param name="sum_ack_ind">Padrão = D</param>
        /// <param name="cal_fscl_cd">Padrão = C</param>
        /// <param name="ccy_cd">Padrão = USD</param>
        /// <param name="listaPrdVars">Pardão 05 (valor unico), ou lista '05','06','07' (com aspas simples)</param>
        /// <param name="drill_dwn_ind">Padrão = Y</param>
        /// <param name="pctr_lwr_tier_2">Padroão = M% (se possuir % sera like caso contrario a consulta é normal)</param>
        /// <param name="skip">Quantidade de linhas para pular</param>
        /// <param name="take">Quantidade de linhas para retornar depois do pulo</param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlsSaldoContaCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("saldo-conta-profitcenter")]
        public async Task<IActionResult> ObterSaldoDaContaProfitCenterAsync([FromQuery] string empresa,
            string conta, int ano, string listaPrdVars, string ack_rcd_typ = "H", string ack_vers = "00",
            string sum_ack_ind = "D", string cal_fscl_cd = "C", string ccy_cd = "USD", string drill_dwn_ind = "Y",
            string pctr_lwr_tier_2 = "M%",
            int skip = 0, int take = 100000)
        {
            var parametro = new GlsSaldoContaProfitCenterParametro
            {
                Ano = ano,
                Conta = conta,
                Empresa = empresa,
                CAL_FSCL_CD = cal_fscl_cd,
                SUM_ACK_IND = sum_ack_ind,
                ACK_RCD_TYP = ack_rcd_typ,
                ACK_VERS = ack_vers,
                CCY_CD = ccy_cd,
                DRILL_DWN_IND = drill_dwn_ind,
                PCTR_LWR_TIER_2 = pctr_lwr_tier_2,
                PRD_VAR_CD = listaPrdVars,
                Skip = skip,
                Take = take
            };

            new ValidationConcernR<GlsSaldoContaProfitCenterParametro>(parametro)
                .AssertIsBetween(x => x.Ano, 1950, 2050)
                .AssertNotIsNullOrWhiteSpace(x => x.Empresa)
                .AssertNotIsNullOrWhiteSpace(x => x.CAL_FSCL_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.SUM_ACK_IND)
                .AssertNotIsNullOrWhiteSpace(x => x.ACK_RCD_TYP)
                .AssertNotIsNullOrWhiteSpace(x => x.ACK_VERS)
                .AssertNotIsNullOrWhiteSpace(x => x.CCY_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.DRILL_DWN_IND)
                .AssertNotIsNullOrWhiteSpace(x => x.PCTR_LWR_TIER_2)
                .AssertNotIsNullOrWhiteSpace(x => x.PRD_VAR_CD);

            if (!parametro.IsValid())
            {
                return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                     new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                     null,
                     parametro.Notifications);
            }

            var resultado = await _globalContaContabilSaldoRepositorio.ObterSaldoDaContaProfitCenter(parametro);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorno o saldo em horas com os parametros indicados
        /// </summary>
        /// <param name="fac_cd">Codigo da Empresa, Exemplo: RK</param>
        /// <param name="cal_yr">Ano que necessita o saldo</param>
        /// <param name="new_fncl_acct_no">Padrão = W010%</param>
        /// <param name="bdgt_src_cd">Padrão = HRS</param>
        /// <param name="skip">Quantidade de linhas para pular</param>
        /// <param name="take">Quantidade de linhas para retornar depois do pulo</param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlsSaldoContaCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("saldo-conta-profitcenter-horas")]
        public async Task<IActionResult> ObterSaldoDaContaProfitCenterEmHorasAsync([FromQuery] string fac_cd,
            int cal_yr, string new_fncl_acct_no = "W010%", string bdgt_src_cd = "HRS",
            int skip = 0, int take = 100000)
        {
            var parametro = new GlsSaldoContaProfitCenterEmHorasParametro
            {
                FAC_CD = fac_cd,
                CAL_YR = cal_yr,
                NEW_FNCL_ACCT_NO = new_fncl_acct_no,
                BDGT_SRC_CD = bdgt_src_cd,
                Skip = skip,
                Take = take
            };

            new ValidationConcernR<GlsSaldoContaProfitCenterEmHorasParametro>(parametro)
                .AssertIsBetween(x => x.CAL_YR, 1950, 2050)
                .AssertNotIsNullOrWhiteSpace(x => x.FAC_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.NEW_FNCL_ACCT_NO)
                .AssertNotIsNullOrWhiteSpace(x => x.BDGT_SRC_CD);

            if (!parametro.IsValid())
            {
                return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                     new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                     null,
                     parametro.Notifications);
            }

            var resultado = await _globalContaContabilSaldoRepositorio.ObterSaldoDaContaProfitCenterEmHoras(parametro);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorna as horas trabalhadas
        /// </summary>
        /// <param name="fac_cd">Codigo da Empresa [28, UN]</param>
        /// <param name="cal_yr">Ano</param>
        /// <param name="cal_fscl_cd">Padrão = C</param>
        /// <param name="ack_vers">Padrão = 00</param>
        /// <param name="bdgt_src_cd">Padrão = HRS</param>
        /// <param name="fncl_org_cd">Padrão = 0% ou 0 ou lista '0123','3456'</param>
        /// <param name="new_fncl_acct_no">Padrão = 00%</param>
        /// <param name="pctr_fac_cd">Padrão = RK</param>
        /// <param name="skip">Quantidade de linhas para pular</param>
        /// <param name="take">Quantidade de linhas para retornar depois do pulo</param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlsHorasTrabalhadaCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("horas-trabalhada")]
        public async Task<IActionResult> ObterHorasTrabalhadaAsync([FromQuery] string fac_cd,
            int cal_yr, string cal_fscl_cd = "C", string ack_vers = "00", string bdgt_src_cd = "HRS",
            string fncl_org_cd = "0%", string new_fncl_acct_no = "00%", string pctr_fac_cd = "RK",
            int skip = 0, int take = 100)
        {
            var parametro = new GlsObterHorasTrabalhadaParametro
            {
                FAC_CD = fac_cd,
                CAL_YR = cal_yr,
                CAL_FSCL_CD = cal_fscl_cd,
                ACK_VERS = ack_vers,
                BDGT_SRC_CD = bdgt_src_cd,
                FNCL_ORG_CD = fncl_org_cd,
                NEW_FNCL_ACCT_NO = new_fncl_acct_no,
                PCTR_FAC_CD = pctr_fac_cd,
                Skip = skip,
                Take = take
            };

            new ValidationConcernR<GlsObterHorasTrabalhadaParametro>(parametro)
                .AssertIsBetween(x => x.CAL_YR, 1950, 2050)
                .AssertNotIsNullOrWhiteSpace(x => x.FAC_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.CAL_FSCL_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.BDGT_SRC_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.FNCL_ORG_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.ACK_VERS)
                .AssertNotIsNullOrWhiteSpace(x => x.NEW_FNCL_ACCT_NO)
                .AssertNotIsNullOrWhiteSpace(x => x.PCTR_FAC_CD);

            if (!parametro.IsValid())
            {
                return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                     new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                     null,
                     parametro.Notifications);
            }

            var resultado = await _globalContaContabilSaldoRepositorio.ObterHorasTrabalhada(parametro);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }

        /// <summary>
        /// Retorna as horas trabalhadas
        /// </summary>
        /// <param name="fac_cd">Codigo da Empresa [28, UN]</param>
        /// <param name="cal_yr">Ano</param>
        /// <param name="bdgt_src_cd">Padrão = HRS</param>
        /// <param name="new_fncl_acct_no">Padrão = Z916%</param>
        /// <param name="pctr_lwr_tier_2">pode ser = MMM% ou MMM ou lista 'MNO','WXYZ'</param>
        /// <param name="skip">Quantidade de linhas para pular</param>
        /// <param name="take">Quantidade de linhas para retornar depois do pulo</param>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<GlsHorasCongeladasCommandResult>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("horas-congeladas")]
        public async Task<IActionResult> ObterHorasCongeladasAsync([FromQuery] string fac_cd,
            int cal_yr, string bdgt_src_cd = "HRS", string new_fncl_acct_no = "Z916%",
            string pctr_lwr_tier_2 = "M%",
            int skip = 0, int take = 100)
        {
            var parametro = new GlsObterHorasCongeladasParametro
            {
                FAC_CD = fac_cd,
                CAL_YR = cal_yr,
                BDGT_SRC_CD = bdgt_src_cd,
                NEW_FNCL_ACCT_NO = new_fncl_acct_no,
                PCTR_LWR_TIER_2 = pctr_lwr_tier_2,
                Skip = skip,
                Take = take
            };

            new ValidationConcernR<GlsObterHorasCongeladasParametro>(parametro)
                .AssertIsBetween(x => x.CAL_YR, 1950, 2050)
                .AssertNotIsNullOrWhiteSpace(x => x.FAC_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.BDGT_SRC_CD)
                .AssertNotIsNullOrWhiteSpace(x => x.NEW_FNCL_ACCT_NO)
                .AssertNotIsNullOrWhiteSpace(x => x.PCTR_LWR_TIER_2);

            if (!parametro.IsValid())
            {
                return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                     new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                     null,
                     parametro.Notifications);
            }

            var resultado = await _globalContaContabilSaldoRepositorio.ObterHorasCongeladas(parametro);

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultado,
                null);
        }
    }
}