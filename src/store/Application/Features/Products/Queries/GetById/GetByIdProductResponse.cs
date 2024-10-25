using Core.Application.Dtos;
using Core.Application.Responses;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse : IResponse
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public string? CategoryName { get; set; }
    public List<GbiprProductImageDto> ProductImages { get; set; }
    public List<GbiprProductVariantDto> ProductVariants { get; set; }

    public GetByIdProductResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductImages = null!;
        ProductVariants = null!;
    }

    public GetByIdProductResponse(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        string? categoryName,
        List<GbiprProductImageDto> productImages,
        List<GbiprProductVariantDto> productVariants)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        CategoryName = categoryName;
        ProductImages = productImages;
        ProductVariants = productVariants;
    }
}

public class GbiprProductImageDto : IDto
{
    public int Id { get; set; }
    public string Url { get; set; }

    public GbiprProductImageDto()
    {
        Url = string.Empty;
    }

    public GbiprProductImageDto(int id, string url)
    {
        Id = id;
        Url = url;
    }
}

public class GbiprProductVariantDto : IDto
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }

    public GbiprProductVariantDto()
    {
        ColorName = string.Empty;
        SizeName = string.Empty;
    }

    public GbiprProductVariantDto(int id,
        int colorId,
        int sizeId,
        int unitsInStock,
        string colorName,
        string sizeName)
    {
        Id = id;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
        ColorName = colorName;
        SizeName = sizeName;
    }
}
