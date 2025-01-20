using Application.Features.Customers.Constants;
using Application.Features.Customers.Rules;
using Application.Features.Employees.Commands.Create;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<CreatedCustomerResponse>,
    ISecuredRequest,
    ITransactionalRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }

    public string[] Roles => [Admin, Read, CustomersOperationClaims.Create];

    public CreateCustomerCommand()
    {
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public CreateCustomerCommand(string email,
        string password,
        string firstName,
        string lastName,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreatedCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
            CustomerBusinessRules customerBusinessRules,
            IMapper mapper,
            IUserService userService)
        {
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<CreatedCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = _mapper.Map<User>(request);

            HashingHelper.CreatePasswordHash(request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt);

            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User createdUser = await _userService.AddAsync(mappedUser);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            mappedCustomer.UserId = createdUser.Id;

            Customer createdCustomer = await _customerRepository.AddAsync(mappedCustomer, cancellationToken);

            CreatedCustomerResponse response = _mapper.Map<CreatedCustomerResponse>(createdCustomer);
            response = _mapper.Map(createdUser, response);

            return response;
        }
    }
}
