using AutoMapper;
using Back.PagLigeiro.Application.DTOs.Request;
using Back.PagLigeiro.Application.Interfaces;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.Cliente;
using Back.PagLigeiro.Domain.Model.Servico;
using Back.PagLigeiro.Domain.Model.User;
using Back.PagLigeiro.Util.Security;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Back.PagLigeiro.Application
{
    public class ServicoApplicationService : IServicoApplicationService
    {
        private readonly IMapper _map;
        private readonly IServicoService _service;
        private readonly IConfiguration _configuration;

        public ServicoApplicationService(IMapper map, IConfiguration configuration, IServicoService service)
        {
            _map = map;
            _configuration = configuration;
            _service = service;
        }

        public async Task<ValidationReturn<ServicoResult>> CreateAsync(ServicoRequest request)
        {
            ValidationReturn<ServicoModel> result = await _service.CreateAsync(_map.Map<ServicoModel>(request));

            return (result.Success) 
                ? ValidationReturn<ServicoResult>.Ok(_map.Map<ServicoResult>(result.Data)) 
                : ValidationReturn<ServicoResult>.WithErrors(result.Errors); 
        }
    }
}