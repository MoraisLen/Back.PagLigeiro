using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.User;
using Back.PagLigeiro.Util.Security;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Services
{
    public class UserService : BaseService<UserModel>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IClienteRepository _crepository;
        private readonly IMapper _map;

        public UserService
        (
            IConfiguration configuraton,
            IUserRepository repositoryUser,
            IMapper map,
            IClienteRepository crepository) : base(repositoryUser)
        {
            _configuration = configuraton;
            _userRepository = repositoryUser;
            _map = map;
            _crepository = crepository;
        }

        public async Task<UserModel> Login(string email, string password) => await _userRepository.GetUserByEmailAndPassword(email, CriptografiaHelper.Encriptar(_configuration, password));

        public new async Task<ValidationReturn<UserModel>> CreateAsync(UserModel user)
        {
            user.Password = CriptografiaHelper.Encriptar(_configuration, user.Password);
            List<FildErrorReturn> errors = await ValidationUser(user);

            if (errors.Count == 0)
            {
                await _userRepository.CreateAsync(user);

                if (!await _userRepository.CommitAsync())
                    errors.Add(new FildErrorReturn("Operação de gravação", "Ocorreu um erro no processo de gravação. Verifique os logs."));
            }

            return errors.Count > 0
                ? ValidationReturn<UserModel>.WithErrors(errors)
                : ValidationReturn<UserModel>.Ok(user);
        }

        public async Task Teste()
        { }

        #region Validação

        private async Task<List<FildErrorReturn>> ValidationUser(UserModel user)
        {
            List<FildErrorReturn> errors = new List<FildErrorReturn>();

            if (await _userRepository.GetUserByEmail(user.Email) != null)
                errors.Add(new FildErrorReturn("Email", "Email já existente na base."));

            return errors;
        }

        #endregion Validação
    }
}