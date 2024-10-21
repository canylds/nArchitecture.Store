using Application.Services.Repositories;
using AutoMapper;
using core.Application.Responses;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Queries.GetList;

public class GetListSizeQuery : IRequest<GetListResponse<GetListSizeListItemDto>>, ISecuredRequest,
    ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public GetListSizeQuery()
    {
        PageRequest = new PageRequest
        {
            PageIndex = 0,
            PageSize = 10
        };
    }

    public GetListSizeQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListSizeQueryHandler : IRequestHandler<GetListSizeQuery, GetListResponse<GetListSizeListItemDto>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public GetListSizeQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSizeListItemDto>> Handle(GetListSizeQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<Size> sizes = await _sizeRepository.GetListAsync(index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                enableTracking: false,
                cancellationToken: cancellationToken);

            GetListResponse<GetListSizeListItemDto> response = _mapper.Map<GetListResponse<GetListSizeListItemDto>>(sizes);

            return response;
        }
    }
}
