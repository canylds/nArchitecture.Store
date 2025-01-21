using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Create;

public class CreateSizeCommand : IRequest<CreatedSizeResponse>, ISecuredRequest
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

    public class CreateSizeCommandHandler
        : IRequestHandler<CreateSizeCommand, CreatedSizeResponse>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;
        private readonly IMapper _mapper;

        public CreateSizeCommandHandler(ISizeRepository sizeRepository,
            SizeBusinessRules sizeBusinessRules,
            IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedSizeResponse> Handle(CreateSizeCommand request,
            CancellationToken cancellationToken)
        {
            await _sizeBusinessRules.SizeNameShouldNotExistWhenCreating(request.Name);

            Size size = _mapper.Map<Size>(request);

            await _sizeRepository.AddAsync(size, cancellationToken);

            CreatedSizeResponse response = _mapper.Map<CreatedSizeResponse>(request);

            return response;
        }
    }
}
