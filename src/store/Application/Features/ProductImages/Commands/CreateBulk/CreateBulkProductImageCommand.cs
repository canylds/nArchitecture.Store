using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.ImageService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Commands.CreateBulk;

public class CreateBulkProductImageCommand : IRequest, ISecuredRequest
{
    public Guid ProductId { get; set; }
    public List<IFormFile> Images { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.CreateBulk];

    public CreateBulkProductImageCommand()
    {
        Images = null!;
    }

    public CreateBulkProductImageCommand(Guid productId, List<IFormFile> ımages)
    {
        ProductId = productId;
        Images = ımages;
    }

    public class CreateBulkProductImageCommandHandler : IRequestHandler<CreateBulkProductImageCommand>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;
        private readonly IProductService _productService;
        private readonly ImageServiceBase _imageService;

        public CreateBulkProductImageCommandHandler(IProductImageRepository productImageRepository,
            ProductImageBusinessRules productImageBusinessRules,
            IProductService productService,
            ImageServiceBase imageService)
        {
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
            _productService = productService;
            _imageService = imageService;
        }

        public async Task Handle(CreateBulkProductImageCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Id == request.ProductId,
                enableTracking: false,
                cancellationToken: cancellationToken);

            await _productImageBusinessRules.ProductShouldBeExistsWhenAddingImages(product);

            List<ProductImage> productImages = [];

            foreach (IFormFile image in request.Images)
                productImages.Add(new ProductImage
                {
                    ProductId = request.ProductId,
                    Url = await _imageService.UploadAsync(image)
                });

            await _productImageRepository.AddRangeAsync(productImages, cancellationToken);
        }
    }
}
