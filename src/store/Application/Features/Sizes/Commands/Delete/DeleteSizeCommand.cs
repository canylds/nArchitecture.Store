using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Delete;

public class DeleteSizeCommand : IRequest<DeletedSizeResponse>, ISecuredRequest
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
        private readonly SizeBusinessRules _sizeBusinessRules;
        private readonly ISizeRepository _sizeRepository;

        public DeleteSizeCommandHandler(IMapper mapper,
            SizeBusinessRules sizeBusinessRules,
            ISizeRepository sizeRepository)
        {
            _mapper = mapper;
            _sizeBusinessRules = sizeBusinessRules;
            _sizeRepository = sizeRepository;
        }

        public async Task<DeletedSizeResponse> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id,
                cancellationToken: cancellationToken);

            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);

            Size deletedSize = await _sizeRepository.DeleteAsync(size!, cancellationToken: cancellationToken);

            DeletedSizeResponse response = _mapper.Map<DeletedSizeResponse>(deletedSize);

            return response;
        }
    }
}