using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductImageRepository : EfRepositoryBase<ProductImage, int, StoreDbContext>, 
    IProductImageRepository
{
    public ProductImageRepository(StoreDbContext context) : base(context)
    {

    }
}
