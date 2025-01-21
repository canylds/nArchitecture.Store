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

    public Task CategoryShouldBeExistsWhenSelected(Category? category)
    {
        if (category == null)
            throw new BusinessException(CategoriesMessages.CategoryDontExists);

        return Task.CompletedTask;
    }

    public async Task CategoryNameShouldNotExistsWhenInsert(string name)
    {
        bool doesExists = await _categoryRepository.AnyAsync(predicate: c => c.Name == name);

        if (doesExists)
            throw new BusinessException(CategoriesMessages.CategoryNameAlreadyExists);
    }

    public async Task CategoryNameShouldNotExistsWhenUpdate(int id, string name)
    {
        bool doesExists = await _categoryRepository.AnyAsync(predicate: c => c.Id != id && c.Name == name);

        if (doesExists)
            throw new BusinessException(CategoriesMessages.CategoryNameAlreadyExists);
    }
}
