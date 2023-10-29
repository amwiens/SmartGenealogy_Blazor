using Microsoft.IdentityModel.Tokens;

namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface ITokenValidator
{
    Task<TokenValidationResult> ValidateTokenAsync(string token);
}