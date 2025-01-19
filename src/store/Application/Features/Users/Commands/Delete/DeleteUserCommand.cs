using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeletedUserResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, UsersOperationClaims.Delete];

    public DeleteUserCommand()
    {

    }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(predicate: u => u.Id.Equals(request.Id),
            cancellationToken: cancellationToken);

            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

            await _userRepository.DeleteAsync(user!, cancellationToken: cancellationToken);

            DeletedUserResponse response = _mapper.Map<DeletedUserResponse>(user);

            return response;
        }
    }
}