using Application.Features.ProductVariants.Constants;
using Application.Features.ProductVariants.Rules;
using Application.Services.ColorService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using Application.Services.SizeService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.ProductVariants.Constants.ProductVariantsOperationClaims;

namespace Application.Features.ProductVariants.Commands.Create;

public class CreateProductVariantCommand : IRequest<CreatedProductVariantResponse>, ISecuredRequest,
    ILoggableRequest
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public string[] Roles => [Admin, Write, ProductVariantsOperationClaims.Create];

    public CreateProductVariantCommand()
    {

    }

    public CreateProductVariantCommand(int productId, int colorId, int sizeId, int unitsInStock)
    {
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }

    public class CreateProductVariantCommandHandler
        : IRequestHandler<CreateProductVariantCommand, CreatedProductVariantResponse>
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IMapper _mapper;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;

        public CreateProductVariantCommandHandler(IProductVariantRepository productVariantRepository,
            IMapper mapper,
            ProductVariantBusinessRules productVariantBusinessRules,
            IProductService productService,
            IColorService colorService,
            ISizeService sizeService)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
            _productVariantBusinessRules = productVariantBusinessRules;
            _productService = productService;
            _colorService = colorService;
            _sizeService = sizeService;
        }

        public async Task<CreatedProductVariantResponse> Handle(CreateProductVariantCommand request,
            CancellationToken cancellationToken)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Id.Equals(request.ProductId),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _productVariantBusinessRules.ProductShouldExistWhenSelected(product);

            Color? color = await _colorService.GetAsync(predicate: c => c.Id.Equals(request.ColorId),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _productVariantBusinessRules.ColorShouldExistWhenSelected(color);

            Size? size = await _sizeService.GetAsync(s => s.Id.Equals(request.SizeId),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _productVariantBusinessRules.SizeShouldExistWhenSelected(size);

            await _productVariantBusinessRules.MyMethod(request.ProductId, request.ColorId, request.SizeId);

            ProductVariant productVariant = _mapper.Map<ProductVariant>(request);

            await _productVariantRepository.AddAsync(productVariant, cancellationToken);

            CreatedProductVariantResponse response = _mapper.Map<CreatedProductVariantResponse>(productVariant);

            return response;
        }
    }
}
