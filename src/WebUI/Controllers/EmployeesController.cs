using HRSystem.Application.Employees.Commands.AddEmployee;
using HRSystem.Application.Employees.Commands.DeleteEmployee;
using HRSystem.Application.Employees.Queries.GetEmployees;
using HRSystem.Application.TodoLists.Commands.UpdateEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.WebUI.Controllers;

[Authorize]
public class EmployeesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<EmloyeeVm>> Get()
    {
        return await Mediator.Send(new GetEmployeesQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(AddEmmloyeeCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteEmployeeCommand(id));

        return NoContent();
    }
}
