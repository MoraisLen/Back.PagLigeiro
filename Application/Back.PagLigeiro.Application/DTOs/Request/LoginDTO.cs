using System.ComponentModel.DataAnnotations;

namespace Back.PagLigeiro.Application.DTOs.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool ManterConectado { get; set; }
    }
}
