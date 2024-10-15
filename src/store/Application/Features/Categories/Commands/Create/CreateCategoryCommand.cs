using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ISecuredRequest, ILoggableRequest
{
    public string Name { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, CategoriesOperationClaims.Create];

    public CreateCategoryCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public CreateCategoryCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(IMapper mapper,
        ICategoryRepository categoryRepository,
        CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameShouldNotExistWhenCreating(request.Name);

            Category mappedCategory = _mapper.Map<Category>(request);

            Category addedCategory = await _categoryRepository.AddAsync(mappedCategory, cancellationToken);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(addedCategory);

            return response;
        }
    }
}