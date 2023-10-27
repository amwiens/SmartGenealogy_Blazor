namespace SmartGenealogy.Application.Features.Products.Specifications;

public class ProductAdvancedFilter : PaginationFilter
{
    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Unit { get; set; }

    public decimal? MaxPrice { get; set; }

    public decimal? MinPrice { get; set; }

    public ProductListView ListView { get; set; } = ProductListView.All;

    public UserProfile? CurrentUser { get; set; }
}