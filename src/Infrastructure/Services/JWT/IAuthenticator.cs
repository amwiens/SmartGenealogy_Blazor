namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface IAuthenticator
{
    Task<ApplicationUser?> Authenticate(string username, string password);
}