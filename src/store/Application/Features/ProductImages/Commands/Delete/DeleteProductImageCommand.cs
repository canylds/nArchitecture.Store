using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Commands.Delete;

public class DeleteProductImageCommand : IRequest<DeletedProductImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ProductImagesOperationClaims.Delete];

    public DeleteProductImageCommand()
    {

    }

    public DeleteProductImageCommand(int id)
    {
        Id = id;
    }

    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand,
        DeletedProductImageResponse>
    {
        private readonly ProductImageBusinessRules _productImageBusinessRules;
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ImageServiceBase _imageService;

        public DeleteProductImageCommandHandler(ProductImageBusinessRules productImageBusinessRules,
            IMapper mapper,
            IProductImageRepository productImageRepository,
            ImageServiceBase imageService)
        {
            _productImageBusinessRules = productImageBusinessRules;
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _imageService = imageService;
        }

        public async Task<DeletedProductImageResponse> Handle(DeleteProductImageCommand request,
            CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: pi => pi.Id == request.Id,
                cancellationToken: cancellationToken);

            await _productImageBusinessRules.ProductImageShouldBeExistsWhenSelected(productImage);

            await _imageService.DeleteAsync(productImage!.Url);

            await _productImageRepository.DeleteAsync(entity: productImage!, cancellationToken: cancellationToken);

            DeletedProductImageResponse response = _mapper.Map<DeletedProductImageResponse>(productImage);

            return response;
        }
    }
}