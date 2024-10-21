using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Delete;

public class DeleteSizeCommand : IRequest<DeletedSizeResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SizesOperationClaims.Delete];

    public DeleteSizeCommand()
    {

    }

    public DeleteSizeCommand(int id)
    {
        Id = id;
    }

    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand, DeletedSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public DeleteSizeCommandHandler(IMapper mapper,
            ISizeRepository sizeRepository,
            SizeBusinessRules sizeBusinessRules)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<DeletedSizeResponse> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id,
                cancellationToken: cancellationToken);

            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);

            await _sizeRepository.DeleteAsync(size!, cancellationToken: cancellationToken);

            DeletedSizeResponse response = _mapper.Map<DeletedSizeResponse>(size);

            return response;
        }
    }
}
