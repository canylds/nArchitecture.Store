using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Queries.GetById;

public class GetByIdColorQuery : IRequest<GetByIdColorResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdColorQuery()
    {

    }

    public GetByIdColorQuery(int id)
    {
        Id = id;
    }

    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, GetByIdColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;
        private readonly IColorRepository _colorRepository;

        public GetByIdColorQueryHandler(IMapper mapper,
            ColorBusinessRules colorBusinessRules,
            IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
            _colorRepository = colorRepository;
        }

        public async Task<GetByIdColorResponse> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id,
                enableTracking: false,
                cancellationToken: cancellationToken);

            await _colorBusinessRules.ColorShouldExistWhenSelected(color);

            GetByIdColorResponse response = _mapper.Map<GetByIdColorResponse>(color);

            return response;
        }
    }
}
