using SmartGenealogy.Application.Features.Tenants.Caching;
using SmartGenealogy.Application.Features.Tenants.DTOs;
using SmartGenealogy.Application.Features.Tenants.Specifications;

namespace SmartGenealogy.Application.Features.Tenants.Queries.PaginationQuery;

public class TenantsWithPaginationQuery : PaginationFilter, ICacheableRequest<PaginatedData<TenantDto>>
{
    public string CacheKey => TenantCacheKey.GetPaginationCacheKey($"{this}");

    public MemoryCacheEntryOptions? Options => TenantCacheKey.MemoryCacheEntryOptions;

    public override string ToString()
    {
        return $"Search:{Keyword},OrderBy:{OrderBy} {SortDirection},{PageNumber},{PageSize}";
    }

    public TenantsPaginationSpecification Specification => new TenantsPaginationSpecification(this);
}

public class TenantsWithPaginationQueryHandler :
    IRequestHandler<TenantsWithPaginationQuery, PaginatedData<TenantDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<TenantsWithPaginationQueryHandler> _localizer;
    private readonly IMapper _mapper;

    public TenantsWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<TenantsWithPaginationQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<PaginatedData<TenantDto>> Handle(TenantsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var data = await _context.Tenants.OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectToPaginatedDataAsync<Tenant, TenantDto>(request.Specification, request.PageNumber, request.PageSize, _mapper.ConfigurationProvider, cancellationToken);
        return data;
    }
}