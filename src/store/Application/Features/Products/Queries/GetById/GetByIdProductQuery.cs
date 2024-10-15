using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Products.Constants.ProductsOperationClaims;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductQuery : IRequest<GetByIdProductResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdProductQuery()
    {

    }

    public GetByIdProductQuery(int id)
    {
        Id = id;
    }

    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetByIdProductQueryHandler(IProductRepository productRepository,
        IMapper mapper,
        ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id.Equals(request.Id),
            include: query => query.Include(p => p.Category),
            enableTracking: false,
            cancellationToken: cancellationToken);

            await _productBusinessRules.ProductShouldExistWhenSelected(product);

            GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);

            return response;
        }
    }
}