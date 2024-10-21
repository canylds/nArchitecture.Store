using Application.Services.Repositories;
using AutoMapper;
using core.Application.Responses;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorQuery : IRequest<GetListResponse<GetListColorListItemDto>>, ISecuredRequest,
    ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [];

    public GetListColorQuery()
    {
        PageRequest = new PageRequest
        {
            PageIndex = 0,
            PageSize = 10
        };
    }

    public GetListColorQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListColorQueryHandler : IRequestHandler<GetListColorQuery, GetListResponse<GetListColorListItemDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetListColorQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListColorListItemDto>> Handle(GetListColorQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<Color> colors = await _colorRepository.GetListAsync(index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                enableTracking: false,
                cancellationToken: cancellationToken);

            GetListResponse<GetListColorListItemDto> response = _mapper.Map<GetListResponse<GetListColorListItemDto>>(colors);

            return response;
        }
    }
}
