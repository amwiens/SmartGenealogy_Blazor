using SmartGenealogy.Application.Features.Customers.Caching;
using SmartGenealogy.Application.Features.Customers.DTOs;
using SmartGenealogy.Application.Features.Customers.Specifications;

namespace SmartGenealogy.Application.Features.Customers.Queries.GetById;

public class GetCustomerByIdQuery : ICacheableRequest<CustomerDto>
{
    public required int Id { get; set; }

    public string CacheKey => CustomerCacheKey.GetByIdCacheKey($"{Id}");

    public MemoryCacheEntryOptions? Options => CustomerCacheKey.MemoryCacheEntryOptions;
}

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetCustomerByIdQueryHandler> _localizer;

    public GetCustomerByIdQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<GetCustomerByIdQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implement GetCustomerByIdQueryHandler method
        var data = await _context.Customers.ApplySpecification(new CustomerByIdSpec(request.Id))
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken) ?? throw new NotFoundException($"Customer with id: [{request.Id}] not found.");
        return data;
    }
}