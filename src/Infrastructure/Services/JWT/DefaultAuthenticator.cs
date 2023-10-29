﻿namespace SmartGenealogy.Infrastructure.Services.JWT;

public class DefaultAuthenticator : IAuthenticator
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DefaultAuthenticator(IServiceScopeFactory scopeFactory)
    {
        var scope = scopeFactory.CreateScope();
        _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    }

    public async Task<ApplicationUser?> Authenticate(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return null;
        }

        var correctPassword = await _userManager.CheckPasswordAsync(user, password);

        if (!correctPassword)
        {
            return null;
        }

        return user;
    }
}