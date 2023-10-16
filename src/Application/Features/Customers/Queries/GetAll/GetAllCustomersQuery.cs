﻿using SmartGenealogy.Application.Features.Customers.Caching;
using SmartGenealogy.Application.Features.Customers.DTOs;

namespace SmartGenealogy.Application.Features.Customers.Queries.GetAll;

public class GetAllCustomersQuery : ICacheableRequest<IEnumerable<CustomerDto>>
{
    public string CacheKey => CustomerCacheKey.GetAllCacheKey;

    public MemoryCacheEntryOptions? Options => CustomerCacheKey.MemoryCacheEntryOptions;
}

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetAllCustomersQueryHandler> _localizer;

    public GetAllCustomersQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<GetAllCustomersQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implement GetAllCustomersQueryHandler method
        var data = await _context.Customers
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return data;
    }
}