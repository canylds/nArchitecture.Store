using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationCLaims;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : IRequest<CreatedColorResponse>, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, ColorsOperationCLaims.Create];

    public CreateColorCommand()
    {
        Name = string.Empty;
    }

    public CreateColorCommand(string name)
    {
        Name = name;
    }

    public class CreateColorCommandHandler
        : IRequestHandler<CreateColorCommand, CreatedColorResponse>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;

        public CreateColorCommandHandler(IColorRepository colorRepository,
            IMapper mapper,
            ColorBusinessRules colorBusinessRules)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request,
            CancellationToken cancellationToken)
        {
            await _colorBusinessRules.ColorNameShouldNotExistWhenCreating(request.Name);

            Color mappedColor = _mapper.Map<Color>(request);

            Color addedColor = await _colorRepository.AddAsync(mappedColor, cancellationToken);

            CreatedColorResponse response = _mapper.Map<CreatedColorResponse>(addedColor);

            return response;
        }
    }
}
