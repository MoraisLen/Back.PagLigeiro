using Back.PagLigeiro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Back.PagLigeiro.Application.DTOs.Request
{
    public class UserCreateRequest
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserResult
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public RoleUserEnum Role { get; set; }
    }
}
