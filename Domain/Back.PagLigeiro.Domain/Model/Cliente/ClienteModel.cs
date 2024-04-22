using Back.PagLigeiro.Domain.Model.Boleto;
using Back.PagLigeiro.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.PagLigeiro.Domain.Model.Cliente
{
    [Table("TAB_CLIENTE")]
    public class ClienteModel : Base
    {
        [MaxLength(300)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        #region Relacionamentos
        public int IdUser { get; set; }
        public UserModel User { get; set; }

        public List<BoletoModel> Boletos { get; set; }
        #endregion
    }
}