using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, int, StoreDbContext>, IUserRepository
{
    public UserRepository(StoreDbContext context) : base(context)
    {

    }
}
