using Application.Features.ProductImages.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.ProductImages.Rules;

public class ProductImageBusinessRules : BaseBusinessRules
{
    public Task ProductImageShouldBeExistsWhenSelected(ProductImage? productImage)
    {
        if (productImage == null)
            throw new BusinessException(ProductImagesMessages.ProductImageDontExists);

        return Task.CompletedTask;
    }

    public Task ProductShouldBeExistsWhenAddingImages(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductImagesMessages.ProductDontExistsWhenAddingImages);

        return Task.CompletedTask;
    }
}
