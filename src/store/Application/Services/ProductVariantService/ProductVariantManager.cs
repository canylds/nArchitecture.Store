using Application.Features.ProductVariants.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ProductVariantService;

public class ProductVariantManager : IProductVariantService
{
    private readonly IProductVariantRepository _productVariantRepository;
    private readonly ProductVariantBusinessRules _productVariantBusinessRules;

    public ProductVariantManager(IProductVariantRepository productVariantRepository,
        ProductVariantBusinessRules productVariantBusinessRules)
    {
        _productVariantRepository = productVariantRepository;
        _productVariantBusinessRules = productVariantBusinessRules;
    }

    public async Task<ICollection<ProductVariant>> AddRangeAsync(ICollection<ProductVariant> productVariants)
    {
        ICollection<ProductVariant> addedProductVariants = await _productVariantRepository.AddRangeAsync(productVariants);

        return addedProductVariants;
    }

    public async Task<ICollection<ProductVariant>> UpdateRangeAsync(ICollection<ProductVariant> productVariants)
    {
        ICollection<ProductVariant> updatedProductVariants = await _productVariantRepository.UpdateRangeAsync(productVariants);

        return updatedProductVariants;
    }

    public async Task<ICollection<ProductVariant>> DeleteRangeAsync(ICollection<ProductVariant> productVariants,
        bool permanent = false)
    {
        ICollection<ProductVariant> deletedProductVariants = await _productVariantRepository.DeleteRangeAsync(productVariants,
            permanent);

        return deletedProductVariants;
    }
}
