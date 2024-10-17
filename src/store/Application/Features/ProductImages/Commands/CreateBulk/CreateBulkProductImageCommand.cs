using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.ImageService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Commands.CreateBulk;

public class CreateBulkProductImageCommand : IRequest<CreatedBulkProductImageResponse>, ISecuredRequest,
    ILoggableRequest
{
    public int ProductId { get; set; }
    public List<IFormFile> Images { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.CreateBulk];

    public CreateBulkProductImageCommand()
    {
        Images = null!;
    }

    public CreateBulkProductImageCommand(int productId, List<IFormFile> images)
    {
        ProductId = productId;
        Images = images;
    }

    public class CreateBulkProductImageCommandHandler
        : IRequestHandler<CreateBulkProductImageCommand, CreatedBulkProductImageResponse>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;
        private readonly ProductImageBusinessRules _productImageBusinessRules;
        private readonly ImageServiceBase _imageService;
        private readonly IProductService _productService;

        public CreateBulkProductImageCommandHandler(IProductImageRepository productImageRepository,
            IMapper mapper,
            ProductImageBusinessRules productImageBusinessRules,
            ImageServiceBase imageService,
            IProductService productService)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _productImageBusinessRules = productImageBusinessRules;
            _imageService = imageService;
            _productService = productService;
        }

        public async Task<CreatedBulkProductImageResponse> Handle(CreateBulkProductImageCommand request,
            CancellationToken cancellationToken)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Id == request.ProductId,
                enableTracking: false,
                cancellationToken: cancellationToken);

            await _productImageBusinessRules.ProductShouldExistWhenSelected(product);

            List<ProductImage> productImages = [];

            foreach (IFormFile image in request.Images)
                productImages.Add(new()
                {
                    ProductId = request.ProductId,
                    Url = await _imageService.UploadAsync(image)
                });

            await _productImageRepository.AddRangeAsync(productImages, cancellationToken);

            List<CbpirProductImageDto> productImageDtos = _mapper.Map<List<CbpirProductImageDto>>(productImages);

            CreatedBulkProductImageResponse response = new(request.ProductId, productImageDtos);

            return response;
        }
    }
}
