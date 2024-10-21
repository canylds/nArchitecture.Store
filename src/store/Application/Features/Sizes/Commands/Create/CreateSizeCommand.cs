using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Create;

public class CreateSizeCommand : IRequest<CreatedSizeResponse>, ISecuredRequest, ILoggableRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, SizesOperationClaims.Create];

    public CreateSizeCommand()
    {
        Name = string.Empty;
    }

    public CreateSizeCommand(string name)
    {
        Name = name;
    }

    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, CreatedSizeResponse>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public CreateSizeCommandHandler(ISizeRepository sizeRepository,
            IMapper mapper,
            SizeBusinessRules sizeBusinessRules)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<CreatedSizeResponse> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            await _sizeBusinessRules.SizeNameShouldNotExistWhenCreating(request.Name);

            Size mappedSize = _mapper.Map<Size>(request);

            Size addedSize = await _sizeRepository.AddAsync(mappedSize, cancellationToken);

            CreatedSizeResponse response = _mapper.Map<CreatedSizeResponse>(addedSize);

            return response;
        }
    }
}
