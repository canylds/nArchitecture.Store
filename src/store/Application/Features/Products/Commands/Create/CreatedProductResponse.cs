using Core.Application.Responses;

namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }

    public CreatedProductResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public CreatedProductResponse(int? categoryId,
        string name,
        string description,
        double unitPrice)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }
}