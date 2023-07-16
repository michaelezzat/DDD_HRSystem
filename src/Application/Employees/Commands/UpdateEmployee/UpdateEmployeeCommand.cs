using HRSystem.Application.Common.Exceptions;
using HRSystem.Application.Common.Interfaces;
using HRSystem.Domain.Entities;
using MediatR;

namespace HRSystem.Application.TodoLists.Commands.UpdateEmployee;

public record UpdateEmployeeCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
