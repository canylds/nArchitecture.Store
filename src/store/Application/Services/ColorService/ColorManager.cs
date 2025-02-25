using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ColorService;

public class ColorManager : IColorService
{
    private readonly IColorRepository _colorRepository;

    public ColorManager(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task<Color?> GetAsync(Expression<Func<Color, bool>> predicate,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        Color? color = await _colorRepository.GetAsync(predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return color;
    }
}
