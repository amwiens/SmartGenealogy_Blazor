using SmartGenealogy.Application.Features.Tenants.Queries.PaginationQuery;

namespace SmartGenealogy.Application.Features.Tenants.Specifications;

#nullable disable warnings
public class TenantsPaginationSpecification : Specification<Tenant>
{
    public TenantsPaginationSpecification(TenantsWithPaginationQuery query)
    {
        Query.Where(q => q.Name != null)
            .Where(q => q.Name.Contains(query.Keyword) || q.Description.Contains(query.Keyword), !string.IsNullOrEmpty(query.Keyword));
    }
}