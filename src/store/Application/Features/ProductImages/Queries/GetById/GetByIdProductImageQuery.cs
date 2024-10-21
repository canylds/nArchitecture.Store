using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Queries.GetById;

public class GetByIdProductImageQuery : IRequest<GetByIdProductImageResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdProductImageQuery()
    {

    }

    public GetByIdProductImageQuery(int id)
    {
        Id = id;
    }

    public class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQuery, GetByIdProductImageResponse>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public GetByIdProductImageQueryHandler(IProductImageRepository productImageRepository,
            IMapper mapper,
            ProductImageBusinessRules productImageBusinessRules)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<GetByIdProductImageResponse> Handle(GetByIdProductImageQuery request, CancellationToken cancellationToken)
        {
            ProductImage? productImage = await _productImageRepository.GetAsync(predicate: pi => pi.Id.Equals(request.Id),
                include: query => query.Include(pi => pi.Product),
                cancellationToken: cancellationToken);

            await _productImageBusinessRules.ProductImageShouldExistWhenSelected(productImage);

            GetByIdProductImageResponse response = _mapper.Map<GetByIdProductImageResponse>(productImage);

            return response;
        }
    }
}
