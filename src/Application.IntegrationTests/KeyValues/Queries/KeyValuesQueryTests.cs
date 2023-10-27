using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Features.KeyValues.Queries.ByName;
using SmartGenealogy.Domain.Enums;

namespace Application.IntegrationTests.KeyValues.Queries;

using static Testing;

public class KeyValuesQueryTests : TestBase
{
    [Test]
    public void ShouldNotNullKeyValuesQueryByName()
    {
        var query = new KeyValuesQueryByName(Picklist.Brand);
        var result = SendAsync(query);
        FluentActions.Invoking(() =>
            SendAsync(query)).Should().NotBeNull();
    }
}