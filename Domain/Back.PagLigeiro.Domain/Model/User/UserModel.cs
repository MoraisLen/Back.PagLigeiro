using Back.PagLigeiro.Domain.Enum;
using Back.PagLigeiro.Domain.Model.Cliente;
using Back.PagLigeiro.Domain.Model.Servico;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.PagLigeiro.Domain.Model.User
{
    [Table("TAB_USER")]
    public class UserModel : Base
    {
        [MaxLength(300)]
        public string Nome { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        public DateTime? DataNascimento { get; set; }

        [MaxLength(11)]
        public string CPF { get; set; }

        [MaxLength(20)]
        public string RG { get; set; }

        [MaxLength(500)]
        public string Endereco { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public RoleUserEnum Role { get; set; }
        public DateTime? LastAccess { get; set; }

        #region Relacionamentos

        public List<ServicoModel> Servicos { get; set; }
        public List<ClienteModel> Clientes { get; set; }

        #endregion Relacionamentos
    }
}