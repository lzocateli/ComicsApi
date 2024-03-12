using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nuuvify.CommonPack.Extensions.Implementation;
using Nuuvify.CommonPack.Extensions.Notificator;
using Nuuvify.CommonPack.Middleware;
using Nuuvify.CommonPack.Middleware.Abstraction.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUV.Cep.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : BaseCustomController
    {
        protected readonly ILogger<BaseController> _logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected virtual new async Task<IActionResult> Response(
            StatusCodeResult codigoRetornoComSucesso,
            StatusCodeResult codigoRetornoComErro,
            object result,
            IEnumerable<NotificationR> notifications)
        {
            if (notifications.NotNullOrZero())
            {
                var tipoErro = notifications.FirstOrDefault(x =>
                    x.Property != null &&
                    x.Property.StartsWith("ApiExterna"));

                if (int.TryParse(tipoErro?.Message, out int codigoErro))
                {
                    codigoRetornoComErro = new StatusCodeResult(codigoErro);
                }

                var retornoPadronizado = StatusCode(codigoRetornoComErro.StatusCode,
                    new ReturnStandardErrors<NotificationR>
                    {
                        Success = false,
                        Errors = notifications
                    });

                return await Task.FromResult(retornoPadronizado);
            }
            else
            {
                var retornoPadronizado = StatusCode(StatusCodes.Status204NoContent, null);

                if (!IsNull(result))
                {
                    var tipo = StatusCodeProducesResponseTypeAction(codigoRetornoComSucesso);

                    var retornoComSucesso = GetInstanceResponse(tipo, result);

                    retornoPadronizado = StatusCode(codigoRetornoComSucesso.StatusCode, retornoComSucesso);
                }

                return await Task.FromResult(retornoPadronizado);
            }
        }
    }
}