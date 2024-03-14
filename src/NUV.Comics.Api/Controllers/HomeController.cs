namespace CBL.Cws.Api.v1.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [Route("")]
        public async Task<IActionResult> Index() => await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, @""));

        [Route("favicon.ico")]
        public async Task<IActionResult> Favicon() => await Task.FromResult(StatusCode(StatusCodes.Status200OK, @""));

        [Route("info")]
        public async Task<IActionResult> Info(
            [FromServices] IOptions<RequestConfiguration> _requestConfiguration)
        {
            var info = new
            {
                _requestConfiguration.Value.ApplicationVersion,
                _requestConfiguration.Value.BuildNumber,
                _requestConfiguration.Value.Environment,
                DataHora = DateTimeOffset.Now,
            };

            var result = new ReturnStandardSuccess<object>
            {
                Success = true,
                Data = info
            };

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpGet]
        [Authorize(Policy = PolicyGroupConstants.GroupUsers)]
        [Route("emailAdm")]
        public async Task<IActionResult> EmailAdmAsync([FromServices] IConfiguration configuration)
        {
            var destinatarios = configuration.GetSection("EmailConfig:EmailAdministradores")
                .GetChildren()?
                .Where(x => !string.IsNullOrWhiteSpace(x.Value))?
                .ToDictionary(x => x.Key, x => x.Value);

            var result = new ReturnStandardSuccess<IEnumerable<KeyValuePair<string, string>>>
            {
                Success = true,
                Data = destinatarios
            };

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }
    }
}