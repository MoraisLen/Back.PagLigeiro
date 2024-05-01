using AutoMapper;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Generics;
using Back.PagLigeiro.Domain.Model.Servico;
using Back.PagLigeiro.Domain.Model.User;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public new async Task<ValidationReturn<ServicoModel>> CreateAsync(ServicoModel servico)
        {            
            await _ServicoRepository.CreateAsync(servico);

            if (!await _ServicoRepository.CommitAsync())
                return ValidationReturn<ServicoModel>.WithErrors(new FildErrorReturn("Operação de gravação", "Ocorreu um erro no processo de gravação. Verifique os logs.").ToList());
            else
                return ValidationReturn<ServicoModel>.Ok(servico);
        }
    }
}