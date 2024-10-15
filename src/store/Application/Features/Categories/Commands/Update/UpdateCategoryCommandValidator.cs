using FluentValidation;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(ucc => ucc.Id).GreaterThan(0);
        RuleFor(ucc => ucc.Name).NotEmpty().MinimumLength(2);
    }
}