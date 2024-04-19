using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Model.User;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Infraestructure.Data.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        private readonly SqlContext _sqlContext;

        public UserRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<UserModel> GetUserByEmailAndPassword(string email, string password)
        {
            return await _sqlContext.Set<UserModel>()
                .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                .FirstOrDefaultAsync();
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _sqlContext.Set<UserModel>()
                .Where(x => x.Email.Equals(email))
                .FirstOrDefaultAsync();
        }
    }
}