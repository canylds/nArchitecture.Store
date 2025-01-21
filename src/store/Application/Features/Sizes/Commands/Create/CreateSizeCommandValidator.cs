using FluentValidation;

namespace Application.Features.Sizes.Commands.Create;

public class CreateSizeCommandValidator : AbstractValidator<CreateSizeCommand>
{
    public CreateSizeCommandValidator()
    {
        RuleFor(csc => csc.Name).NotEmpty();
    }
}