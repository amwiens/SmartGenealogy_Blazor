using SmartGenealogy.Application.Features.KeyValues.DTOs;

namespace SmartGenealogy.Application.Common.Interfaces;

public interface IPicklistService
{
    List<KeyValueDto> DataSource { get; }

    event Action? OnChange;

    Task InitializeAsync();

    void Initialize();

    Task Refresh();
}