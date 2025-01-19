using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.Users.Constants.UsersOperationClaims;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommand : IRequest<CreatedUserResponse>, ISecuredRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string[] Roles => [Admin, Write, UsersOperationClaims.Create];

    public CreateUserCommand()
    {
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public CreateUserCommand(string email, string password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);

            User user = _mapper.Map<User>(request);

            HashingHelper.CreatePasswordHash(request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            User createdUser = await _userRepository.AddAsync(user, cancellationToken);

            CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);

            return response;
        }
    }
}