using Back.PagLigeiro.Api.Controllers.Error.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Back.PagLigeiro.Api.Controllers.Error
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var iderro = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            Response.StatusCode = 500;
            return new ErrorResponse("", "", "Ocorreu um Erro ao processar sua solicitação...", Response.StatusCode, iderro);
        }
    }
}
