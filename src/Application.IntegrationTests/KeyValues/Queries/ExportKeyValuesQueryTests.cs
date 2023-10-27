using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Features.KeyValues.Queries.Export;

namespace Application.IntegrationTests.KeyValues.Queries;

using static Testing;

public class ExportKeyValuesQueryTests : TestBase
{
    [Test]
    public async Task ShouldNotEmptyExportQuery()
    {
        var query = new ExportKeyValuesQuery();
        var result = await SendAsync(query);
        result.Should().NotBeNull();
    }
}