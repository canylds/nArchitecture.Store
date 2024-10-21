using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Update;

public class UpdateSizeCommand : IRequest<UpdatedSizeResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, SizesOperationClaims.Update];

    public UpdateSizeCommand()
    {
        Name = string.Empty;
    }

    public UpdateSizeCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand, UpdatedSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly SizeBusinessRules _sizeBusinessRules;
        private readonly ISizeRepository _sizeRepository;

        public UpdateSizeCommandHandler(IMapper mapper,
            SizeBusinessRules sizeBusinessRules,
            ISizeRepository sizeRepository)
        {
            _mapper = mapper;
            _sizeBusinessRules = sizeBusinessRules;
            _sizeRepository = sizeRepository;
        }

        public async Task<UpdatedSizeResponse> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id,
                cancellationToken: cancellationToken);

            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);
            await _sizeBusinessRules.SizeNameShouldNotExistWhenUpdating(request.Id, request.Name);

            Size mappedSize = _mapper.Map(request, size!);

            Size updatedSize = await _sizeRepository.UpdateAsync(mappedSize, cancellationToken);

            UpdatedSizeResponse response = _mapper.Map<UpdatedSizeResponse>(updatedSize);

            return response;
        }
    }
}
