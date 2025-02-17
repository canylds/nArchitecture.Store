using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.ProductService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, 
    ISecuredRequest,
    ITransactionalRequest
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        private readonly IProductService _productService;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper,
            CategoryBusinessRules categoryBusinessRules,
            IProductService productService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _productService = productService;
        }

        public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetAsync(predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken);

            await _categoryBusinessRules.CategoryShouldBeExistsWhenSelected(category);

            await _productService.UnassignCategoryFromProductsAsync(category!.Id);

            Category deletedCategory = await _categoryRepository.DeleteAsync(category!, cancellationToken: cancellationToken);

            DeletedCategoryResponse response = _mapper.Map<DeletedCategoryResponse>(deletedCategory);

            return response;
        }
    }
}
