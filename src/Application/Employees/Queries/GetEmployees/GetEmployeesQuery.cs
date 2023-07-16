using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRSystem.Application.Common.Interfaces;
using HRSystem.Application.Common.Security;
using HRSystem.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Application.Employees.Queries.GetEmployees;

[Authorize]
public record GetEmployeesQuery : IRequest<EmloyeeVm>;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmloyeeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmloyeeVm> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        return new EmloyeeVm
        {
           
        };
    }
}
