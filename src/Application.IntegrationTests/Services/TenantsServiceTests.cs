﻿using NUnit.Framework;

using SmartGenealogy.Domain.Entities;

namespace Application.IntegrationTests.Services;

using static Testing;

public class TenantsServiceTests : TestBase
{
    [SetUp]
    public async Task InitData()
    {
        await AddAsync(new Tenant() { Name = "Test1", Description = "Test1" });
        await AddAsync(new Tenant() { Name = "Test2", Description = "Test2" });
    }

    [Test]
    public void ShouldLoadDataSource()
    {
        var tenantsService = CreateTenantsService();
        tenantsService.Initialize();
        var count = tenantsService.DataSource.Count();
        Assert.AreEqual(2, count);
    }

    [Test]
    public async Task ShouldUpdateDataSource()
    {
        await AddAsync(new Tenant() { Name = "Test3", Description = "Test3" });
        var tenantsService = CreateTenantsService();
        await tenantsService.Refresh();
        var count = tenantsService.DataSource.Count();
        Assert.AreEqual(3, count);
    }
}