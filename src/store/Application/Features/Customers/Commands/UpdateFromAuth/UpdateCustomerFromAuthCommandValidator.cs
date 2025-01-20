using FluentValidation;

namespace Application.Features.Customers.Commands.UpdateFromAuth;

public class UpdateCustomerFromAuthCommandValidator : AbstractValidator<UpdateCustomerFromAuthCommand>
{
    public UpdateCustomerFromAuthCommandValidator()
    {
        RuleFor(ucfac => ucfac.Address).NotEmpty();
        RuleFor(ucfac => ucfac.City).NotEmpty();
        RuleFor(ucfac => ucfac.Region).NotEmpty();
        RuleFor(ucfac => ucfac.PostalCode).NotEmpty();
        RuleFor(ucfac => ucfac.Country).NotEmpty();
        RuleFor(ucfac => ucfac.Phone).NotEmpty();
    }
}