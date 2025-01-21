using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationCLaims;
using Application.Features.Colors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Application.Features.Colors.Rules;
using Domain.Entities;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand : IRequest<DeletedColorResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ColorsOperationCLaims.Delete];

    public DeleteColorCommand()
    {

    }

    public DeleteColorCommand(int id)
    {
        Id = id;
    }

    public class DeleteColorCommandHandler
        : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;

        public DeleteColorCommandHandler(IColorRepository colorRepository,
            IMapper mapper,
            ColorBusinessRules colorBusinessRules)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request,
            CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(c => c.Id == request.Id,
                cancellationToken: cancellationToken);

            await _colorBusinessRules.ColorShouldExistWhenSelected(color);

            await _colorRepository.DeleteAsync(color!, cancellationToken: cancellationToken);

            DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(color);

            return response;
        }
    }
}