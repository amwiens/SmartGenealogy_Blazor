using SmartGenealogy.Application.Features.Tenants.DTOs;

namespace SmartGenealogy.Application.Common.Interfaces.MultiTenant;

public interface ITenantService
{
    List<TenantDto> DataSource { get; }

    event Action? OnChange;

    Task InitializeAsync();

    void Initialize();

    Task Refresh();
}