﻿using SmartGenealogy.Application.Features.KeyValues.Caching;
using SmartGenealogy.Application.Features.KeyValues.DTOs;

namespace SmartGenealogy.Application.Features.KeyValues.Queries.ByName;

public class KeyValuesQueryByName : ICacheableRequest<IEnumerable<KeyValueDto>>
{
    public KeyValuesQueryByName(Picklist name)
    {
        Name = name;
    }

    public Picklist Name { get; set; }

    public string CacheKey => KeyValueCacheKey.GetCacheKey(Name.ToString());

    public MemoryCacheEntryOptions? Options => KeyValueCacheKey.MemoryCacheEntryOptions;
}

public class KeyValuesQueryByNameHandler : IRequestHandler<KeyValuesQueryByName, IEnumerable<KeyValueDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public KeyValuesQueryByNameHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<KeyValueDto>> Handle(KeyValuesQueryByName request,
        CancellationToken cancellationToken)
    {
        var data = await _context.KeyValues.Where(x => x.Name == request.Name)
            .OrderBy(x => x.Text)
            .ProjectTo<KeyValueDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return data;
    }
}