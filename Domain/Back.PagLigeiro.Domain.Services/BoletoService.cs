using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Model.Boleto;
using Microsoft.Extensions.Configuration;

namespace Back.PagLigeiro.Domain.Services
{
    public class BoletoService : BaseService<BoletoModel>, IBoletoService
    {
        private readonly IConfiguration _configuration;
        private readonly IBoletoRepository _BoletoRepository;
        private readonly IMapper _map;

        public BoletoService
        (
            IConfiguration configuraton,
            IBoletoRepository repositoryBoleto,
            IMapper map
        ) : base(repositoryBoleto)
        {
            _configuration = configuraton;
            _BoletoRepository = repositoryBoleto;
            _map = map;
        }
    }
}