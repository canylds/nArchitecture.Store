using Application.Features.Employees.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Employees.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task EmployeeShouldBeExistsWhenSelected(Employee? employee)
    {
        if (employee == null)
            throw new BusinessException(EmployeesMessages.EmployeeDontExists);

        return Task.CompletedTask;
    }
}
