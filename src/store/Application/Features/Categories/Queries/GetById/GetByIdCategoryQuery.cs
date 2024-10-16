using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdCategoryQuery()
    {

    }

    public GetByIdCategoryQuery(int id)
    {
        Id = id;
    }

    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(IMapper mapper,
        ICategoryRepository categoryRepository,
        CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id,
            enableTracking: false,
            cancellationToken: cancellationToken);

            await _categoryBusinessRules.CategoryShouldExistWhenSelected(category);

            GetByIdCategoryResponse response = _mapper.Map<GetByIdCategoryResponse>(category);

            return response;
        }
    }
}