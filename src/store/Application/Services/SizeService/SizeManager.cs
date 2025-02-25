using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SizeService;

public class SizeManager : ISizeService
{
    private readonly ISizeRepository _sizeRepository;

    public SizeManager(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public async Task<Size?> GetAsync(Expression<Func<Size, bool>> predicate,
        Func<IQueryable<Size>, IIncludableQueryable<Size, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        Size? size = await _sizeRepository.GetAsync(predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return size;
    }
}