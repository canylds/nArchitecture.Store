using FluentValidation;

namespace Application.Features.ProductVariants.Commands.CreateBulk;

public class CreateBulkProductVariantCommandValidator : AbstractValidator<CreateBulkProductVariantCommand>
{
    public CreateBulkProductVariantCommandValidator()
    {
        RuleFor(cbpvc => cbpvc.ProductId).GreaterThan(0);
        RuleForEach(cbpvc => cbpvc.ProductVariants).ChildRules(productVariant =>
        {
            productVariant.RuleFor(pv => pv.ColorId).GreaterThan(0).WithMessage("ColorId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.SizeId).GreaterThan(0).WithMessage("SizeId 0'dan büyük olmalıdır.");
            productVariant.RuleFor(pv => pv.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("UnitsInStock 0'dan küçük olamaz.");
        });
        RuleFor(cbpvc => cbpvc.ProductVariants)
            .Must(productVariants => productVariants.GroupBy(productVariant => new
            {
                productVariant.ColorId,
                productVariant.SizeId
            }).All(g => g.Count() == 1))
            .WithMessage("ProductVariants, aynı ColorId ve SizeId değerlerine sahip birden fazla öğe içeremez.");
    }
}
