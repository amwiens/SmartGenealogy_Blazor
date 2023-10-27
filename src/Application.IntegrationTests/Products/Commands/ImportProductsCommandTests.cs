using System.Reflection;

using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Application.Features.Products.Commands.Import;

namespace Application.IntegrationTests.Products.Commands;

using static Testing;

public class ImportProductsCommandTests
{
    [Test]
    public async Task DownloadTemplate()
    {
        var cmd = new CreateProductsTemplateCommand();
        var result = await SendAsync(cmd);
        result.Succeeded.Should().BeTrue();
    }

    [Test]
    public async Task ImportDataFromExcel()
    {
        var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var excelFile = Path.Combine(dir, "../../../", "Products", "ImportExcel", "Products.xlsx");
        var data = File.ReadAllBytes(excelFile);
        var cmd = new ImportProductsCommand("Products.xlsx", data);
        var result = await SendAsync(cmd);
        result.Succeeded.Should().BeTrue();
    }
}