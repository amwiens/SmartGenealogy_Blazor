﻿namespace SmartGenealogy.Infrastructure.Services.JWT;

/// <summary>
/// The dto used to send an authenticated user response containing access Token and refresh Token
/// </summary>
public class AuthenticatedUserResponse
{
    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}