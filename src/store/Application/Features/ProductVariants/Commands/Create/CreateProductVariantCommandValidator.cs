using FluentValidation;

namespace Application.Features.ProductVariants.Commands.Create;

public class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
{
    public CreateProductVariantCommandValidator()
    {
        RuleFor(cpvc => cpvc.ProductId).GreaterThan(0);
        RuleFor(cpvc => cpvc.ColorId).GreaterThan(0);
        RuleFor(cpvc => cpvc.SizeId).GreaterThan(0);
        RuleFor(cpvc => cpvc.UnitsInStock).GreaterThanOrEqualTo(0);
    }
}