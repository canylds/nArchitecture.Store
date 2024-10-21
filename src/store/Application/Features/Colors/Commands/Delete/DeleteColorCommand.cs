using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand : IRequest<DeletedColorResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ColorsOperationClaims.Delete];

    public DeleteColorCommand()
    {

    }

    public DeleteColorCommand(int id)
    {
        Id = id;
    }

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;
        private readonly IColorRepository _colorRepository;

        public DeleteColorCommandHandler(IMapper mapper,
            ColorBusinessRules colorBusinessRules,
            IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
            _colorRepository = colorRepository;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken);

            await _colorBusinessRules.ColorShouldExistWhenSelected(color);

            await _colorRepository.DeleteAsync(color!, cancellationToken: cancellationToken);

            DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(color);

            return response;
        }
    }
}
