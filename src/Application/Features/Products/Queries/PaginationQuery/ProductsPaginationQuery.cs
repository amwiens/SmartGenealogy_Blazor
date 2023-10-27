using SmartGenealogy.Application.Features.Products.Caching;
using SmartGenealogy.Application.Features.Products.DTOs;
using SmartGenealogy.Application.Features.Products.Specifications;

namespace SmartGenealogy.Application.Features.Products.Queries.PaginationQuery;

public class ProductsWithPaginationQuery : ProductAdvancedFilter, ICacheableRequest<PaginatedData<ProductDto>>
{
    public string CacheKey => ProductCacheKey.GetPaginationCacheKey($"{this}");

    public MemoryCacheEntryOptions? Options => ProductCacheKey.MemoryCacheEntryOptions;

    public override string ToString()
    {
        return $"CurrentUser:{CurrentUser?.UserId},ListView:{ListView},Search:{Keyword},Name:{Name},Brand:{Brand},Unit:{Unit},MinPrice:{MinPrice},MaxPrice:{MaxPrice},SortDirection:{SortDirection},Ordery:{OrderBy},{PageNumber},{PageSize}";
    }

    public ProductAdvancedSpecification Specification => new ProductAdvancedSpecification(this);
}

public class ProductsWithPaginationQueryHandler :
    IRequestHandler<ProductsWithPaginationQuery, PaginatedData<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<ProductsWithPaginationQueryHandler> _localizer;
    private readonly IMapper _mapper;

    public ProductsWithPaginationQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<ProductsWithPaginationQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<PaginatedData<ProductDto>> Handle(ProductsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var data = await _context.Products.OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectToPaginatedDataAsync<Product, ProductDto>(request.Specification, request.PageNumber, request.PageSize, _mapper.ConfigurationProvider, cancellationToken);
        return data;
    }
}