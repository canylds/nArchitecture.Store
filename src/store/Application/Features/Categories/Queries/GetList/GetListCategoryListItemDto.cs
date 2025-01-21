using Core.Application.Dtos;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public GetListCategoryListItemDto()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public GetListCategoryListItemDto(int id, string name, string description, string? ımageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = ımageUrl;
    }
}
