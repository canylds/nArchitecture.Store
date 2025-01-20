using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, int, StoreDbContext>, ICategoryRepository
{
    public CategoryRepository(StoreDbContext context) : base(context)
    {

    }
}