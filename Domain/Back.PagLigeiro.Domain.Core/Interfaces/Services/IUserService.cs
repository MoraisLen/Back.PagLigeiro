using Back.PagLigeiro.Domain.Model.User;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<UserModel>
    {
        new Task<bool> CreateAsync(UserModel user);
        Task<UserModel> Login(string email, string password);
    }
}