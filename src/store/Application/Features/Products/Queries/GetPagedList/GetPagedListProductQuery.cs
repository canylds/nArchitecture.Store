using Application.Services.Repositories;
using AutoMapper;
using core.Application.Responses;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetPagedList;

public class GetPagedListProductQuery : IRequest<GetPagedListResponse<GetPagedListProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetPagedListProductQuery()
    {
        PageRequest = new PageRequest
        {
            PageIndex = 0,
            PageSize = 10
        };
    }

    public GetPagedListProductQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetPagedListProductQueryHandler
        : IRequestHandler<GetPagedListProductQuery, GetPagedListResponse<GetPagedListProductListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetPagedListProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetPagedListResponse<GetPagedListProductListItemDto>> Handle(GetPagedListProductQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetPagedListAsync(index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: query => query.Include(p => p.Category)
                                       .Include(p => p.ProductImages)
                                       .Include(p => p.ProductVariants).ThenInclude(pv => pv.Color)
                                       .Include(p => p.ProductVariants).ThenInclude(pv => pv.Size),
                enableTracking: false,
                cancellationToken: cancellationToken);

            GetPagedListResponse<GetPagedListProductListItemDto> response = _mapper.Map<GetPagedListResponse<GetPagedListProductListItemDto>>(products);

            return response;
        }
    }
}