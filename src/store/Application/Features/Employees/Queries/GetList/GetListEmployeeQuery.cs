using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Employees.Constants.EmployeesOperationClaims;

namespace Application.Features.Employees.Queries.GetList;

public class GetListEmployeeQuery : IRequest<IList<GetListEmployeeListItemDto>>, ISecuredRequest
{
    public string[] Roles => [Admin, Read];

    public class GetListEmployeeQueryHandler
        : IRequestHandler<GetListEmployeeQuery, IList<GetListEmployeeListItemDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public async Task<IList<GetListEmployeeListItemDto>> Handle(GetListEmployeeQuery request,
            CancellationToken cancellationToken)
        {
            IList<Employee> employees = await _employeeRepository.GetListAsync(include: query => query.Include(e => e.User),
                enableTracking: false,
                cancellationToken: cancellationToken);

            IList<GetListEmployeeListItemDto> response = _mapper.Map<IList<GetListEmployeeListItemDto>>(employees);

            return response;
        }
    }
}