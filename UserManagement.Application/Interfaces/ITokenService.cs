namespace UserManagement.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string username);
    }
}
