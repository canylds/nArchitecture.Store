using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.ProductService;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task UnassignCategoryFromProductsAsync(int categoryId)
    {
        IList<Product> products = await _productRepository.GetListAsync(predicate: p => p.CategoryId == categoryId);

        foreach (Product product in products)
            product.CategoryId = null;

        await _productRepository.UpdateRangeAsync(products);
    }
}
