using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Domain.Generics;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Application.Interfaces
{
    public interface IServicoApplicationService
    {
        Task<ValidationReturn<ServicoResult>> CreateAsync(ServicoRequest request);
    }
}