using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.CustomerService;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerBusinessRules _customerBusinessRules;

    public CustomerManager(ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules)
    {
        _customerRepository = customerRepository;
        _customerBusinessRules = customerBusinessRules;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _customerBusinessRules.CustomerUserIdShouldNotExistWhenCreating(customer.UserId);

        Customer addedCustomer = await _customerRepository.AddAsync(customer);

        return addedCustomer;
    }
}
