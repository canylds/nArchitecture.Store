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
}
