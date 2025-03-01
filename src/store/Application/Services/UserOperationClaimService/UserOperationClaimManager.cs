using System.Linq.Expressions;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services.UserOperationClaimService;

public class UserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<UserOperationClaim> AddAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId);

        UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userUserOperationClaim);

        return addedUserOperationClaim;
    }

    public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(userUserOperationClaim.Id,
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId);

        UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(userUserOperationClaim);

        return updatedUserOperationClaim;
    }

    public async Task<UserOperationClaim> DeleteAsync(UserOperationClaim userUserOperationClaim, bool permanent = false)
    {
        UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userUserOperationClaim);

        return deletedUserOperationClaim;
    }

    public async Task<UserOperationClaim?> GetAsync(Expression<Func<UserOperationClaim, bool>> predicate,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        UserOperationClaim? userUserOperationClaim = await _userOperationClaimRepository.GetAsync(predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return userUserOperationClaim;
    }

    public async Task<IPaginate<UserOperationClaim>?> GetListAsync(Expression<Func<UserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>>? orderBy = null,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IPaginate<UserOperationClaim> userUserOperationClaimList = await _userOperationClaimRepository.GetPagedListAsync(predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken);

        return userUserOperationClaimList;
    }
}