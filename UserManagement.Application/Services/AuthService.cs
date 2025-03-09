using UserManagement.Application.Interfaces;

namespace UserManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public string GenerateToken(string username)
        {
            return _tokenService.CreateToken(username);
        }

        public bool ValidateUserAsync(string Username, string Password)
        {
            return (Username == "admin" && Password == "12345") ? true : false;
        }
    }
}
