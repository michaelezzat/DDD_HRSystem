using HRSystem.Application.Common.Interfaces;
using HRSystem.Domain.Entities;
using MediatR;

namespace HRSystem.Application.Employees.Commands.AddEmployee;

public record AddEmmloyeeCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class AddEmloyeeCommandHandler : IRequestHandler<AddEmmloyeeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddEmloyeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddEmmloyeeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Employee();

        entity.Title = request.Title;

        _context.Employees.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
