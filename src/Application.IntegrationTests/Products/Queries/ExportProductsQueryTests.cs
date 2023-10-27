using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Features.Products.Queries.Export;

namespace Application.IntegrationTests.Products.Queries;

using static Testing;

public class ExportProductsQueryTests : TestBase
{
    [Test]
    public async Task ShouldNotEmptyExportQuery()
    {
        var query = new ExportProductsQuery()
        {
            OrderBy = "Id",
            SortDirection = "Ascending"
        };
        var result = await SendAsync(query);
        result.Should().NotBeNull();
    }

    [Test]
    public async Task ShouldNotEmptyExportQueryWithFilter()
    {
        var query = new ExportProductsQuery()
        {
            Keyword = "1",
            OrderBy = "Id",
            SortDirection = "Ascending"
        };
        var result = await SendAsync(query);
        result.Should().NotBeNull();
    }
}