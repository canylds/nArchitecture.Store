using Application.Features.Products.Constants;
using Application.Features.Products.Rules;
using Application.Services.CategoryService;
using Application.Services.ColorService;
using Application.Services.ProductVariantService;
using Application.Services.Repositories;
using Application.Services.SizeService;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>,
    ISecuredRequest,
    ILoggableRequest,
    ITransactionalRequest
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public List<UpcProductVariantDto> ProductVariants { get; set; }

    public string[] Roles => [Admin, Write, ProductsOperationClaims.Update];

    public UpdateProductCommand()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductVariants = null!;
    }

    public UpdateProductCommand(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        List<UpcProductVariantDto> productVariants)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        ProductVariants = productVariants;
    }

    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IProductVariantService _productVariantService;

        public UpdateProductCommandHandler(IProductRepository productRepository,
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

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id,
                include: query => query.Include(p => p.ProductVariants),
                cancellationToken: cancellationToken);

            await _productBusinessRules.ProductShouldExistWhenSelected(product);

            if (request.CategoryId != null)
            {
                Category? category = await _categoryService.GetAsync(predicate: c => c.Id == request.CategoryId,
                    enableTracking: false,
                    cancellationToken: cancellationToken);

                await _productBusinessRules.CategoryShouldExistWhenSelected(category);
            }

            foreach (UpcProductVariantDto productVariant in request.ProductVariants)
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

            await _productBusinessRules.ProductNameShouldNotExistWhenUpdating(request.Id, request.Name);

            _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product!, cancellationToken);

            List<ProductVariant> productVariantsToAdd = [];
            List<ProductVariant> productVariantsToUpdate = [];
            List<ProductVariant> productVariantsToDelete = [];

            foreach (UpcProductVariantDto upcProductVariantDto in request.ProductVariants)
            {
                ProductVariant? productVariant = product!.ProductVariants.FirstOrDefault(pv =>
                pv.ColorId == upcProductVariantDto.ColorId
                && pv.SizeId == upcProductVariantDto.SizeId);

                if (productVariant == null)
                    productVariantsToAdd.Add(new ProductVariant
                    {
                        ProductId = product.Id,
                        ColorId = upcProductVariantDto.ColorId,
                        SizeId = upcProductVariantDto.SizeId,
                        UnitsInStock = upcProductVariantDto.UnitsInStock
                    });
                else
                {
                    productVariant.UnitsInStock = upcProductVariantDto.UnitsInStock;
                    productVariantsToUpdate.Add(productVariant);
                }
            }

            foreach (ProductVariant existingProductVariant in product!.ProductVariants)
            {
                bool doesExist = request.ProductVariants.Any(pv => pv.ColorId == existingProductVariant.ColorId
                && pv.SizeId == existingProductVariant.SizeId);

                if (!doesExist)
                    productVariantsToDelete.Add(existingProductVariant);
            }

            await _productVariantService.AddRangeAsync(productVariantsToAdd);
            await _productVariantService.UpdateRangeAsync(productVariantsToUpdate);
            var deletedProductVariants = await _productVariantService.DeleteRangeAsync(productVariantsToDelete);

            UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

            List<UprProductVariantDto> uprProductVariantDtosToDelete = [];

            foreach (UprProductVariantDto uprProductVariantDto in response.ProductVariants)
                if (deletedProductVariants.Any(dpv => dpv.Id == uprProductVariantDto.Id))
                    uprProductVariantDtosToDelete.Add(uprProductVariantDto);

            foreach (UprProductVariantDto uprProductVariantDto in uprProductVariantDtosToDelete)
                response.ProductVariants.Remove(uprProductVariantDto);

            return response;
        }
    }
}

public class UpcProductVariantDto : IDto
{
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public UpcProductVariantDto()
    {

    }

    public UpcProductVariantDto(int colorId, int sizeId, int unitsInStock)
    {
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}
