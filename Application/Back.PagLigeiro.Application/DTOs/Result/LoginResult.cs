using Back.PagLigeiro.Application.DTOs.Request;

namespace Back.PagLigeiro.Application.DTOs.Result
{
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
