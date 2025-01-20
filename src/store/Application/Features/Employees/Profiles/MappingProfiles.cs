using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Employees.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, CreatedEmployeeResponse>();

        CreateMap<Employee, GetListEmployeeListItemDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
    }
}
