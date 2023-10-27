using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Common.ExceptionHandlers;
using SmartGenealogy.Application.Features.KeyValues.Commands.AddEdit;
using SmartGenealogy.Application.Features.KeyValues.Commands.Delete;
using SmartGenealogy.Domain.Entities;
using SmartGenealogy.Domain.Enums;

namespace Application.IntegrationTests.KeyValues.Commands;

using static Testing;

public class DeleteKeyValueTests : TestBase
{
    [Test]
    public void ShouldRequireValidKeyValueId()
    {
        var command = new DeleteKeyValueCommand(new int[] { 99 });

        FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteKeyValue()
    {
        var addCommand = new AddEditKeyValueCommand()
        {
            Name = Picklist.Brand,
            Text = "Word",
            Value = "Word",
            Description = "For Test"
        };
        var result = await SendAsync(addCommand);

        await SendAsync(new DeleteKeyValueCommand(new int[] { result.Data }));

        var item = await FindAsync<Document>(result.Data);

        item.Should().BeNull();
    }
}