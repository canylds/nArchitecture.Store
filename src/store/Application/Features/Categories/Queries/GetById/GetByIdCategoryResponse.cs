using Core.Application.Responses;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public GetByIdCategoryResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public GetByIdCategoryResponse(int id, string name, string description, string? imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }
}