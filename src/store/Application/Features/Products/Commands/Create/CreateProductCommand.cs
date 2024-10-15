using static Application.Features.Products.Constants.ProductsOperationClaims;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Application.Features.Products.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Application.Features.Products.Rules;
using Domain.Entities;
using Core.Application.Pipelines.Logging;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ISecuredRequest, ILoggableRequest
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }

    public string[] Roles => [Admin, Write, ProductsOperationClaims.Create];

    public CreateProductCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public CreateProductCommand(int? categoryId, string name, string description, double unitPrice)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper,
        ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productBusinessRules.ProductNameShouldNotExistWhenCreating(request.Name);

            Product product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product, cancellationToken);

            CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

            return response;
        }
    }
}