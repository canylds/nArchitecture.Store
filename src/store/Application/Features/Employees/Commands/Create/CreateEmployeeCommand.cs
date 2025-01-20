using Application.Features.Employees.Constants;
using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;
using static Application.Features.Employees.Constants.EmployeesOperationClaims;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommand : IRequest<CreatedEmployeeResponse>,
    ISecuredRequest,
    ITransactionalRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string? PhotoUrl { get; set; }

    public string[] Roles => [Admin, Write, EmployeesOperationClaims.Create];

    public CreateEmployeeCommand()
    {
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Title = string.Empty;
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public CreateEmployeeCommand(string email,
        string password,
        string firstName,
        string lastName,
        string title,
        DateTime birthDate,
        DateTime hireDate,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string? photoUrl)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        BirthDate = birthDate;
        HireDate = hireDate;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
        PhotoUrl = photoUrl;
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreatedEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly IUserService _userService;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository,
            IMapper mapper,
            EmployeeBusinessRules employeeBusinessRules,
            IUserService userService)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _userService = userService;
        }

        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = _mapper.Map<User>(request);

            HashingHelper.CreatePasswordHash(request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt);

            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            User createdUser = await _userService.AddAsync(mappedUser);

            Employee mappedEmployee = _mapper.Map<Employee>(request);
            mappedEmployee.UserId = createdUser.Id;

            Employee createdEmployee = await _employeeRepository.AddAsync(mappedEmployee, cancellationToken);

            CreatedEmployeeResponse response = _mapper.Map<CreatedEmployeeResponse>(createdEmployee);
            response = _mapper.Map(createdUser, response);

            return response;
        }
    }
}