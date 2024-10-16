using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CategoriesOperationClaims.Delete];

    public DeleteCategoryCommand()
    {

    }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
    {
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(CategoryBusinessRules categoryBusinessRules,
        ICategoryRepository categoryRepository,
        IMapper mapper)
        {
            _categoryBusinessRules = categoryBusinessRules;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id,
            cancellationToken: cancellationToken);

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category);

            await _categoryRepository.DeleteAsync(category!, cancellationToken: cancellationToken);

            DeletedCategoryResponse response = _mapper.Map<DeletedCategoryResponse>(category);

            return response;
        }
    }
}
