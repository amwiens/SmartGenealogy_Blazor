using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Common.ExceptionHandlers;
using SmartGenealogy.Application.Features.Products.Commands.AddEdit;
using SmartGenealogy.Application.Features.Products.Commands.Delete;
using SmartGenealogy.Application.Features.Products.Queries.GetAll;
using SmartGenealogy.Domain.Entities;

namespace Application.IntegrationTests.Products.Commands;

using static Testing;

public class DeleteProductCommandTests
{
    [SetUp]
    public async Task InitData()
    {
        await AddAsync(new Product() { Name = "Test1" });
        await AddAsync(new Product() { Name = "Test2" });
        await AddAsync(new Product() { Name = "Test3" });
        await AddAsync(new Product() { Name = "Test4" });
        await AddAsync(new Product() { Name = "Test5" });
    }

    [Test]
    public void ShouldRequireValidKeyValueId()
    {
        var command = new DeleteProductCommand(new int[] { 99 });

        FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteOne()
    {
        var addCommand = new AddEditProductCommand() { Name = "Test", Brand = "Brand", Price = 100m, Unit = "EA", Description = "Description" };
        var result = await SendAsync(addCommand);

        await SendAsync(new DeleteProductCommand(new int[] { result.Data }));

        var item = await FindAsync<Product>(result.Data);

        item.Should().BeNull();
    }

    [Test]
    public async Task ShouldDeleteAll()
    {
        var query = new GetAllProductsQuery();
        var result = await SendAsync(query);
        result.Count().Should().Be(4);
        var id = result.Select(x => x.Id).ToArray();
        var deleted = await SendAsync(new DeleteProductCommand(id));
        deleted.Succeeded.Should().BeTrue();

        var deleteResult = await SendAsync(query);
        deleteResult.Should().BeNullOrEmpty();
    }
}