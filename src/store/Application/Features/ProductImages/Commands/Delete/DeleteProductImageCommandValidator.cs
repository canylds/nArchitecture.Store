using FluentValidation;

namespace Application.Features.ProductImages.Commands.Delete;

public class DeleteProductImageCommandValidator : AbstractValidator<DeleteProductImageCommand>
{
    public DeleteProductImageCommandValidator()
    {
        RuleFor(dpic => dpic.Id).GreaterThan(0);
    }
}