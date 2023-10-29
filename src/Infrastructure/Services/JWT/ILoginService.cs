namespace SmartGenealogy.Infrastructure.Services.JWT;

public interface ILoginService
{
    Task<AuthenticatedUserResponse> LoginAsync(ApplicationUser user);
}