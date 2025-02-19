using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductVariantRepository : EfRepositoryBase<ProductVariant, Guid, StoreDbContext>,
    IProductVariantRepository
{
    public ProductVariantRepository(StoreDbContext context) : base(context)
    {

    }
}