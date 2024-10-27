using Application.Features.ProductVariants.Constants;
using Application.Features.ProductVariants.Rules;
using Application.Services.ColorService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using Application.Services.SizeService;
using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.ProductVariants.Constants.ProductVariantsOperationClaims;

namespace Application.Features.ProductVariants.Commands.CreateBulk;

public class CreateBulkProductVariantCommand : IRequest<CreatedBulkProductVariantResponse>, ISecuredRequest,
    ILoggableRequest
{
    public int ProductId { get; set; }
    public List<CbpvcProductVariantDto> ProductVariants { get; set; }

    public string[] Roles => [Admin, Write, ProductVariantsOperationClaims.CreateBulk];

    public CreateBulkProductVariantCommand()
    {
        ProductVariants = null!;
    }

    public CreateBulkProductVariantCommand(int productId, List<CbpvcProductVariantDto> productVariants)
    {
        ProductId = productId;
        ProductVariants = productVariants;
    }

    public class CreateBulkProductVariantCommandHandler
        : IRequestHandler<CreateBulkProductVariantCommand, CreatedBulkProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;

        public CreateBulkProductVariantCommandHandler(IMapper mapper,
            ProductVariantBusinessRules productVariantBusinessRules,
            IProductVariantRepository productVariantRepository,
            IProductService productService,
            IColorService colorService,
            ISizeService sizeService)
        {
            _mapper = mapper;
            _productVariantBusinessRules = productVariantBusinessRules;
            _productVariantRepository = productVariantRepository;
            _productService = productService;
            _colorService = colorService;
            _sizeService = sizeService;
        }

        public async Task<CreatedBulkProductVariantResponse> Handle(CreateBulkProductVariantCommand request,
            CancellationToken cancellationToken)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Id.Equals(request.ProductId),
                enableTracking: false,
                cancellationToken: cancellationToken);

            await _productVariantBusinessRules.ProductShouldExistWhenSelected(product);

            foreach (CbpvcProductVariantDto productVariant in request.ProductVariants)
            {
                Color? color = await _colorService.GetAsync(predicate: c => c.Id.Equals(productVariant.ColorId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _productVariantBusinessRules.ColorShouldExistWhenSelected(color);

                Size? size = await _sizeService.GetAsync(s => s.Id.Equals(productVariant.SizeId),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _productVariantBusinessRules.SizeShouldExistWhenSelected(size);

                await _productVariantBusinessRules.ProductVariantShouldNotExistWhenCreating(request.ProductId,
                    productVariant.ColorId,
                    productVariant.SizeId);
            }

            List<ProductVariant> productVariants = _mapper.Map<List<ProductVariant>>(request.ProductVariants);

            foreach (ProductVariant productVariant in productVariants)
                productVariant.ProductId = request.ProductId;

            await _productVariantRepository.AddRangeAsync(productVariants, cancellationToken);

            List<CbpvrProductVariantDto> productVariantDtos = _mapper.Map<List<CbpvrProductVariantDto>>(productVariants);

            CreatedBulkProductVariantResponse response = new(request.ProductId, productVariantDtos);

            return response;
        }
    }
}

public class CbpvcProductVariantDto : IDto
{
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public CbpvcProductVariantDto()
    {

    }

    public CbpvcProductVariantDto(int colorId, int sizeId, int unitsInStock)
    {
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}
