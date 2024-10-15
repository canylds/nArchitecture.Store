using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(cpc => cpc.CategoryId)
        .GreaterThan(0)
        .When(cpc => cpc.CategoryId != null)
        .WithMessage("CategoryId, null değilse 0'dan büyük olmalıdır.");
        // .WithMessage("CategoryId must be greater than 0 when it's not null.");
        RuleFor(cpc => cpc.Name).NotEmpty().MinimumLength(2);
        RuleFor(cpc => cpc.UnitPrice).GreaterThan(0);
    }
}