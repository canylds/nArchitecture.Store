using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductImageRepository : IAsyncRepository<ProductImage, int>,
    IRepository<ProductImage, int>
{

}
