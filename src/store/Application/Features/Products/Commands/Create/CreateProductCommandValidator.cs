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
        RuleFor(cpc => cpc.Name).NotEmpty().MinimumLength(2);
        RuleFor(cpc => cpc.UnitPrice).GreaterThan(0);
        RuleForEach(cpc => cpc.ProductVariants).ChildRules(productVariant =>
        {
            productVariant.RuleFor(pv => pv.ColorId).GreaterThan(0).WithMessage("ColorId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.SizeId).GreaterThan(0).WithMessage("SizeId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("UnitsInStock 0'dan küçük olamaz.");
        });
        RuleFor(cpc => cpc.ProductVariants)
            .Must(productVariants => productVariants.GroupBy(productVariant => new
            {
                productVariant.ColorId,
                productVariant.SizeId
            }).All(g => g.Count() == 1))
            .WithMessage("ProductVariants, aynı ColorId ve SizeId değerlerine sahip birden fazla öğe içeremez.");
    }
}
