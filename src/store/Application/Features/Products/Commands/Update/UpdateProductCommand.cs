using Application.Features.Products.Constants;
using Application.Features.Products.Rules;
using Application.Services.CategoryService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }

    public string[] Roles => [Admin, Write, ProductsOperationClaims.Update];

    public UpdateProductCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public UpdateProductCommand(int id, int? categoryId, string name, string description, double unitPrice)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly ICategoryService _categoryService;

        public UpdateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules,
            ICategoryService categoryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _categoryService = categoryService;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id,
            cancellationToken: cancellationToken);

            await _productBusinessRules.ProductShouldExistWhenSelected(product);

            if (request.CategoryId != null)
            {
                Category? category = await _categoryService.GetAsync(predicate: c => c.Id == request.CategoryId,
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _productBusinessRules.CategoryShouldExistWhenSelected(category);
            }

            await _productBusinessRules.ProductNameShouldNotExistWhenUpdating(request.Id, request.Name);

            _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product!, cancellationToken);

            UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

            return response;
        }
    }
}