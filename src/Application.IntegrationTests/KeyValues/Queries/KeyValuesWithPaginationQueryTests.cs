﻿using NUnit.Framework;

using SmartGenealogy.Application.Features.KeyValues.Queries.PaginationQuery;
using SmartGenealogy.Domain.Entities;
using SmartGenealogy.Domain.Enums;

namespace Application.IntegrationTests.KeyValues.Queries;

using static Testing;

public class KeyValuesWithPaginationQueryTests : TestBase
{
    [SetUp]
    public async Task InitData()
    {
        await AddAsync<KeyValue>(new KeyValue() { Name = Picklist.Brand, Text = "Text1", Value = "Value1", Description = "Test Description" });
        await AddAsync<KeyValue>(new KeyValue() { Name = Picklist.Brand, Text = "Text2", Value = "Value2", Description = "Test Description" });
        await AddAsync<KeyValue>(new KeyValue() { Name = Picklist.Brand, Text = "Text3", Value = "Value3", Description = "Test Description" });
        await AddAsync<KeyValue>(new KeyValue() { Name = Picklist.Brand, Text = "Text4", Value = "Value4", Description = "Test Description" });
        await AddAsync<KeyValue>(new KeyValue() { Name = Picklist.Brand, Text = "Text5", Value = "Value5", Description = "Test Description" });
    }

    [Test]
    public async Task ShouldNotEmptyQuery()
    {
        var query = new KeyValuesWithPaginationQuery();
        var result = await SendAsync(query);
        Assert.AreEqual(5, result.TotalItems);
    }

    [Test]
    public async Task ShouldNotEmptyKeywordQuery()
    {
        var query = new KeyValuesWithPaginationQuery() { Keyword = "1" };
        var result = await SendAsync(query);
        Assert.AreEqual(1, result.TotalItems);
    }
}