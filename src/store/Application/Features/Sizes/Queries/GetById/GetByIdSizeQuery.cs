using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Queries.GetById;

public class GetByIdSizeQuery : IRequest<GetByIdSizeResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public GetByIdSizeQuery()
    {

    }

    public GetByIdSizeQuery(int id)
    {
        Id = id;
    }

    public class GetByIdSizeQueryHandler : IRequestHandler<GetByIdSizeQuery, GetByIdSizeResponse>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public GetByIdSizeQueryHandler(ISizeRepository sizeRepository,
            IMapper mapper,
            SizeBusinessRules sizeBusinessRules)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<GetByIdSizeResponse> Handle(GetByIdSizeQuery request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id,
                enableTracking: false,
                cancellationToken: cancellationToken);

            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);

            GetByIdSizeResponse response = _mapper.Map<GetByIdSizeResponse>(size);

            return response;
        }
    }
}
