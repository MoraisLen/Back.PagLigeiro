using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Model.Servico;

namespace Back.PagLigeiro.Infraestructure.Data.Repository
{
    public class ServicoRepository : BaseRepository<ServicoModel>, IServicoRepository
    {
        private readonly SqlContext _sqlContext;

        public ServicoRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}