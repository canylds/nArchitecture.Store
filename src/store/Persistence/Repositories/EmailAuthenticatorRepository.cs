using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, StoreDbContext>,
    IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(StoreDbContext context) : base(context)
    {

    }
}
