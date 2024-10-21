using FluentValidation;

namespace Application.Features.Sizes.Commands.Update;

public class UpdateSizeCommandValidator : AbstractValidator<UpdateSizeCommand>
{
    public UpdateSizeCommandValidator()
    {
        RuleFor(usc => usc.Id).GreaterThan(0);
        RuleFor(usc => usc.Name).NotEmpty().MinimumLength(2);
    }
}