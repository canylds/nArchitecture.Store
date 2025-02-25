namespace Application.Features.ProductImages.Constants;

public static class ProductImagesOperationClaims
{
    private const string _section = "ProductImages";

    public const string Admin = $"{_section}.Admin";

    public const string Write = $"{_section}.Write";
    public const string Read = $"{_section}.Read";

    public const string CreateBulk = $"{_section}.CreateBulk";
    public const string Delete = $"{_section}.Delete";
}