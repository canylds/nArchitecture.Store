using static Application.Features.Products.Constants.ProductsOperationClaims;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Application.Features.Products.Constants;
using AutoMapper;
using Application.Services.Repositories;
using Application.Features.Products.Rules;
using Domain.Entities;
using Core.Application.Pipelines.Logging;

namespace Application.Features.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<DeletedProductResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ProductsOperationClaims.Delete];

    public DeleteProductCommand()
    {

    }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteProductCommandHandler(IMapper mapper,
        IProductRepository productRepository,
        ProductBusinessRules productBusinessRules)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id,
            cancellationToken: cancellationToken);

            await _productBusinessRules.ProductShouldExistWhenSelected(product);

            await _productRepository.DeleteAsync(entity: product!, cancellationToken: cancellationToken);

            DeletedProductResponse response = _mapper.Map<DeletedProductResponse>(product);

            return response;
        }
    }
}