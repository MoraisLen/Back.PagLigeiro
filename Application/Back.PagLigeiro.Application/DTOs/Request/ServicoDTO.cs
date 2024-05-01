using System.ComponentModel.DataAnnotations;

namespace Back.PagLigeiro.Application.DTOs.Request
{
    public class ServicoRequest
    {
        [Required]
        [MaxLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        public int IdUser { get; set; }
    }

    public class ServicoResult
    {
        public string Descricao { get; set; }
        public int IdUser { get; set; }
    }
}