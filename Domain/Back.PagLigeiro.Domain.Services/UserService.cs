using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Model.User;
using Back.PagLigeiro.Util.Security;
using Back.PagLigeiro.Util.Validation.Error;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Services
{
    public class UserService : BaseService<UserModel>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _map;

        public UserService
        (
            IConfiguration configuraton,
            IUserRepository repositoryUser,
            IMapper map
        ) : base(repositoryUser)
        {
            _configuration = configuraton;
            _userRepository = repositoryUser;
            _map = map;
        }

        public async Task<UserModel> Login(string email, string password)
            => await _userRepository.GetUserByEmailAndPassword(email, CriptografiaHelper.Encriptar(_configuration, password));

        public new async Task<bool> CreateAsync(UserModel user)
        {
            user.Password = CriptografiaHelper.Encriptar(_configuration, user.Password);

            if (await ValidationUser(user))
                return await _userRepository.CreateAsync(user);

            return false;
        }

        private async Task<bool> ValidationUser(UserModel user)
        {
            if (await _userRepository.GetUserByEmail(user.Email) != null)
                throw ErrorValidation.getError("Email", "Email já cadastrado.");

            return true;
        }
    }
}