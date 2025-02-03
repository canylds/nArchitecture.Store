using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task ProductShouldBeExistsWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductsMessages.ProductDontExists);

        return Task.CompletedTask;
    }

    public async Task ProductIdShouldBeExistsWhenSelected(Guid id)
    {
        bool doesExist = await _productRepository.AnyAsync(predicate: p => p.Id == id);

        if (doesExist)
            throw new BusinessException(ProductsMessages.ProductDontExists);
    }

    public async Task ProductNameShouldNotExistsWhenInsert(string Name)
    {
        bool doesExists = await _productRepository.AnyAsync(predicate: p => p.Name == Name);

        if (doesExists)
            throw new BusinessException(ProductsMessages.ProductNameAlreadyExists);
    }

    public async Task ProductNameShouldNotExistsWhenUpdate(Guid id, string Name)
    {
        bool doesExists = await _productRepository.AnyAsync(predicate: p => p.Id != id && p.Name == Name);

        if (doesExists)
            throw new BusinessException(ProductsMessages.ProductNameAlreadyExists);
    }
}