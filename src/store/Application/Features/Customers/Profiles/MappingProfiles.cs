using Application.Features.Customers.Commands.UpdateFromAuth;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Customers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UpdateCustomerFromAuthCommand, Customer>();
        CreateMap<Customer, UpdatedCustomerFromAuthResponse>();
    }
}
