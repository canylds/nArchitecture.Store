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
        // .WithMessage("CategoryId must be greater than 0 when it's not null.");
        RuleFor(upc => upc.Name).NotEmpty().MinimumLength(2);
        RuleFor(upc => upc.UnitPrice).GreaterThan(0);
    }
}