using FluentValidation;

namespace Application.Features.Colors.Commands.Update;

public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
{
    public UpdateColorCommandValidator()
    {
        RuleFor(ucc => ucc.Id).GreaterThan(0);
        RuleFor(ucc => ucc.Name).NotEmpty().MinimumLength(2);
    }
}