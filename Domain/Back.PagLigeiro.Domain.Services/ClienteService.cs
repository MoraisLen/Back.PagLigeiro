using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Model.Cliente;
using Microsoft.Extensions.Configuration;

namespace Back.PagLigeiro.Domain.Services
{
    public class ClienteService : BaseService<ClienteModel>, IClienteService
    {
        private readonly IConfiguration _configuration;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _map;

        public ClienteService
        (
            IConfiguration configuraton,
            IClienteRepository repositoryCliente,
            IMapper map
        ) : base(repositoryCliente)
        {
            _configuration = configuraton;
            _ClienteRepository = repositoryCliente;
            _map = map;
        }
    }
}