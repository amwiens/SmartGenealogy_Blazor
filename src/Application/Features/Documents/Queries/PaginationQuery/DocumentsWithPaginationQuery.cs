﻿using SmartGenealogy.Application.Features.Documents.Caching;
using SmartGenealogy.Application.Features.Documents.DTOs;
using SmartGenealogy.Application.Features.Documents.Specifications;

namespace SmartGenealogy.Application.Features.Documents.Queries.PaginationQuery;

public class DocumentsWithPaginationQuery : AdvancedDocumentsFilter, ICacheableRequest<PaginatedData<DocumentDto>>
{
    public string CacheKey => DocumentCacheKey.GetPaginationCacheKey($"{this}");

    public MemoryCacheEntryOptions? Options => DocumentCacheKey.MemoryCacheEntryOptions;

    public override string ToString()
    {
        return $"CurrentUserId:{CurrentUser?.UserId},ListView:{ListView},Search:{Keyword},OrderBy:{OrderBy} {SortDirection},{PageNumber},{PageSize}";
    }

    public AdvancedDocumentsSpecification Specification => new AdvancedDocumentsSpecification(this);
}

public class DocumentsQueryHandler : IRequestHandler<DocumentsWithPaginationQuery, PaginatedData<DocumentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DocumentsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedData<DocumentDto>> Handle(DocumentsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var data = await _context.Documents.OrderBy($"{request.OrderBy} {request.SortDirection}")
            .ProjectToPaginatedDataAsync<Document, DocumentDto>(request.Specification, request.PageNumber, request.PageSize, _mapper.ConfigurationProvider, cancellationToken);

        return data;
    }
}