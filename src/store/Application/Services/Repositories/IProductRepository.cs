using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, int>, IRepository<Product, int>
{

}
