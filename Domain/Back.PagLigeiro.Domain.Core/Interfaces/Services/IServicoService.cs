using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.Servico;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Domain.Core.Interfaces.Services
{
    public interface IServicoService : IBaseService<ServicoModel>
    {
        Task<ValidationReturn<ServicoModel>> CreateAsync(ServicoModel servico);
    }
}