using Application.Services.Repositories;
using AutoMapper;
using core.Application.Responses;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public GetListProductQuery()
    {
        PageRequest = new PageRequest
        {
            PageIndex = 0,
            PageSize = 10
        };
    }

    public GetListProductQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListProductQueryHandler(IMapper mapper,
        IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Product> prodocuts =
                await _productRepository.GetListAsync(include: query => query.Include(p => p.Category).Include(p => p.ProductImages),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                enableTracking: false,
                cancellationToken: cancellationToken);

            GetListResponse<GetListProductListItemDto> response = _mapper.Map<GetListResponse<GetListProductListItemDto>>(prodocuts);

            return response;
        }
    }
}