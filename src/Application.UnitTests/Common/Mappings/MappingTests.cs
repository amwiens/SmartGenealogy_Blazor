﻿using System.Reflection;
using System.Runtime.Serialization;

using AutoMapper;

using NUnit.Framework;

using SmartGenealogy.Application.Common.Interfaces;
using SmartGenealogy.Application.Features.Documents.DTOs;
using SmartGenealogy.Application.Features.KeyValues.DTOs;
using SmartGenealogy.Application.Features.Products.DTOs;
using SmartGenealogy.Domain.Entities;

namespace Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));
        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Document), typeof(DocumentDto), true)]
    [TestCase(typeof(KeyValue), typeof(KeyValueDto), true)]
    [TestCase(typeof(Product), typeof(ProductDto), true)]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination, bool inverseMap = false)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);

        if (inverseMap)
        {
            ShouldSupportMappingFromSourceToDestination(destination, source, false);
        }
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type);

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}