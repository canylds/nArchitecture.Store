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

    public GetByIdProductResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
        ProductImages = null!;
    }

    public GetByIdProductResponse(int id,
        int? categoryId,
        string name,
        string description,
        double unitPrice,
        string? categoryName,
        List<GbiprProductImageDto> productImages)
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
