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

    public GetListProductListItemDto()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductImages = null!;
    }

    public GetListProductListItemDto(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        string? categoryName,
        List<GlplidProductImageDto> productImages)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        CategoryName = categoryName;
        ProductImages = productImages;
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
