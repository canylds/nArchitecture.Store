using FluentValidation;

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdateProductVariantCommandValidator : AbstractValidator<UpdateProductVariantCommand>
{
    public UpdateProductVariantCommandValidator()
    {
        RuleFor(upvc => upvc.Id).GreaterThan(0);
        RuleFor(upvc => upvc.UnitsInStock).GreaterThanOrEqualTo(0);
    }
}