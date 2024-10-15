using Application.Features.Categories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Categories.Rules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task CategoryShouldExistWhenSelected(Category? category)
    {
        if (category == null)
            throw new BusinessException(CategoriesMessages.NotExists);

        return Task.CompletedTask;
    }

    public async Task CategoryNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _categoryRepository.AnyAsync(predicate: c => c.Name == name);

        if (doesExist)
            throw new BusinessException(CategoriesMessages.AlreadyExists);
    }

    public async Task CategoryNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _categoryRepository.AnyAsync(predicate: c => c.Id != id && c.Name == name);

        if (doesExist)
            throw new BusinessException(CategoriesMessages.AlreadyExists);
    }
}