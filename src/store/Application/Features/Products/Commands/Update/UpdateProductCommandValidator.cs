using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(upc => upc.Id).GreaterThan(0);
        RuleFor(upc => upc.CategoryId)
            .GreaterThan(0)
            .When(upc => upc.CategoryId != null)
            .WithMessage("CategoryId, null değilse 0'dan büyük olmalıdır.");
        RuleFor(upc => upc.Name).NotEmpty().MinimumLength(2);
        RuleFor(upc => upc.UnitPrice).GreaterThan(0);
        RuleForEach(upc => upc.ProductVariants).ChildRules(productVariant =>
        {
            productVariant.RuleFor(pv => pv.ColorId).GreaterThan(0).WithMessage("ColorId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.SizeId).GreaterThan(0).WithMessage("SizeId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("UnitsInStock 0'dan küçük olamaz.");
        });
        RuleFor(upc => upc.ProductVariants)
            .Must(productVariants => productVariants.GroupBy(productVariant => new
            {
                productVariant.ColorId,
                productVariant.SizeId
            }).All(g => g.Count() == 1))
            .WithMessage("ProductVariants, aynı ColorId ve SizeId değerlerine sahip birden fazla öğe içeremez.");
    }
}
