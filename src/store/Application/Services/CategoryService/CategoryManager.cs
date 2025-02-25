using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CategoryService;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category?> GetAsync(Expression<Func<Category, bool>> predicate,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        Category? category = await _categoryRepository.GetAsync(predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return category;
    }
}
