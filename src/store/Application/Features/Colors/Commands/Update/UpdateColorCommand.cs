using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Commands.Update;

public class UpdateColorCommand : IRequest<UpdatedColorResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, ColorsOperationClaims.Update];

    public UpdateColorCommand()
    {
        Name = string.Empty;
    }

    public UpdateColorCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdatedColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;
        private readonly IColorRepository _colorRepository;

        public UpdateColorCommandHandler(IMapper mapper,
            ColorBusinessRules colorBusinessRules,
            IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
            _colorRepository = colorRepository;
        }

        public async Task<UpdatedColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id,
                cancellationToken: cancellationToken);

            await _colorBusinessRules.ColorShouldExistWhenSelected(color);
            await _colorBusinessRules.ColorNameShouldNotExistWhenUpdating(request.Id, request.Name);

            Color mappedColor = _mapper.Map(request, color!);

            Color updatedColor = await _colorRepository.UpdateAsync(mappedColor, cancellationToken);

            UpdatedColorResponse response = _mapper.Map<UpdatedColorResponse>(updatedColor);

            return response;
        }
    }
}
