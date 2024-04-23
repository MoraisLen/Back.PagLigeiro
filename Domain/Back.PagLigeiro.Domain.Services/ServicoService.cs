using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Model.Servico;
using Microsoft.Extensions.Configuration;

namespace Back.PagLigeiro.Domain.Services
{
    public class ServicoService : BaseService<ServicoModel>, IServicoService
    {
        private readonly IConfiguration _configuration;
        private readonly IServicoRepository _ServicoRepository;
        private readonly IMapper _map;

        public ServicoService
        (
            IConfiguration configuraton,
            IServicoRepository repositoryServico,
            IMapper map
        ) : base(repositoryServico)
        {
            _configuration = configuraton;
            _ServicoRepository = repositoryServico;
            _map = map;
        }
    }
}