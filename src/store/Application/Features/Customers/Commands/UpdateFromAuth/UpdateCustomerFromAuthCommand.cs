using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateFromAuth;

public class UpdateCustomerFromAuthCommand : IRequest<UpdatedCustomerFromAuthResponse>
{
    public int UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }

    public UpdateCustomerFromAuthCommand()
    {
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public UpdateCustomerFromAuthCommand(int userId,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone)
    {
        UserId = userId;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
    }

    public class UpdateCustomerFromAuthCommandHandler
        : IRequestHandler<UpdateCustomerFromAuthCommand, UpdatedCustomerFromAuthResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IMapper _mapper;

        public UpdateCustomerFromAuthCommandHandler(ICustomerRepository customerRepository,
            CustomerBusinessRules customerBusinessRules,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdatedCustomerFromAuthResponse> Handle(UpdateCustomerFromAuthCommand request,
            CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetAsync(predicate: c => c.UserId == request.UserId,
                cancellationToken: cancellationToken);

            await _customerBusinessRules.CustomerShouldBeExistsWhenSelected(customer);

            Customer mappedCustomer = _mapper.Map(request, customer!);

            Customer updatedCustomer = await _customerRepository.UpdateAsync(mappedCustomer);

            UpdatedCustomerFromAuthResponse response = _mapper.Map<UpdatedCustomerFromAuthResponse>(updatedCustomer);

            return response;
        }
    }
}
