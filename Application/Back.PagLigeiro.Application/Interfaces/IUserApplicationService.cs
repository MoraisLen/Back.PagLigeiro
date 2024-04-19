using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.DTOs.Result;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<LoginResult> CreateAsync(UserCreateRequest _request);
        Task<LoginResult> LoginAsync(LoginRequest login);
    }
}