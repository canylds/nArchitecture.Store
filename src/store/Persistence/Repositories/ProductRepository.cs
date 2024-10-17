using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, int, StoreDbContext>, IProductRepository
{
    public ProductRepository(StoreDbContext context) : base(context)
    {

    }
}
