using Core.Application.Dtos;
using Core.Application.Responses;

namespace Application.Features.Products.Commands.Update;

public class UpdatedProductResponse : IResponse
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public List<UprProductVariantDto> ProductVariants { get; set; }

    public UpdatedProductResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductVariants = null!;
    }

    public UpdatedProductResponse(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        List<UprProductVariantDto> productVariants)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        ProductVariants = productVariants;
    }
}

public class UprProductVariantDto : IDto
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public UprProductVariantDto()
    {

    }

    public UprProductVariantDto(int id, int colorId, int sizeId, int unitsInStock)
    {
        Id = id;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}
