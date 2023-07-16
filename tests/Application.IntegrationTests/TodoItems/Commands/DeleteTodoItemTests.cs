using HRSystem.Application.Common.Exceptions;
using HRSystem.Application.TodoItems.Commands.CreateTodoItem;
using HRSystem.Application.TodoItems.Commands.DeleteTodoItem;
using HRSystem.Application.TodoLists.Commands.CreateTodoList;
using HRSystem.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace HRSystem.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new AddEmmloyeeCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new AddEmployeeCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<Employee>(itemId);

        item.Should().BeNull();
    }
}
