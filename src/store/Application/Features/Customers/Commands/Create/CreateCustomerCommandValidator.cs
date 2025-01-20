using FluentValidation;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(ccc => ccc.Email).NotEmpty().EmailAddress();
        RuleFor(ccc => ccc.Password).NotEmpty().MinimumLength(4);
        RuleFor(ccc => ccc.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(ccc => ccc.LastName).NotEmpty().MinimumLength(2);
        RuleFor(ccc => ccc.Address).NotEmpty();
        RuleFor(ccc => ccc.City).NotEmpty();
        RuleFor(ccc => ccc.Region).NotEmpty();
        RuleFor(ccc => ccc.PostalCode).NotEmpty();
        RuleFor(ccc => ccc.Country).NotEmpty();
        RuleFor(ccc => ccc.Phone).NotEmpty();
    }
}