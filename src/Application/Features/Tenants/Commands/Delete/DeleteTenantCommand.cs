using SmartGenealogy.Application.Common.Interfaces.MultiTenant;
using SmartGenealogy.Application.Features.Tenants.Caching;

namespace SmartGenealogy.Application.Features.Tenants.Commands.Delete;

public class DeleteTenantCommand : ICacheInvalidatorRequest<Result<int>>
{

    public DeleteTenantCommand(string[] id)
    {
        Id = id;
    }

    public string[] Id { get; }

    public string CacheKey => TenantCacheKey.GetAllCacheKey;

    public CancellationTokenSource? SharedExpiryTokenSource => TenantCacheKey.SharedExpiryTokenSource();
}

public class DeleteTenantCommandHandler :
    IRequestHandler<DeleteTenantCommand, Result<int>>
{
    private readonly ITenantService _tenantsService;
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IStringLocalizer<DeleteTenantCommandHandler> _stringLocalizer;
    private readonly IMapper _mapper;

    public DeleteTenantCommandHandler(
        ITenantService tenantsService,
        IApplicationDbContext applicationDbContext,
        IStringLocalizer<DeleteTenantCommandHandler> stringLocalizer, IMapper mapper)
    {
        _tenantsService = tenantsService;
        _applicationDbContext = applicationDbContext;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
    {
        var items = await _applicationDbContext.Tenants.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
        foreach (var item in items)
        {
            _applicationDbContext.Tenants.Remove(item);
        }

        var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
        await _tenantsService.Refresh();
        return await Result<int>.SuccessAsync(result);
    }
}