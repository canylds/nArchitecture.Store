using static Application.Features.Products.Constants.ProductsOperationClaims;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Application.Features.Products.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Application.Features.Products.Rules;
using Domain.Entities;
using Core.Application.Pipelines.Logging;
using Application.Services.CategoryService;
using Core.Application.Dtos;
using Application.Services.ColorService;
using Application.Services.SizeService;
using Core.Application.Pipelines.Transaction;
using Application.Services.ProductVariantService;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ISecuredRequest,
    ILoggableRequest,
    ITransactionalRequest
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public List<CpcProductVariantDto> ProductVariants { get; set; }

    public string[] Roles => [Admin, Write, ProductsOperationClaims.Create];

    public CreateProductCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductVariants = null!;
    }

    public CreateProductCommand(int? categoryId,
        string name,
        string description,
        double unitPrice,
        List<CpcProductVariantDto> productVariants)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        ProductVariants = productVariants;
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IProductVariantService _productVariantService;

        public CreateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules,
            ICategoryService categoryService,
            IColorService colorService,
            ISizeService sizeService,
            IProductVariantService productVariantService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _categoryService = categoryService;
            _colorService = colorService;
            _sizeService = sizeService;
            _productVariantService = productVariantService;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.CategoryId != null)
            {
                Category? category = await _categoryService.GetAsync(predicate: c => c.Id == request.CategoryId,
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _productBusinessRules.CategoryShouldExistWhenSelected(category);
            }

            foreach (CpcProductVariantDto productVariant in request.ProductVariants)
            {
                Color? color = await _colorService.GetAsync(predicate: c => c.Id.Equals(productVariant.ColorId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _productBusinessRules.ColorShouldExistWhenSelected(color);

                Size? size = await _sizeService.GetAsync(s => s.Id.Equals(productVariant.SizeId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _productBusinessRules.SizeShouldExistWhenSelected(size);
            }

            await _productBusinessRules.ProductNameShouldNotExistWhenCreating(request.Name);

            Product product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product, cancellationToken);

            List<ProductVariant> productVariants = _mapper.Map<List<ProductVariant>>(request.ProductVariants);

            foreach (ProductVariant productVariant in productVariants)
                productVariant.ProductId = product.Id;

            await _productVariantService.AddRangeAsync(productVariants);

            CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

            return response;
        }
    }
}

public class CpcProductVariantDto : IDto
{
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public CpcProductVariantDto()
    {

    }

    public CpcProductVariantDto(int colorId, int sizeId, int unitsInStock)
    {
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}