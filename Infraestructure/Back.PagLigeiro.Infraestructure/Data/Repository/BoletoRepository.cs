using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Model.Boleto;

namespace Back.PagLigeiro.Infraestructure.Data.Repository
{
    public class BoletoRepository : BaseRepository<BoletoModel>, IBoletoRepository
    {
        private readonly SqlContext _sqlContext;

        public BoletoRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}