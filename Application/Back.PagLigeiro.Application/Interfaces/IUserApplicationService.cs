using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.DTOs.Result;
using Back.PagLigeiro.Domain.Generics;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<ValidationReturn<LoginResult>> CreateAsync(UserCreateRequest _request);
        Task<LoginResult> LoginAsync(LoginRequest login);
    }
}