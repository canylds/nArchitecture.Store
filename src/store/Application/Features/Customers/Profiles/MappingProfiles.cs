using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.UpdateFromAuth;
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
    }
}
