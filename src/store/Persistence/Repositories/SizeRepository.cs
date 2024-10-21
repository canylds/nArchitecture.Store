using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SizeRepository : EfRepositoryBase<Size, int, StoreDbContext>, ISizeRepository
{
    public SizeRepository(StoreDbContext context) : base(context)
    {

    }
}
