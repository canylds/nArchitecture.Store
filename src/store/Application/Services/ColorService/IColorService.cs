using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ColorService;

public interface IColorService
{
    Task<Color?> GetAsync(Expression<Func<Color, bool>> predicate,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
}
