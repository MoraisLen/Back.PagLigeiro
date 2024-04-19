using Back.PagLigeiro.Domain.Model.User;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> GetUserByEmailAndPassword(string email, string password);
    }
}
