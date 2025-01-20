using FluentValidation;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(cec => cec.Email).NotEmpty().EmailAddress();
        RuleFor(cec => cec.Password).NotEmpty().MinimumLength(4);
        RuleFor(cec => cec.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(cec => cec.LastName).NotEmpty().MinimumLength(2);
        RuleFor(cec => cec.Title).NotEmpty();
        RuleFor(cec => cec.Address).NotEmpty();
        RuleFor(cec => cec.City).NotEmpty();
        RuleFor(cec => cec.Region).NotEmpty();
        RuleFor(cec => cec.PostalCode).NotEmpty();
        RuleFor(cec => cec.Country).NotEmpty();
        RuleFor(cec => cec.Phone).NotEmpty();
    }
}