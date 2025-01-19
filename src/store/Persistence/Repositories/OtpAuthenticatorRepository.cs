using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, StoreDbContext>,
    IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(StoreDbContext context) : base(context)
    {

    }
}
