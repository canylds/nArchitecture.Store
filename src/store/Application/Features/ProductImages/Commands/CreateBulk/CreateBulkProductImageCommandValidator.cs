using FluentValidation;

namespace Application.Features.ProductImages.Commands.CreateBulk;

public class CreateBulkProductImageCommandValidator : AbstractValidator<CreateBulkProductImageCommand>
{
    public CreateBulkProductImageCommandValidator()
    {
        RuleFor(cbpic => cbpic.ProductId).GreaterThan(0);
        RuleFor(cbpic => cbpic.Images).NotEmpty();
    }
}
