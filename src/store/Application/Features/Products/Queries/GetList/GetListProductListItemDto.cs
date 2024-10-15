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

    public GetListProductListItemDto()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public GetListProductListItemDto(int id,
    int? categoryId,
    string name,
    string description,
    double unitPrice,
    string? categoryName)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        CategoryName = categoryName;
    }
}