using AutoMapper;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.DTOs.Result;
using Back.PagLigeiro.Application.Interfaces;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Generics;
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

        public async Task<LoginResult> LoginAsync(LoginRequest login)
        {
            UserModel userResult = await _service.Login(login.Email, login.Password);

            if (userResult != null)
                return await Access(userResult);

            return null;
        }

        public async Task<ValidationReturn<LoginResult>> CreateAsync(UserCreateRequest _request)
        {
            UserModel user = _map.Map<UserModel>(_request);
            ValidationReturn<UserModel> ret = await _service.CreateAsync(user);

            return ret.Success
                ? new ValidationReturn<LoginResult>(data: await Access(user))
                : new ValidationReturn<LoginResult>(errors: ret.Errors);
        }

        private async Task<LoginResult> Access(UserModel user)
        {
            UserResult userMap = _map.Map<UserResult>(user);
            string token = JWTHelper.getToken(_configuration, user.Email, (int)user.Role);

            return new LoginResult(token, userMap);
        }
    }
}