using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ISecuredRequest
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

    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(CategoryBusinessRules categoryBusinessRules,
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _categoryBusinessRules = categoryBusinessRules;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameShouldNotExistsWhenInsert(request.Name);

            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category, cancellationToken);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);

            return response;
        }
    }
}
