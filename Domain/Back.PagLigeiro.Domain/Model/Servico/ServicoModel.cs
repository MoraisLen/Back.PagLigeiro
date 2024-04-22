using Back.PagLigeiro.Domain.Model.Boleto;
using Back.PagLigeiro.Domain.Model.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.PagLigeiro.Domain.Model.Servico
{
    [Table("TAB_SERVICO")]
    public class ServicoModel : Base
    {
        [MaxLength(300)]
        public string Descricao { get; set; }

        #region Relacionamento
        public int IdUser { get; set; }
        public UserModel User { get; set; }

        public List<BoletoModel> Boletos { get; set; }
        #endregion Relacionamento
    }
}