using Core.Application.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.CreateBulk;

public class CreatedBulkProductVariantResponse : IResponse
{
    public int ProductId { get; set; }
    public List<CbpvrProductVariantDto> ProductVariants { get; set; }

    public CreatedBulkProductVariantResponse()
    {
        ProductVariants = null!;
    }

    public CreatedBulkProductVariantResponse(int productId, List<CbpvrProductVariantDto> productVariants)
    {
        ProductId = productId;
        ProductVariants = productVariants;
    }
}

public class CbpvrProductVariantDto : IDto
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public CbpvrProductVariantDto()
    {

    }

    public CbpvrProductVariantDto(int id, int colorId, int sizeId, int unitsInStock)
    {
        Id = id;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}
