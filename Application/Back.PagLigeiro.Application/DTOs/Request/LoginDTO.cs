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

    public class LoginResult
    {
        public string Token { get; set; }
        public UserResult User { get; set; }

        public LoginResult(string _token, UserResult _user)
        {
            User = _user;
            Token = _token;
        }

        public LoginResult()
        { }
    }
}
