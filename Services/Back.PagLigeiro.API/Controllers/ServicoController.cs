using Back.PagLigeiro.Api.Controllers.Error.Model;
using Back.PagLigeiro.Api.Controllers.Request;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.Interfaces;
using Back.PagLigeiro.Domain.Generics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoApplicationService _servicoApplicationService;
        public ServicoController(IServicoApplicationService servicoApplicationService)
        {
            _servicoApplicationService = servicoApplicationService;
        }

        /// <summary>
        /// Criação do serviço.
        /// </summary>
        /// <param name="request">Dados do serviço.</param>
        /// <response code="200">Serviço criado com sucesso.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SimpleResponse<LoginResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> CreateAsync([FromBody] ServicoRequest request)
        {
            ValidationReturn<ServicoResult> result = await _servicoApplicationService.CreateAsync(request);

            return result.Success
                ? StatusCode(StatusCodes.Status200OK, new SimpleResponse<ServicoResult>(true, result.Data))
                : StatusCode(StatusCodes.Status400BadRequest, new ErrorResponse(result.Errors));
        }
    }
}
