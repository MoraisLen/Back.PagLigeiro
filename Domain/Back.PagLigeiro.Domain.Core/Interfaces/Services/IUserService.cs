using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.User;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<UserModel>
    {
        new Task<ValidationReturn<UserModel>> CreateAsync(UserModel user);
        Task<UserModel> Login(string email, string password);
    }
}