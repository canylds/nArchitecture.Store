using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.UpdateFromAuth;
using Application.Features.Customers.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Customers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<Customer, CreatedCustomerResponse>();

        CreateMap<UpdateCustomerFromAuthCommand, Customer>();
        CreateMap<Customer, UpdatedCustomerFromAuthResponse>();

        CreateMap<Customer, GetListCustomerListItemDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
    }
}
