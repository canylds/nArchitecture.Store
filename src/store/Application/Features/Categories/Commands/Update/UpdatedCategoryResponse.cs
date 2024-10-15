using Core.Application.Responses;

namespace Application.Features.Categories.Commands.Update;

public class UpdatedCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public UpdatedCategoryResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public UpdatedCategoryResponse(int id, string name, string description, string? imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }
}