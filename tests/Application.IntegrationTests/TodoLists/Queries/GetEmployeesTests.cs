using HRSystem.Application.TodoLists.Queries.GetTodos;
using HRSystem.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using HRSystem.Application.Employees.Queries.GetEmployees;

namespace HRSystem.Application.IntegrationTests.TodoLists.Queries;

using static Testing;

public class GetEmployeesTests : BaseTestFixture
{
   

    [Test]
    public async Task ShouldReturnAllEmployees()
    {
        await RunAsDefaultUserAsync();

        var query = new GetEmployeesQuery();

        var result = await SendAsync(query);

    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetEmployeesQuery();

        var action = () => SendAsync(query);
        
        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
