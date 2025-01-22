using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductService;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ICollection<Product>> UpdateRangeAsync(ICollection<Product> products)
    {
        ICollection<Product> updatedProducts = await _productRepository.UpdateRangeAsync(products);

        return updatedProducts;
    }

    public async Task<IList<Product>> GetListAsync(Expression<Func<Product, bool>>? predicate = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IList<Product> productList = await _productRepository.GetListAsync(predicate,
            orderBy,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return productList;
    }
}
