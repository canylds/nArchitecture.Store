using Core.Application.Dtos;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GetListColorListItemDto()
    {
        Name = string.Empty;
    }

    public GetListColorListItemDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
