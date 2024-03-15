

namespace NUV.Comics.Api.Controllers
{
    // [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/[controller]")]
    public class GlobalSerialNumberPrefixController : BaseController
    {

        public GlobalSerialNumberPrefixController(
            ILogger<GlobalSerialNumberPrefixController> logger)
            : base(logger)
        {

        }

        /// <summary>
        /// Obtem o family code (EDS_PROD_FAM_CD) da tabela serial number prefix (Z1FS001$.SER_NO_PFX_MDL_REF)
        /// </summary>
        /// <remarks>
        /// Desenvolvida para ser utilizada pelo Mais API
        /// </remarks>
        /// /// <param name="serialNumberPrefix">Prefixo do Numero de Série</param>
        /// <returns></returns>
        [Produces("application/json")]
        // [SwaggerResponse(200, type: typeof(ReturnStandardSuccess<object>), description: "Codigo da Familia do Serial Number Prefix")]
        // [SwaggerResponse(204, description: "Codigo de retorno quando o metodo processou a solicitação do client, mas o retorno é nulo")]
        // [SwaggerResponse(422, type: typeof(IEnumerable<ReturnStandardErrors<NotificationR>>), description: "Codigo de retorno quando o metodo processou a solicitação do client, com notificações")]
        // [SwaggerResponse(417, type: typeof(IEnumerable<ReturnStandardErrorsModelState>), description: "Codigo de retorno para erro nos dados enviados pelo client")]
        // [SwaggerResponse(500, type: typeof(ReturnStandardErrors<NotificationR>), description: "Houve uma exceção que foi tratada pela aplicação e registrada em log")]
        // [HttpGet, MapToApiVersion("1.0")]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("serialNumberPrefix")]
        public async Task<IActionResult> FamilyCodeByMachineSerialNumber(
            [FromQuery] string serialNumberPrefix)
        {
            // var familyCode = await _serialNumerPrefixRepositorio.FamilyCodeByMachineSerialNumber(serialNumberPrefix);

            object resultAction = null;

            return await Response(new StatusCodeResult(StatusCodes.Status200OK),
                new StatusCodeResult(StatusCodes.Status422UnprocessableEntity),
                resultAction,
                null);
        }
    }
}
