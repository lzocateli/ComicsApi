

namespace NUV.Comics.Api.Controllers
{
    // [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class GlobalContasContabeisController : BaseController
    {

        public GlobalContasContabeisController(
            ILogger<GlobalContasContabeisController> logger)
            : base(logger)
        {

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
        // [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<object>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        // [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        // [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        // [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        // [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        // [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("saldo-conta")]
        public async Task<IActionResult> ObterSaldoDaContaAsync([FromQuery] string empresa, string conta,
            int ano, string tipo, string versao, string somaInd, string fiscalCd, int skip = 0, int take = 100000)
        {
            // var parametro = new GlsSaldoContaParametro
            // {
            //     Ano = ano,
            //     Conta = conta,
            //     Empresa = empresa,
            //     FiscalCd = fiscalCd,
            //     SomaInd = somaInd,
            //     Tipo = tipo,
            //     Versao = versao,
            //     Skip = skip,
            //     Take = take
            // };

            // new ValidationConcernR<GlsSaldoContaParametro>(parametro)
            //     .AssertIsBetween(x => x.Ano, 1950, 2050)
            //     .AssertNotIsNullOrWhiteSpace(x => x.Empresa)
            //     .AssertNotIsNullOrWhiteSpace(x => x.FiscalCd)
            //     .AssertNotIsNullOrWhiteSpace(x => x.SomaInd)
            //     .AssertNotIsNullOrWhiteSpace(x => x.Tipo)
            //     .AssertNotIsNullOrWhiteSpace(x => x.Versao);

            // if (!parametro.IsValid())
            // {
            //     return await Response(new StatusCodeResult(StatusCodes.Status200OK),
            //          new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
            //          null,
            //          parametro.Notifications);
            // }

            // var resultAction = await _globalContaContabilSaldoRepositorio.ObterSaldoDaConta(parametro);
            object resultAction = null;

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultAction,
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
        // [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<IEnumerable<int>>), description: "Codigo de retorno quando o metodo processou a solicitação do client")]
        // [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        // [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        // [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        // [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        // [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("saldo-conta-profitcenter")]
        public async Task<IActionResult> ObterSaldoDaContaProfitCenterAsync([FromQuery] string empresa,
            string conta, int ano, string listaPrdVars, string ack_rcd_typ = "H", string ack_vers = "00",
            string sum_ack_ind = "D", string cal_fscl_cd = "C", string ccy_cd = "USD", string drill_dwn_ind = "Y",
            string pctr_lwr_tier_2 = "M%",
            int skip = 0, int take = 100000)
        {
            // var parametro = new GlsSaldoContaProfitCenterParametro
            // {
            //     Ano = ano,
            //     Conta = conta,
            //     Empresa = empresa,
            //     CAL_FSCL_CD = cal_fscl_cd,
            //     SUM_ACK_IND = sum_ack_ind,
            //     ACK_RCD_TYP = ack_rcd_typ,
            //     ACK_VERS = ack_vers,
            //     CCY_CD = ccy_cd,
            //     DRILL_DWN_IND = drill_dwn_ind,
            //     PCTR_LWR_TIER_2 = pctr_lwr_tier_2,
            //     PRD_VAR_CD = listaPrdVars,
            //     Skip = skip,
            //     Take = take
            // };

            // new ValidationConcernR<GlsSaldoContaProfitCenterParametro>(parametro)
            //     .AssertIsBetween(x => x.Ano, 1950, 2050)
            //     .AssertNotIsNullOrWhiteSpace(x => x.Empresa)
            //     .AssertNotIsNullOrWhiteSpace(x => x.CAL_FSCL_CD)
            //     .AssertNotIsNullOrWhiteSpace(x => x.SUM_ACK_IND)
            //     .AssertNotIsNullOrWhiteSpace(x => x.ACK_RCD_TYP)
            //     .AssertNotIsNullOrWhiteSpace(x => x.ACK_VERS)
            //     .AssertNotIsNullOrWhiteSpace(x => x.CCY_CD)
            //     .AssertNotIsNullOrWhiteSpace(x => x.DRILL_DWN_IND)
            //     .AssertNotIsNullOrWhiteSpace(x => x.PCTR_LWR_TIER_2)
            //     .AssertNotIsNullOrWhiteSpace(x => x.PRD_VAR_CD);

            // if (!parametro.IsValid())
            // {
            //     return await Response(new StatusCodeResult(StatusCodes.Status200OK),
            //          new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
            //          null,
            //          parametro.Notifications);
            // }

            // var resultado = await _globalContaContabilSaldoRepositorio.ObterSaldoDaContaProfitCenter(parametro);

            var resultAction = Enumerable.Empty<int>;


            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultAction,
                null);
        }


    }
}