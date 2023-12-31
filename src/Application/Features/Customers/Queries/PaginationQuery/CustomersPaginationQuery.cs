﻿using SmartGenealogy.Application.Features.Customers.Caching;
using SmartGenealogy.Application.Features.Customers.DTOs;
using SmartGenealogy.Application.Features.Customers.Specifications;

namespace SmartGenealogy.Application.Features.Customers.Queries.PaginationQuery;

public class CustomersWithPaginationQuery : CustomerAdvancedFilter, ICacheableRequest<PaginatedData<CustomerDto>>
{
    public override string ToString()
    {
        return $"Listview:{ListView}, Search:{Keyword}, {OrderBy}, {SortDirection}, {PageNumber}, {PageSize}";
    }

    public string CacheKey => CustomerCacheKey.GetPaginationCacheKey($"{this}");

    public MemoryCacheEntryOptions? Options => CustomerCacheKey.MemoryCacheEntryOptions;

    public CustomerAdvancedPaginationSpec Specification => new CustomerAdvancedPaginationSpec(this);
}

public class CustomersWithPaginationQueryHandler : IRequestHandler<CustomersWithPaginationQuery, PaginatedData<CustomerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<CustomersWithPaginationQueryHandler> _localizer;

    public CustomersWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<CustomersWithPaginationQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<PaginatedData<CustomerDto>> Handle(CustomersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implement CustomersWithPaginationQueryHandler method
        var data = await _context.Customers.OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectToPaginatedDataAsync<Customer, CustomerDto>(request.Specification, request.PageNumber, request.PageSize, _mapper.ConfigurationProvider, cancellationToken);
        return data;
    }
}