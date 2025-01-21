using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ISizeRepository : IAsyncRepository<Size, int>, IRepository<Size, int>
{

}
