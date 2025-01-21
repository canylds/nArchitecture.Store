using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sizes.Queries.GetList;

public class GetListSizeQuery
    : IRequest<IList<GetListSizeListItemDto>>
{
    public class GetListSizeQueryHandler
        : IRequestHandler<GetListSizeQuery, IList<GetListSizeListItemDto>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public GetListSizeQueryHandler(ISizeRepository SizeRepository, IMapper mapper)
        {
            _sizeRepository = SizeRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetListSizeListItemDto>> Handle(GetListSizeQuery request,
            CancellationToken cancellationToken)
        {
            IList<Size> sizes = await _sizeRepository.GetListAsync(enableTracking: false,
                cancellationToken: cancellationToken);

            IList<GetListSizeListItemDto> response = _mapper.Map<IList<GetListSizeListItemDto>>(sizes);

            return response;
        }
    }
}