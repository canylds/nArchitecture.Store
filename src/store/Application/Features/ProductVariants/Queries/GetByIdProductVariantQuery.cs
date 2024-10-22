using Application.Features.ProductVariants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductVariants.Constants.ProductVariantsOperationClaims;

namespace Application.Features.ProductVariants.Queries;

public class GetByIdProductVariantQuery : IRequest<GetByIdProductVariantResponse>, ISecuredRequest,
    ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdProductVariantQuery()
    {

    }

    public GetByIdProductVariantQuery(int id)
    {
        Id = id;
    }

    public class GetByIdProductVariantQueryHandler
        : IRequestHandler<GetByIdProductVariantQuery, GetByIdProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;
        private readonly IProductVariantRepository _productVariantRepository;

        public GetByIdProductVariantQueryHandler(IMapper mapper,
            ProductVariantBusinessRules productVariantBusinessRules,
            IProductVariantRepository productVariantRepository)
        {
            _mapper = mapper;
            _productVariantBusinessRules = productVariantBusinessRules;
            _productVariantRepository = productVariantRepository;
        }

        public async Task<GetByIdProductVariantResponse> Handle(GetByIdProductVariantQuery request,
            CancellationToken cancellationToken)
        {
            ProductVariant? productVariant = await _productVariantRepository.GetAsync(pv => pv.Id.Equals(request.Id),
                include: query => query.Include(pv => pv.Product).Include(pv => pv.Color).Include(pv => pv.Size),
                cancellationToken: cancellationToken);

            await _productVariantBusinessRules.ProductVariantShouldExistWhenSelected(productVariant);

            GetByIdProductVariantResponse response = _mapper.Map<GetByIdProductVariantResponse>(productVariant);

            return response;
        }
    }
}
