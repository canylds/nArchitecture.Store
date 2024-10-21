using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, StoreDbContext>,
    IOperationClaimRepository
{
    public OperationClaimRepository(StoreDbContext context) : base(context)
    {

    }
}
