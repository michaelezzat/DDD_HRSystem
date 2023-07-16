using System.Runtime.Serialization;
using AutoMapper;
using HRSystem.Application.Common.Mappings;
using HRSystem.Application.Common.Models;
using HRSystem.Application.TodoLists.Queries.GetTodos;
using HRSystem.Domain.Entities;
using NUnit.Framework;

namespace HRSystem.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Employee), typeof(EmployeeDto))]
    [TestCase(typeof(Employee), typeof(TodoItemDto))]
    [TestCase(typeof(Employee), typeof(LookupDto))]
    [TestCase(typeof(Employee), typeof(LookupDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
