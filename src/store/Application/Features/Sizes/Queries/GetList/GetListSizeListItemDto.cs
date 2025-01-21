using Core.Application.Dtos;

namespace Application.Features.Sizes.Queries.GetList;

public class GetListSizeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GetListSizeListItemDto()
    {
        Name = string.Empty;
    }

    public GetListSizeListItemDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
