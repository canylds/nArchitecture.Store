using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductService;

public interface IProductService
{
    Task<ICollection<Product>> UpdateRangeAsync(ICollection<Product> products);
    Task<IList<Product>> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
}
