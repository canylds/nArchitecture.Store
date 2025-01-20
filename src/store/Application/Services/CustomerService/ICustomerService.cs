using Domain.Entities;

namespace Application.Services.CustomerService;

public interface ICustomerService
{
    Task<Customer> AddAsync(Customer customer);
}
