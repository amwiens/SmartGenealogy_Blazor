﻿namespace SmartGenealogy.Application.Common.Interfaces.Identity;

public interface IIdentityService : IService
{
    Task<string?> GetUserNameAsync(string userId, CancellationToken cancellation = default);

    Task<bool> IsInRoleAsync(string userId, string role, CancellationToken cancellation = default);

    Task<bool> AuthorizeAsync(string userId, string policyName, CancellationToken cancellation = default);

    Task<Result> DeleteUserAsync(string userId, CancellationToken cancellation = default);

    Task<IDictionary<string, string?>> FetchUsers(string roleName, CancellationToken cancellation= default);

    Task UpdateLiveStatus(string userId, bool isLive, CancellationToken cancellation = default);

    Task<ApplicationUserDto> GetApplicationUserDto(string userId, CancellationToken cancellation = default);

    string GetUserName(string userId);

    Task<List<ApplicationUserDto>?> GetUsers(string? tenantId, CancellationToken cancellation = default);
}