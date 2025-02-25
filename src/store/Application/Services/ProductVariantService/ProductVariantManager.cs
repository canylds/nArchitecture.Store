using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.ProductVariantService;

public class ProductVariantManager : IProductVariantService
{
    private readonly IProductVariantRepository _productVariantRepository;

    public ProductVariantManager(IProductVariantRepository productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    public async Task<ICollection<ProductVariant>> AddRangeAsync(ICollection<ProductVariant> productVariants)
    {
        ICollection<ProductVariant> addedProductVariants = await _productVariantRepository.AddRangeAsync(productVariants);

        return addedProductVariants;
    }
}
