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

    public Task ProductShouldExistWhenSelected(Product? product)
    {
        if (product == null)
            throw new BusinessException(ProductsMessages.NotExists);

        return Task.CompletedTask;
    }

    public async Task ProductNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _productRepository.AnyAsync(p => p.Name == name);

        if (doesExist)
            throw new BusinessException(ProductsMessages.AlreadyExists);
    }

    public async Task ProductNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _productRepository.AnyAsync(p => p.Id != id && p.Name == name);

        if (doesExist)
            throw new BusinessException(ProductsMessages.AlreadyExists);
    }

    public Task CategoryShouldExistWhenSelected(Category? category)
    {
        if (category == null)
            throw new BusinessException(ProductsMessages.CategoryDontExists);

        return Task.CompletedTask;
    }
}