using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductVariantRepository : IAsyncRepository<ProductVariant, Guid>,
    IRepository<ProductVariant, Guid>
{

}