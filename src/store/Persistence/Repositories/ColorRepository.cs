using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ColorRepository : EfRepositoryBase<Color, int, StoreDbContext>, IColorRepository
{
    public ColorRepository(StoreDbContext context) : base(context)
    {

    }
}