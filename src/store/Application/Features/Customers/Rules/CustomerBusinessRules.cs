using Application.Features.Customers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Customers.Rules;

public class CustomerBusinessRules : BaseBusinessRules
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerBusinessRules(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task CustomerShouldBeExistsWhenSelected(Customer? customer)
    {
        if (customer == null)
            throw new BusinessException(CustomersMessages.CustomerDontExists);

        return Task.CompletedTask;
    }
}
