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

    public GetByIdProductResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public GetByIdProductResponse(int id,
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