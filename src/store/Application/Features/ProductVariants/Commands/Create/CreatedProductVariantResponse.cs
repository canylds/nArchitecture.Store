using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.Create;

public class CreatedProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public CreatedProductVariantResponse()
    {
    }

    public CreatedProductVariantResponse(int id,
        int productId,
        int colorId,
        int sizeId,
        int unitsInStock)
    {
        Id = id;
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}
