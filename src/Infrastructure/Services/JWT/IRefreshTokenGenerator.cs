namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface IRefreshTokenGenerator
{
    Task<string> GenerateRefreshToken(ApplicationUser user);
}