using Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductListItemDto : IDto
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public string? CategoryName { get; set; }
    public List<GlplidProductImageDto> ProductImages { get; set; }
    public List<GlplidProductVariantDto> ProductVariants { get; set; }

    public GetListProductListItemDto()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductImages = null!;
        ProductVariants = null!;
    }

    public GetListProductListItemDto(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        string? categoryName,
        List<GlplidProductImageDto> productImages,
        List<GlplidProductVariantDto> productVariants)
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

public class GlplidProductImageDto : IDto
{
    public int Id { get; set; }
    public string Url { get; set; }

    public GlplidProductImageDto()
    {
        Url = string.Empty;
    }

    public GlplidProductImageDto(int id, string url)
    {
        Id = id;
        Url = url;
    }
}

public class GlplidProductVariantDto : IDto
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }

    public GlplidProductVariantDto()
    {
        ColorName = string.Empty;
        SizeName = string.Empty;
    }

    public GlplidProductVariantDto(int id,
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
