using AutoMapper;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.DTOs.Result;
using Back.PagLigeiro.Application.Interfaces;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.Cliente;
using Back.PagLigeiro.Domain.Model.User;
using Back.PagLigeiro.Util.Security;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Application
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IMapper _map;
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public UserApplicationService(IMapper map, IUserService service, IConfiguration configuration)
        {
            _map = map;
            _service = service;
            _configuration = configuration;
        }

        public async Task<ValidationReturn<LoginResult>> LoginAsync(LoginRequest login)
        {
            UserModel userResult = await _service.Login(login.Email, login.Password);

            return userResult != null
                ? ValidationReturn<LoginResult>.Ok(await Access(userResult))
                : ValidationReturn<LoginResult>.WithErrors();
        }

        public async Task<ValidationReturn<LoginResult>> CreateAsync(UserCreateRequest request)
        {
            UserModel user = _map.Map<UserModel>(request);
            ValidationReturn<UserModel> ret = await _service.CreateAsync(user);

            return ret.Success
                ? ValidationReturn<LoginResult>.Ok(await Access(user))
                : ValidationReturn<LoginResult>.WithErrors(ret.Errors);
        }

        private async Task<LoginResult> Access(UserModel user)
        {
            UserResult userMap = _map.Map<UserResult>(user);
            string token = JWTHelper.getToken(_configuration, user.Email, (int)user.Role);

            return new LoginResult(token, userMap);
        }

        public async Task TesteAsync()
        {
            await _service.Teste();

        }
    }
}