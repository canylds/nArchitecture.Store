using FluentValidation;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator()
    {
        RuleFor(ccc => ccc.Name).NotEmpty().MinimumLength(2);
    }
}