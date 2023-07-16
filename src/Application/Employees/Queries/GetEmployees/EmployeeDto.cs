using HRSystem.Application.Common.Mappings;
using HRSystem.Domain.Entities;

namespace HRSystem.Application.TodoLists.Queries.GetTodos;

public class EmployeeDto : IMapFrom<Employee>
{
    public string? Title { get; init; }

}
