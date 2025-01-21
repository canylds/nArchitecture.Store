using Core.Application.Responses;

namespace Application.Features.Categories.Commands.Create;

public class CreatedCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public CreatedCategoryResponse()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public CreatedCategoryResponse(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
