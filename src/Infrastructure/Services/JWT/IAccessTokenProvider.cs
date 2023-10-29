namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface IAccessTokenProvider
{
    string? AccessToken { get; }

    string? RefreshToken { get; }

    Task<ClaimsPrincipal> GetClaimsPrincipal();

    Task Login(ApplicationUser applicationuser);

    Task RemoveAuthDataFromStorage();
}