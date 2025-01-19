using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmployeeRepository : EfRepositoryBase<Employee, int, StoreDbContext>, IEmployeeRepository
{
    public EmployeeRepository(StoreDbContext context) : base(context)
    {
    }
}