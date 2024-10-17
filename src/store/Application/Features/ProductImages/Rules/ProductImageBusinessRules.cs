using Application.Features.ProductImages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.ProductImages.Rules;

public class ProductImageBusinessRules : BaseBusinessRules
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageBusinessRules(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    public Task ProductImageShouldExistWhenSelected(ProductImage? productImage)
    {
        if (productImage == null)
            throw new BusinessException(ProductImagesMessages.NotExists);

        return Task.CompletedTask;
    }

    public Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductImagesMessages.ProductDontExists);

        return Task.CompletedTask;
    }
}
