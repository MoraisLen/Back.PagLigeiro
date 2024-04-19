using Back.PagLigeiro.Api.Controllers.Error.Model;
using Back.PagLigeiro.Api.Controllers.Request;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.DTOs.Result;
using Back.PagLigeiro.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public class AuthController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        public AuthController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        /// <summary>
        /// Autenticação via credênciais de acesso.
        /// </summary>
        /// <param name="request">Credênciais de acesso.</param>
        /// <response code="200">Sessão inicializada com sucesso.</response>
        /// <response code="401">Acesso não realizado. Verifique as credênciais.</response>
        /// <response code="400">Falha no servidor. Tente novamente mais tarde.</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SimpleResponse<LoginResult>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> LoginAsync([FromBody]LoginRequest request)
        {
            try
            {
                LoginResult result = await _userApplicationService.LoginAsync(request);

                return result == null
                    ? StatusCode(StatusCodes.Status401Unauthorized)
                    : StatusCode(StatusCodes.Status200OK, new SimpleResponse<LoginResult>(true, result));
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
