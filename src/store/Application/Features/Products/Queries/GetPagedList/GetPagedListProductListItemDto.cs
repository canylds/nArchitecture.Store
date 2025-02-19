using Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetPagedList;

public class GetPagedListProductListItemDto : IDto
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }
    public string? CategoryName { get; set; }
    public List<GplplidProductVariantDto> ProductVariants { get; set; }
    public List<GplplidProductImageDto> ProductImages { get; set; }

    public GetPagedListProductListItemDto()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductVariants = null!;
        ProductImages = null!;
    }
}

public class GplplidProductVariantDto : IDto //GetPagedListProductListItemDtoProductVariantDto
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }

    public GplplidProductVariantDto()
    {
        ColorName = string.Empty;
        SizeName = string.Empty;
    }

    public GplplidProductVariantDto(int id,
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

public class GplplidProductImageDto : IDto //GetPagedListProductListItemDtoProductImageDto
{
    public int Id { get; set; }
    public string Url { get; set; }

    public GplplidProductImageDto()
    {
        Url = string.Empty;
    }

    public GplplidProductImageDto(int id, string url)
    {
        Id = id;
        Url = url;
    }
}