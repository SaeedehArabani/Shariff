namespace UserManagement.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string username);
        bool ValidateUserAsync(string Username, string Password);
    }
}
