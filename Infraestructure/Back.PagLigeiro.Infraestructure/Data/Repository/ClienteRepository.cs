using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Model.Cliente;

namespace Back.PagLigeiro.Infraestructure.Data.Repository
{
    public class ClienteRepository : BaseRepository<ClienteModel>, IClienteRepository
    {
        private readonly SqlContext _sqlContext;

        public ClienteRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}