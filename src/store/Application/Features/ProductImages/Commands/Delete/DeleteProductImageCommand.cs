using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductImages.Commands.Delete;

public class DeleteProductImageCommand : IRequest<DeletedProductImageResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => throw new NotImplementedException();

    public DeleteProductImageCommand()
    {

    }

    public DeleteProductImageCommand(int id)
    {
        Id = id;
    }

    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, DeletedProductImageResponse>
    {
        private readonly ProductImageBusinessRules _productImageBusinessRules;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public DeleteProductImageCommandHandler(ProductImageBusinessRules productImageBusinessRules,
            IProductImageRepository productImageRepository,
            IMapper mapper)
        {
            _productImageBusinessRules = productImageBusinessRules;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedProductImageResponse> Handle(DeleteProductImageCommand request,
            CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: pi => pi.Id == request.Id,
                cancellationToken: cancellationToken);

            await _productImageBusinessRules.ProductImageShouldExistWhenSelected(productImage);

            await _productImageRepository.DeleteAsync(productImage!);

            DeletedProductImageResponse response = _mapper.Map<DeletedProductImageResponse>(productImage);

            return response;
        }
    }
}
