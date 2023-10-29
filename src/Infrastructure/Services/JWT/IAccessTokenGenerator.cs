namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface IAccessTokenGenerator
{
    Task<string> GenerateAccessToken(ApplicationUser user);
}