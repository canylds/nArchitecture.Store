using Application.Features.Employees.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Employees.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, CreatedEmployeeResponse>();
    }
}
