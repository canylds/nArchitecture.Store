using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductService;

public interface IProductService
{
    Task UnassignCategoryFromProductsAsync(int categoryId);
    Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
}
