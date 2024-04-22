using Back.PagLigeiro.Domain.Enum;
using Back.PagLigeiro.Domain.Model.Cliente;
using Back.PagLigeiro.Domain.Model.Servico;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.PagLigeiro.Domain.Model.Boleto
{
    [Table("TAB_BOLETO")]
    public class BoletoModel : Base
    {
        [MaxLength(300)]
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataMinPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusBoletoEnum Status { get; set; }

        #region Relacionamentos
        public int IdCliente { get; set; }
        public ClienteModel Cliente { get; set; }

        public int IdServico { get; set; }
        public ServicoModel Servico { get; set; }
        #endregion
    }
}