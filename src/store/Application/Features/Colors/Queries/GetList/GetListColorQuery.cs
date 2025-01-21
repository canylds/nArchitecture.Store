using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorQuery
    : IRequest<IList<GetListColorListItemDto>>
{
    public class GetListColorQueryHandler
        : IRequestHandler<GetListColorQuery, IList<GetListColorListItemDto>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetListColorQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetListColorListItemDto>> Handle(GetListColorQuery request,
            CancellationToken cancellationToken)
        {
            IList<Color> colors = await _colorRepository.GetListAsync(enableTracking: false,
                cancellationToken: cancellationToken);

            IList<GetListColorListItemDto> response = _mapper.Map<IList<GetListColorListItemDto>>(colors);

            return response;
        }
    }
}