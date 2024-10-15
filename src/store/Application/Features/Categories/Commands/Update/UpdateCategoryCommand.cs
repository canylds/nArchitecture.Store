using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, CategoriesOperationClaims.Update];

    public UpdateCategoryCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public UpdateCategoryCommand(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper,
        CategoryBusinessRules categoryBusinessRules,
        ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id,
            cancellationToken: cancellationToken);

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category);
            await _categoryBusinessRules.CategoryNameShouldNotExistWhenUpdating(request.Id, request.Name);

            Category mappedCategory = _mapper.Map(request, category!);

            Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory, cancellationToken);

            UpdatedCategoryResponse response = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);

            return response;
        }
    }
}