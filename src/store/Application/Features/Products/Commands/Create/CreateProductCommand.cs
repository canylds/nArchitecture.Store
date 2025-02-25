using Application.Features.Products.Constants;
using Application.Features.Products.Rules;
using Application.Services.CategoryService;
using Application.Services.ColorService;
using Application.Services.Repositories;
using Application.Services.SizeService;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ISecuredRequest
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
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(ProductBusinessRules productBusinessRules,
            IProductRepository productRepository,
            ICategoryService categoryService,
            IColorService colorService,
            ISizeService sizeService,
            IMapper mapper)
        {
            _productBusinessRules = productBusinessRules;
            _productRepository = productRepository;
            _categoryService = categoryService;
            _colorService = colorService;
            _sizeService = sizeService;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            if (request.CategoryId != null)
            {
                Category? category = await _categoryService.GetAsync(predicate: c => c.Id.Equals(request.CategoryId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _productBusinessRules.CategoryShouldBeExistsWhenAddingProduct(category);
            }

            foreach (CpcProductVariantDto productVariantDto in request.ProductVariants)
            {
                Color? color = await _colorService.GetAsync(predicate: c => c.Id.Equals(productVariantDto.ColorId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _productBusinessRules.ColorShouldBeExistsWhenAddingProduct(color);

                Size? size = await _sizeService.GetAsync(s => s.Id.Equals(productVariantDto.SizeId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _productBusinessRules.SizeShouldBeExistsWhenAddingProduct(size);
            }

            await _productBusinessRules.ProductNameShouldNotExistsWhenInsert(request.Name);

            Product product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product, cancellationToken);

            //To Be Continued
            throw new NotImplementedException();
        }
    }
}

public class CpcProductVariantDto : IDto //CreateProductCommandProductVariantDto
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
