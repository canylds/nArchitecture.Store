using Core.Application.Responses;

namespace Application.Features.ProductVariants.Queries;

public class GetByIdProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }
    public string ProductName { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }

    public GetByIdProductVariantResponse()
    {
        ProductName = string.Empty;
        ColorName = string.Empty;
        SizeName = string.Empty;
    }

    public GetByIdProductVariantResponse(int id,
        int productId,
        int colorId,
        int sizeId,
        int unitsInStock,
        string productName,
        string colorName,
        string sizeName)
    {
        Id = id;
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
        ProductName = productName;
        ColorName = colorName;
        SizeName = sizeName;
    }
}
