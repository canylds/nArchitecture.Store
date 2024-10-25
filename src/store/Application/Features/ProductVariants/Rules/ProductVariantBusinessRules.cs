using Application.Features.ProductVariants.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.ProductVariants.Rules;

public class ProductVariantBusinessRules : BaseBusinessRules
{
    private readonly IProductVariantRepository _productVariantRepository;

    public ProductVariantBusinessRules(IProductVariantRepository productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    public Task ProductVariantShouldExistWhenSelected(ProductVariant? productVariant)
    {
        if (productVariant == null)
            throw new BusinessException(ProductVariantsMessages.NotExists);

        return Task.CompletedTask;
    }

    public Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductVariantsMessages.ProductDontExists);

        return Task.CompletedTask;
    }

    public Task ColorShouldExistWhenSelected(Color? color)
    {
        if (color == null)
            throw new BusinessException(ProductVariantsMessages.ColorDontExists);

        return Task.CompletedTask;
    }

    public Task SizeShouldExistWhenSelected(Size? size)
    {
        if (size == null)
            throw new BusinessException(ProductVariantsMessages.SizeDontExists);

        return Task.CompletedTask;
    }

    public async Task MyMethod(int productId, int colorId, int sizeId)
    {
        bool doesExist = await _productVariantRepository.AnyAsync(predicate:
            pv => pv.ProductId == productId && pv.ColorId == colorId && pv.SizeId == sizeId);

        if (doesExist)
            throw new BusinessException(ProductVariantsMessages.AlreadyExists);
    }
}
