using FluentValidation;

namespace Application.Features.ProductImages.Commands.CreateBulk;

public class CreateBulkProductImageCommandValidator : AbstractValidator<CreateBulkProductImageCommand>
{
    private static readonly List<string> AllowedExtensions = [".jpg", ".png", ".jpeg", ".webp"];

    public CreateBulkProductImageCommandValidator()
    {
        RuleFor(x => x.Images)
            .NotEmpty()
            .WithMessage("En az bir resim yüklemelisiniz.")
            .Must(images => images.All(image => AllowedExtensions.Contains(Path.GetExtension(image.FileName).ToLower())))
            .WithMessage($"Sadece şu formatlar desteklenmektedir: {string.Join(", ", AllowedExtensions)}");
    }
}