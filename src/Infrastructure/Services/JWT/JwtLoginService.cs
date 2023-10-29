namespace SmartGenealogy.Infrastructure.Services.JWT;

/// <summary>
/// Use this class to log a user in.
/// </summary>
public class JwtLoginService : ILoginService
{
    private readonly ITokenGeneratorService _tokenGenerator;

    public JwtLoginService(ITokenGeneratorService tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    /// <summary>
    /// Use this method to get an access Token and a refresh Token for the given TUser
    /// </summary>
    /// <param name="user">User</param>
    /// <returns>An instance of <see cref="AuthenticatedUserResponse"/>, containing an access Token and a refresh Token</returns>
    public async Task<AuthenticatedUserResponse> LoginAsync(ApplicationUser user)
    {
        var accessToken = await _tokenGenerator.GenerateAccessToken(user);
        var refreshToken = await _tokenGenerator.GenerateRefreshToken(user);

        return new AuthenticatedUserResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}