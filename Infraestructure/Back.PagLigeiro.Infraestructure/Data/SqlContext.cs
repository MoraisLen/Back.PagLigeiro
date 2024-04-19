using Back.PagLigeiro.Domain.Model.User;
using Microsoft.EntityFrameworkCore;

namespace Back.PagLigeiro.Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}